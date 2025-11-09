import os
import json
import requests
from bs4 import BeautifulSoup

DATA_DIR = "braverse_data"
CARD_JSON = os.path.join(DATA_DIR, "card_data.json")

BASE_URL = "https://cookierun.gg/cookierun-braverse-{color}-starter-deck-list-and-review/"

def load_all_cards(path):
    with open(path, "r", encoding = "utf-8") as f:
        cards = json.load(f)
    return {c.get("field_cardNo_suyeowsc"): c for c in cards}

def scrape_deck(color, expected_prefix, card_lookup):
    """Scrape a given deck by color, e.g. 'red' or 'yellow'."""
    url = BASE_URL.format(color = color)
    print(f"\nScraping {color.capitalize()} deck from {url}")
    response = requests.get(url)
    response.raise_for_status()
    soup = BeautifulSoup(response.text, "html.parser")

    deck_spec = []
    for row in soup.select("table tr"):
        cols = row.find_all("td")
        if len(cols) < 2:
            continue
        card_no = cols[0].get_text(strip = True)
        qty = None
        for maybe in cols:
            text = maybe.get_text(strip = True)
            if text.isdigit():
                qty = int(text)
                break
        if card_no.startswith(expected_prefix) and qty is not None:
            deck_spec.append((card_no, qty))

    # Build JSON structure
    total = sum(q for _, q in deck_spec)
    deck_json = {
        "deckName": f"Starter Deck {color.capitalize()}",
        "deckID": expected_prefix.replace("-", ""),
        "totalCards": total,
        "cards": [{"cardNo": c, "quantity": q} for c, q in deck_spec]
    }

    # Validate against card database
    missing = [c for c, _ in deck_spec if c not in card_lookup]
    if missing:
        print(f"Missing {len(missing)} cards for {color} deck: {missing}")
    
    output_path = os.path.join(DATA_DIR, f"{color}_deck.json")
    with open(output_path, "w", encoding = "utf-8") as f:
        json.dump(deck_json, f, ensure_ascii = False, indent = 2)
    print(f"Saved {color.capitalize()} deck JSON to {output_path}")

def main():
    card_lookup = load_all_cards(CARD_JSON)
    print(f"Loaded {len(card_lookup)} cards from master dataset")

    for color, prefix in [("red", "ST1-"), ("yellow", "ST2-")]:
        scrape_deck(color, prefix, card_lookup)

    print("\nAll decks processed. Review any warnings for missing data")

if __name__ == "__main__":
    main()