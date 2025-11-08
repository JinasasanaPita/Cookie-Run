import os
import json

# Paths
DATA_DIR = "braverse_data"
IMAGE_DIR = os.path.join(DATA_DIR, "images")
JSON_PATH = os.path.join(DATA_DIR, "card_data.json")
OUTPUT_PATH = os.path.join(DATA_DIR, "card_data_mapped.json")

# Load card data
with open(JSON_PATH, "r", encoding = "utf-8") as f:
    cards = json.load(f)

# Get all images filenames (for matching)
local_images = {f.lower(): f for f in os.listdir(IMAGE_DIR)}

# Map each card to a local image
for card in cards:
    title = card.get("title", "").replace("/", "_").replace(":", "_")
    card_image_url = card.get("cardImage", "")
    ext = os.path.splitext(card_image_url)[1] or "png.webp"
    expected_filename = f"{title}{ext}".lower()

    # Check if the images exists
    if expected_filename in local_images:
        card["localImage"] = os.path.join("images", local_images[expected_filename])
    else:
        match = next((f for f in local_images if title.lower() in f), None)
        if match:
            card["localImage"] = os.path.join("images", local_images[match])
        else:
            card["localImage"] = None

with open(OUTPUT_PATH, "w", encoding = "utf-8") as f:
    json.dump(cards, f, ensure_ascii = False, indent = 2)

print(f"Mapped {len(cards)} cards. Saved to {OUTPUT_PATH}")    