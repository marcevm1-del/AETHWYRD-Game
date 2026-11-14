#!/usr/bin/env python3
"""Local image generation for AETHWYRD with Stable Diffusion 1.5 (no API key, no paid service).

Runs on the GTX 1650 (4 GB). GTX 16-series cards give black images in half precision, so on those it uses full
precision with model offload (slower, about a minute per image); other cards use half precision. It shares TripoSR's Python environment, so run it with
E:\\tsr-venv\\Scripts\\python.exe (that venv has torch with CUDA, diffusers and transformers):

  E:\\tsr-venv\\Scripts\\python.exe Tools\\ai_images\\local_sd.py --prompt "a sturdy wooden supply crate with iron bands"
  ... --style concept --prompt "a misty forest shrine at dawn" --width 768 --height 512 --count 2 --seed 7

--style object (the default) adds the framing TripoSR needs: one whole object, centred, plain white background,
three-quarter view, soft even light. --style concept leaves the prompt as it is, for mood and concept pictures.

Output: Art/Generation/staging/images/<slug>-<seed>.png (gitignored) with a .json sidecar (model, licence, prompt,
seed, steps, size, date, sha256). The last line printed is "OUT <path>" for each image, so other tools can read it.

Model: stable-diffusion-v1-5/stable-diffusion-v1-5 (CreativeML OpenRAIL-M: commercial use of outputs allowed, with
the licence's use restrictions). The weights (about 2 GB in fp16) download from Hugging Face on first run.
The model's safety checker stays on (teen rating); a flagged image comes back black and is reported.
"""
import argparse
import datetime
import hashlib
import json
import os
import re
import sys

HERE = os.path.dirname(os.path.abspath(__file__))
ROOT = os.path.abspath(os.path.join(HERE, "..", ".."))
DEFAULT_OUT = os.path.join(ROOT, "Art", "Generation", "staging", "images")
MODEL = "stable-diffusion-v1-5/stable-diffusion-v1-5"
LICENCE = "CreativeML OpenRAIL-M (commercial use of outputs allowed; use restrictions apply)"
OBJECT_STYLE = ("single object, centered, whole object fully visible, plain white background, three-quarter view, "
                "soft even studio lighting, stylized anime fantasy game asset, clean shapes, bright colors")
CONCEPT_STYLE = "stylized anime fantasy concept art, bright flowing colors, clean cel shading"
NEGATIVE = ("text, watermark, logo, signature, frame, border, multiple objects, cropped, cut off, blurry, lowres, "
            "deformed, extra parts, busy background, shadow on background, nsfw, gore")


def slug(text):
    s = re.sub(r"[^a-z0-9]+", "-", text.lower()).strip("-")
    return (s[:48] or "image").rstrip("-")


def build_prompt(prompt, style):
    if style == "object":
        return prompt.strip().rstrip(",") + ", " + OBJECT_STYLE
    if style == "concept":
        return prompt.strip().rstrip(",") + ", " + CONCEPT_STYLE
    return prompt


def needs_full_precision(name):
    """GTX 16-series cards produce NaN (black images) from Stable Diffusion in half precision.

    Measured on a GTX 1650: fp16 everywhere gives a black image, and keeping only the VAE in fp32
    does not help, because the NaN comes out of the UNet. Full precision works but does not fit in
    4 GB, so those cards run with model offload: about 3 minutes an image once the model is loaded,
    and several more the first time, when it is read from disk.
    """
    return "GTX 16" in (name or "").upper()


def load_pipeline(model, cpu, half=None):
    import torch
    from diffusers import StableDiffusionPipeline
    use_cuda = torch.cuda.is_available() and not cpu
    name = torch.cuda.get_device_name(0) if use_cuda else ""
    if half is None:
        half = use_cuda and not needs_full_precision(name)
    dtype = torch.float16 if (use_cuda and half) else torch.float32
    # The fp16 weight files are the ones we download (about 2 GB); they load fine as float32 too.
    try:
        pipe = StableDiffusionPipeline.from_pretrained(model, torch_dtype=dtype, variant="fp16")
    except Exception:
        pipe = StableDiffusionPipeline.from_pretrained(model, torch_dtype=dtype)
    pipe.enable_attention_slicing()
    try:
        pipe.enable_vae_slicing()
    except Exception:
        pass
    note = "fp16" if dtype == torch.float16 else "fp32"
    if use_cuda:
        vram_gb = torch.cuda.get_device_properties(0).total_memory / (1024 ** 3)
        if dtype == torch.float32 and vram_gb < 6:
            pipe.enable_model_cpu_offload()  # full precision on a small card: only the active part on the GPU
        else:
            pipe = pipe.to("cuda")
    return pipe, ("cuda (%s, %s)" % (name, note) if use_cuda else "cpu")


