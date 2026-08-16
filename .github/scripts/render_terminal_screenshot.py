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
MAX_WIDTH = 900


def load_font(size):
    for path in FONT_PATHS:
        try:
            return ImageFont.truetype(path, size)
        except OSError:
            continue
    return ImageFont.load_default()


def wrap_line(line, font, draw, max_text_width):
    """Break a line at whitespace so no rendered line exceeds max_text_width;
    a single very long unbroken run gets hard-cut rather than overflowing."""
    if draw.textbbox((0, 0), line, font=font)[2] <= max_text_width:
        return [line]

    words = line.split(" ")
    wrapped, current = [], ""
    for word in words:
        candidate = f"{current} {word}".strip()
        if draw.textbbox((0, 0), candidate, font=font)[2] <= max_text_width or not current:
            current = candidate
        else:
            wrapped.append(current)
            current = word
    if current:
        wrapped.append(current)

    # A single "word" (e.g. a long path with no spaces) can still overflow -
    # hard-cut it into chunks.
    final = []
    for piece in wrapped:
        while draw.textbbox((0, 0), piece, font=font)[2] > max_text_width and len(piece) > 1:
            cut = len(piece) // 2
            while cut > 1 and draw.textbbox((0, 0), piece[:cut], font=font)[2] > max_text_width:
                cut -= 1
            final.append(piece[:cut])
            piece = piece[cut:]
        final.append(piece)
    return final


def main():
    title, transcript_path, output_path = sys.argv[1], sys.argv[2], sys.argv[3]
    with open(transcript_path, "r", encoding="utf-8", errors="replace") as f:
        text = f.read().rstrip("\n")
    raw_lines = text.split("\n") if text else ["(no output)"]

    font = load_font(FONT_SIZE)
    title_font = load_font(FONT_SIZE - 2)

    dummy = Image.new("RGB", (1, 1))
    draw = ImageDraw.Draw(dummy)

    max_text_width = MAX_WIDTH - PADDING * 2
    lines = []
    for raw_line in raw_lines:
        lines.extend(wrap_line(raw_line, font, draw, max_text_width))

    line_widths = [draw.textbbox((0, 0), line, font=font)[2] for line in lines]
    text_width = max(line_widths, default=0)
    line_height = font.getbbox("Ag")[3] + LINE_SPACING

    width = max(MIN_WIDTH, min(MAX_WIDTH, text_width + PADDING * 2))
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
