import os
import json
import requests
from time import sleep

CARD_JSON_URL = "https://cookierunbraverse.com/en/cardList/card.json"

DATA_DIR = "braverse_data"
IMAGE_DIR = os.path.join(DATA_DIR, "images")
os.makedirs(IMAGE_DIR, exist_ok = True)

# Fetch JSON data
print("Fetching card data...")
response = requests.get(CARD_JSON_URL)
response.raise_for_status()
cards = response.json()

print(f"Retrieved {len(cards)} cards.")

# Step 2: Save the full JSON locally
json_path = os.path.join(DATA_DIR, "card_data.json")
with open(json_path, "w", encoding = "utf-8") as f:
    json.dump(cards, f, ensure_ascii = False, indent = 2)
print(f"Saved JSON data to {json_path}")

# Step 3: Download card images
# Load local JSON

with open(json_path, "r", encoding = "utf-8") as f:
    cards = json.load(f)

for i, card in enumerate(cards, start = 1):
    # Extract relevant fields
    name = card.get("title", f"card_{i}").replace("/", "_").replace(":", "_")
    image_url = card.get("cardImage")

    if not image_url:
        print(f"No image found for {name}")
        continue

    # Extract file extension
    ext = os.path.splitext(image_url)[1]
    if not ext:
        ext = ".png"
    save_path = os.path.join(IMAGE_DIR, f"{name}{ext}")

    if os.path.exists(save_path):
        print(f"[{i}/{len(cards)}] Skipping (already exists): {name}")
        continue

    # Download the image
    try:
        response = requests.get(image_url, timeout = 10)
        response.raise_for_status()
        with open(save_path, "wb") as img_file:
            img_file.write(response.content)
        print(f"[{i}/{len(cards)}] Saved: {name}")
        sleep(0.5)
    except Exception as e:
        print(f"[{i}/{len(cards)}] Failed: {name} ({e})")