def main(argv=None):
    ap = argparse.ArgumentParser(description="Local Stable Diffusion 1.5 images for AETHWYRD (no key needed)")
    ap.add_argument("--prompt", required=True)
    ap.add_argument("--style", choices=["object", "concept", "raw"], default="object")
    ap.add_argument("--negative", default=NEGATIVE)
    ap.add_argument("--steps", type=int, default=25)
    ap.add_argument("--guidance", type=float, default=7.0)
    ap.add_argument("--width", type=int, default=512)
    ap.add_argument("--height", type=int, default=512)
    ap.add_argument("--seed", type=int, default=None, help="first seed; each extra image adds 1")
    ap.add_argument("--count", type=int, default=1)
    ap.add_argument("--out", default=DEFAULT_OUT)
    ap.add_argument("--model", default=MODEL)
    ap.add_argument("--cpu", action="store_true", help="force CPU (very slow)")
    ap.add_argument("--half", action="store_true", help="force half precision (do not use on GTX 16-series: black images)")
    ap.add_argument("--full", action="store_true", help="force full precision")
    ap.add_argument("--dry-run", action="store_true", help="print the full prompt and exit (no torch needed)")
    a = ap.parse_args(argv)
    if a.width % 8 or a.height % 8 or not (256 <= a.width <= 1024 and 256 <= a.height <= 1024):
        sys.exit("width and height must be multiples of 8 between 256 and 1024")
    full = build_prompt(a.prompt, a.style)
    if a.dry_run:
        print("prompt: " + full)
        print("negative: " + a.negative)
        return 0
    import torch
    seed0 = a.seed if a.seed is not None else int.from_bytes(os.urandom(4), "little") % 2_000_000_000
    pipe, device = load_pipeline(a.model, a.cpu, True if a.half else (False if a.full else None))
    os.makedirs(a.out, exist_ok=True)
    for i in range(a.count):
        seed = seed0 + i
        gen = torch.Generator(device="cpu").manual_seed(seed)
        res = pipe(full, negative_prompt=a.negative, num_inference_steps=a.steps, guidance_scale=a.guidance,
                   width=a.width, height=a.height, generator=gen)
        img = res.images[0]
        flagged = bool(getattr(res, "nsfw_content_detected", None) and res.nsfw_content_detected[0])
        path = os.path.join(a.out, "%s-%d.png" % (slug(a.prompt), seed))
        img.save(path)
        with open(path, "rb") as f:
            digest = hashlib.sha256(f.read()).hexdigest()
        side = {"tool": "Tools/ai_images/local_sd.py", "model": a.model, "licence": LICENCE, "device": device,
                "prompt": a.prompt, "fullPrompt": full, "negative": a.negative, "style": a.style, "seed": seed,
                "steps": a.steps, "guidance": a.guidance, "width": a.width, "height": a.height,
                "safetyFlagged": flagged, "date": datetime.datetime.now().isoformat(timespec="seconds"),
                "sha256": digest}
        with open(os.path.splitext(path)[0] + ".json", "w", encoding="utf-8") as f:
            json.dump(side, f, indent=2)
        lo, hi = img.convert("L").getextrema()
        if hi - lo < 8:
            print("WARNING: the image is blank (seed %d): half-precision fault or the safety checker; try --full or another seed" % seed)
            side["blank"] = True
            with open(os.path.splitext(path)[0] + ".json", "w", encoding="utf-8") as f:
                json.dump(side, f, indent=2)
            print("BLANK " + path, flush=True)
            continue
        print("OUT " + path, flush=True)
    return 0


if __name__ == "__main__":
    sys.exit(main())
