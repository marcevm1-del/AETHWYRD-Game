"""Offline tests for generate_image.py: no network, no keys. Run: python -I Tools/ai_images/test_generate_image.py"""
import base64
import io
import json
import os
import sys
import tempfile
import unittest
from contextlib import redirect_stderr, redirect_stdout

sys.path.insert(0, os.path.dirname(os.path.abspath(__file__)))
import generate_image as g  # noqa: E402

PNG = b"\x89PNG\r\n\x1a\nFAKE"


class GeminiTests(unittest.TestCase):
    def test_request_shape(self):
        cfg = g.load_config()["providers"]["gemini"]
        url, body = g.build_gemini_request(cfg, "some-model", "a cat")
        self.assertTrue(url.endswith("/models/some-model:generateContent"))
        self.assertEqual(body["generationConfig"]["responseModalities"], ["TEXT", "IMAGE"])
        self.assertEqual(body["contents"][0]["parts"][0]["text"], "a cat")

    def test_parse_inline_image(self):
        data = {"candidates": [{"content": {"parts": [
            {"text": "here"}, {"inlineData": {"mimeType": "image/png", "data": base64.b64encode(PNG).decode()}}]}}]}
        image, mime, text = g.parse_gemini_response(data)
        self.assertEqual(image, PNG)
        self.assertEqual(mime, "image/png")
        self.assertEqual(text, "here")

    def test_text_only_and_blocked_and_error(self):
        with self.assertRaises(g.ProviderError):
            g.parse_gemini_response({"candidates": [{"content": {"parts": [{"text": "no image"}]}}]})
        with self.assertRaises(g.ProviderError):
            g.parse_gemini_response({"candidates": [], "promptFeedback": {"blockReason": "SAFETY"}})
        with self.assertRaises(g.ProviderError):
            g.parse_gemini_response({"error": {"message": "bad"}})


class OpenAITests(unittest.TestCase):
    def test_parse(self):
        data = {"data": [{"b64_json": base64.b64encode(PNG).decode(), "revised_prompt": "x"}]}
        image, mime, _ = g.parse_openai_response(data)
        self.assertEqual(image, PNG)
        with self.assertRaises(g.ProviderError):
            g.parse_openai_response({"data": []})


class KeyAndCliTests(unittest.TestCase):
    def test_missing_key_message_has_no_key_and_names_the_variable(self):
        cfg = g.load_config()["providers"]["gemini"]
        with self.assertRaises(g.ProviderError) as ctx:
            g.find_key(cfg, environ={})
        self.assertIn("GEMINI_API_KEY", str(ctx.exception))

    def test_key_is_found_from_the_environment_only(self):
        cfg = g.load_config()["providers"]["gemini"]
        self.assertEqual(g.find_key(cfg, environ={"GOOGLE_API_KEY": " abc "}), "abc")

    def test_dry_run_needs_no_key_and_prints_no_key(self):
        out = io.StringIO()
        with redirect_stdout(out):
            code = g.main(["--provider", "gemini", "--prompt", "a hero", "--dry-run"], environ={})
        self.assertEqual(code, 0)
        shown = json.loads(out.getvalue())
        self.assertIn("a hero", shown["body"]["contents"][0]["parts"][0]["text"])
        self.assertNotIn("key", out.getvalue().lower().replace("api key", ""))

    def test_real_run_without_key_fails_clearly(self):
        err = io.StringIO()
        with redirect_stderr(err):
            code = g.main(["--provider", "gemini", "--prompt", "a hero"], environ={})
        self.assertEqual(code, 2)
        self.assertIn("No API key found", err.getvalue())

    def test_sidecar_is_written_with_hash(self):
        with tempfile.TemporaryDirectory() as d:
            path = g.write_with_sidecar(d, "gemini", "m", "A Hero!", "A Hero! Style: x", PNG, "image/png", "note")
            self.assertTrue(path.endswith(".png"))
            with open(path + ".json", encoding="utf-8") as f:
                side = json.load(f)
            self.assertEqual(side["provider"], "gemini")
            self.assertEqual(len(side["sha256"]), 64)
            self.assertIn("do not import into Game/", side["status"])


if __name__ == "__main__":
    unittest.main()
