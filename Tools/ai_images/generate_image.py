#!/usr/bin/env python3
"""Generate concept images with an AI provider (Gemini first, OpenAI optional).

Standard library only. API keys come from environment variables and are never printed, logged or saved.
Every image is written to a staging folder (gitignored) with a JSON sidecar that records the provider, model,
prompt, date and a hash. Nothing here puts a file into Game/: an image only goes into the game after its tool and
terms are registered in 13_Production/third_party_assets.md.

Examples:
  python Tools/ai_images/generate_image.py --provider gemini --prompt "a young adventurer, front view" --dry-run
  python Tools/ai_images/generate_image.py --provider gemini --list-models
  python Tools/ai_images/generate_image.py --provider gemini --prompt "a young adventurer, front view"
"""
import argparse
import base64
import datetime
import hashlib
import json
import os
import re
import sys
import urllib.error
import urllib.request

HERE = os.path.dirname(os.path.abspath(__file__))
ROOT = os.path.abspath(os.path.join(HERE, "..", ".."))
CONFIG_PATH = os.path.join(HERE, "providers.json")
DEFAULT_OUT = os.path.join(ROOT, "Art", "Generation", "staging", "images")
TIMEOUT_SECONDS = 180


class ProviderError(Exception):
    """A problem the user can act on (missing key, bad response). Never contains a key."""


def load_config(path=CONFIG_PATH):
    with open(path, encoding="utf-8") as f:
        return json.load(f)


def find_key(provider_cfg, environ=None):
    environ = os.environ if environ is None else environ
    for name in provider_cfg.get("envKeys", []):
        value = environ.get(name, "").strip()
        if value:
            return value
    names = " or ".join(provider_cfg.get("envKeys", []))
    raise ProviderError(
        "No API key found. Set the environment variable %s yourself (for example in PowerShell: "
        "$env:%s = 'your key') and run this again. The key is never written to any file."
        % (names, provider_cfg["envKeys"][0])
    )


def final_prompt(prompt, house_style, use_house_style=True):
    prompt = prompt.strip()
    if use_house_style and house_style:
        return prompt + ". Style: " + house_style
    return prompt


# ---- Gemini (REST) ----------------------------------------------------------------------------------------------

def build_gemini_request(cfg, model, prompt):
    url = "%s/models/%s:generateContent" % (cfg["endpoint"].rstrip("/"), model)
    body = {
        "contents": [{"parts": [{"text": prompt}]}],
        "generationConfig": {"responseModalities": ["TEXT", "IMAGE"]},
    }
    return url, body


def parse_gemini_response(data):
    """Return (image_bytes, mime, text) from a generateContent response, or raise ProviderError."""
    if "error" in data:
        raise ProviderError("Gemini returned an error: %s" % data["error"].get("message", "unknown"))
    candidates = data.get("candidates") or []
    if not candidates:
        reason = (data.get("promptFeedback") or {}).get("blockReason")
        raise ProviderError("Gemini returned no image%s." % (" (blocked: %s)" % reason if reason else ""))
    text, image, mime = [], None, None
    for part in (candidates[0].get("content") or {}).get("parts", []):
        if "text" in part:
            text.append(part["text"])
        inline = part.get("inlineData") or part.get("inline_data")
        if inline and inline.get("data"):
            image = base64.b64decode(inline["data"])
            mime = inline.get("mimeType") or inline.get("mime_type") or "image/png"
    if image is None:
        raise ProviderError("Gemini answered with text only: %s" % " ".join(text)[:300])
    return image, mime, " ".join(text)


# ---- OpenAI (REST) ----------------------------------------------------------------------------------------------

def build_openai_request(cfg, model, prompt):
    url = "%s/images/generations" % cfg["endpoint"].rstrip("/")
    body = {"model": model, "prompt": prompt, "n": 1, "size": "1024x1024"}
    return url, body


def parse_openai_response(data):
    if "error" in data:
        raise ProviderError("OpenAI returned an error: %s" % data["error"].get("message", "unknown"))
    items = data.get("data") or []
    if not items or not items[0].get("b64_json"):
        raise ProviderError("OpenAI returned no inline image data.")
    return base64.b64decode(items[0]["b64_json"]), "image/png", items[0].get("revised_prompt", "")


BUILDERS = {
    "gemini-rest": (build_gemini_request, parse_gemini_response),
    "openai-images": (build_openai_request, parse_openai_response),
}


def auth_headers(kind, key):
    if kind == "gemini-rest":
        return {"x-goog-api-key": key, "Content-Type": "application/json"}
    return {"Authorization": "Bearer " + key, "Content-Type": "application/json"}


