# AI image generation (Gemini first)

`generate_image.py` makes concept images with an AI provider. Standard library only, no installs.

## Set your key (you do this, not Claude)
PowerShell, for this window only:

```powershell
$env:GEMINI_API_KEY = "your key"
```

The key is read from the environment and is never printed, logged or written to a file.

## Use it
```powershell
python Tools\ai_images\generate_image.py --provider gemini --list-models        # which image models your account offers
python Tools\ai_images\generate_image.py --provider gemini --prompt "a young adventurer, front view" --dry-run   # no key needed
python Tools\ai_images\generate_image.py --provider gemini --prompt "a young adventurer, front view"
python Tools\ai_images\generate_image.py --provider openai --prompt "..."      # needs OPENAI_API_KEY
```

Images go to `Art/Generation/staging/images/` (gitignored) with a `.json` sidecar (provider, model, prompt, date, hash). The house style from `providers.json` is appended unless you pass `--no-house-style`.

## Check
`python -I Tools\ai_images\test_generate_image.py` runs 9 offline tests (no network, no key).

## Honest status
- The Gemini model id in `providers.json` is a starting point and has **not** been checked against a live account; run `--list-models`, then set `model` there or pass `--model`.
- The live Gemini and OpenAI calls have **not** been exercised (no key was used when this was built).
- Other tools exist in Claude Desktop (Higgsfield, Canva, Figma, Miro) and can cost paid credits; they are not wired in here.
- Nothing generated goes into `Game/` until it is registered in `13_Production/third_party_assets.md`.
