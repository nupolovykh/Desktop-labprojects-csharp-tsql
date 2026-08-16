#!/usr/bin/env python3
"""Renders captured console I/O as a dark terminal-style PNG.

Usage: render_terminal_screenshot.py <title> <transcript-file> <output-png>
"""
import sys
from PIL import Image, ImageDraw, ImageFont

FONT_PATHS = [
    "/usr/share/fonts/truetype/dejavu/DejaVuSansMono.ttf",
    "/usr/share/fonts/truetype/liberation/LiberationMono-Regular.ttf",
]
FONT_SIZE = 16
PADDING = 20
LINE_SPACING = 6
TITLEBAR_HEIGHT = 32
BG_COLOR = (30, 30, 30)
TITLEBAR_COLOR = (50, 50, 50)
TEXT_COLOR = (220, 220, 220)
TITLE_COLOR = (200, 200, 200)
DOT_COLORS = [(255, 95, 86), (255, 189, 46), (39, 201, 63)]
MIN_WIDTH = 480


def load_font(size):
    for path in FONT_PATHS:
        try:
            return ImageFont.truetype(path, size)
        except OSError:
            continue
    return ImageFont.load_default()


def main():
    title, transcript_path, output_path = sys.argv[1], sys.argv[2], sys.argv[3]
    with open(transcript_path, "r", encoding="utf-8", errors="replace") as f:
        text = f.read().rstrip("\n")
    lines = text.split("\n") if text else ["(no output)"]

    font = load_font(FONT_SIZE)
    title_font = load_font(FONT_SIZE - 2)

    dummy = Image.new("RGB", (1, 1))
    draw = ImageDraw.Draw(dummy)
    line_widths = [draw.textbbox((0, 0), line, font=font)[2] for line in lines]
    text_width = max(line_widths, default=0)
    line_height = font.getbbox("Ag")[3] + LINE_SPACING

    width = max(MIN_WIDTH, text_width + PADDING * 2)
    height = TITLEBAR_HEIGHT + PADDING * 2 + line_height * len(lines)

    img = Image.new("RGB", (width, height), BG_COLOR)
    draw = ImageDraw.Draw(img)

    draw.rectangle([0, 0, width, TITLEBAR_HEIGHT], fill=TITLEBAR_COLOR)
    for i, color in enumerate(DOT_COLORS):
        cx = 16 + i * 20
        draw.ellipse([cx - 6, TITLEBAR_HEIGHT // 2 - 6, cx + 6, TITLEBAR_HEIGHT // 2 + 6], fill=color)
    draw.text((width / 2, TITLEBAR_HEIGHT / 2), title, font=title_font, fill=TITLE_COLOR, anchor="mm")

    y = TITLEBAR_HEIGHT + PADDING
    for line in lines:
        draw.text((PADDING, y), line, font=font, fill=TEXT_COLOR)
        y += line_height

    img.save(output_path)
    print(f"Saved {output_path}")


if __name__ == "__main__":
    main()