def http_json(url, headers, body=None):
    data = None if body is None else json.dumps(body).encode("utf-8")
    req = urllib.request.Request(url, data=data, headers=headers, method="POST" if body is not None else "GET")
    try:
        with urllib.request.urlopen(req, timeout=TIMEOUT_SECONDS) as resp:
            return json.loads(resp.read().decode("utf-8"))
    except urllib.error.HTTPError as e:
        try:
            detail = json.loads(e.read().decode("utf-8"))
            message = (detail.get("error") or {}).get("message", "")
        except Exception:
            message = ""
        raise ProviderError("The provider answered HTTP %d. %s" % (e.code, message[:300]))
    except urllib.error.URLError as e:
        raise ProviderError("Could not reach the provider: %s" % e.reason)


def list_models(kind, cfg, key):
    headers = auth_headers(kind, key)
    if kind == "gemini-rest":
        data = http_json(cfg["endpoint"].rstrip("/") + "/models?pageSize=200", headers)
        rows = [m for m in data.get("models", []) if "image" in m.get("name", "").lower()]
        return ["%s  (%s)" % (m["name"], ",".join(m.get("supportedGenerationMethods", []))) for m in rows]
    data = http_json(cfg["endpoint"].rstrip("/") + "/models", headers)
    return sorted(m["id"] for m in data.get("data", []) if "image" in m.get("id", "").lower())


# ---- Output -----------------------------------------------------------------------------------------------------

def slug(text, limit=40):
    s = re.sub(r"[^a-z0-9]+", "-", text.lower()).strip("-")
    return (s[:limit].strip("-")) or "image"


def write_with_sidecar(out_dir, provider, model, prompt, full_prompt, image, mime, note, now=None):
    now = now or datetime.datetime.now(datetime.timezone.utc)
    ext = {"image/png": ".png", "image/jpeg": ".jpg", "image/webp": ".webp"}.get(mime, ".bin")
    os.makedirs(out_dir, exist_ok=True)
    stem = "%s_%s_%s" % (provider, now.strftime("%Y%m%d-%H%M%S"), slug(prompt))
    image_path = os.path.join(out_dir, stem + ext)
    with open(image_path, "wb") as f:
        f.write(image)
    sidecar = {
        "tool": "Tools/ai_images/generate_image.py",
        "provider": provider,
        "model": model,
        "prompt": prompt,
        "finalPrompt": full_prompt,
        "createdUtc": now.isoformat(),
        "mime": mime,
        "bytes": len(image),
        "sha256": hashlib.sha256(image).hexdigest(),
        "providerNote": note,
        "status": "staging: not registered in 13_Production/third_party_assets.md; do not import into Game/",
    }
    with open(image_path + ".json", "w", encoding="utf-8") as f:
        json.dump(sidecar, f, indent=2)
        f.write("\n")
    return image_path


def main(argv=None, environ=None):
    ap = argparse.ArgumentParser(description="Generate a concept image with an AI provider.")
    ap.add_argument("--provider", help="provider name from providers.json (default: the configured default)")
    ap.add_argument("--prompt", help="what to draw")
    ap.add_argument("--model", help="override the model id")
    ap.add_argument("--out", default=DEFAULT_OUT, help="output folder (default: Art/Generation/staging/images)")
    ap.add_argument("--no-house-style", action="store_true", help="do not append the house style")
    ap.add_argument("--list-models", action="store_true", help="list the image models the account offers (needs a key)")
    ap.add_argument("--dry-run", action="store_true", help="print the request without sending it (no key needed)")
    args = ap.parse_args(argv)

    cfg = load_config()
    name = args.provider or cfg["defaultProvider"]
    if name not in cfg["providers"]:
        print("Unknown provider '%s'. Known: %s" % (name, ", ".join(cfg["providers"])), file=sys.stderr)
        return 2
    pcfg = cfg["providers"][name]
    kind = pcfg["kind"]
    model = args.model or pcfg["model"]
    build, parse = BUILDERS[kind]

    try:
        if args.list_models:
            for line in list_models(kind, pcfg, find_key(pcfg, environ)):
                print(line)
            return 0
        if not args.prompt:
            print("Give --prompt (or --list-models).", file=sys.stderr)
            return 2
        full = final_prompt(args.prompt, cfg.get("houseStyle", ""), not args.no_house_style)
        url, body = build(pcfg, model, full)
        if args.dry_run:
            print(json.dumps({"provider": name, "model": model, "modelStatus": pcfg.get("modelStatus"),
                              "url": url, "body": body}, indent=2))
            return 0
        key = find_key(pcfg, environ)
        data = http_json(url, auth_headers(kind, key), body)
        image, mime, text = parse(data)
        path = write_with_sidecar(args.out, name, model, args.prompt, full, image, mime, pcfg.get("termsNote", ""))
        print("Wrote " + path)
        if text:
            print("Provider note: " + text[:300])
        return 0
    except ProviderError as e:
        print("Error: %s" % e, file=sys.stderr)
        return 2


if __name__ == "__main__":
    sys.exit(main())
