using NUnit.Framework;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

public class DeckManager : MonoBehaviour
{
    public Deck redDeck;
    public Deck yellowDeck;
    DeckData deck = new DeckData();
    

    string filepath_redDeck = "braverse_data/red_deck.json";
    string filepath_yellowDeck = "braverse_data/yellow_deck.json";


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        BuildDeck(filepath_redDeck);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void BuildDeck(string deckPath)
    {
        string path = Path.Combine(Application.dataPath, deckPath);

        if (File.Exists(path))
        {
            string jsonText = File.ReadAllText(path);
            Debug.Log("Loaded deck JSON: \n" + jsonText);

            deck = JsonUtility.FromJson<DeckData>(jsonText);
            Debug.Log($"Loaded deck: {deck.deckName} with {deck.cards.Count} unique cards.");
        }
        else
            Debug.LogError("Deck file not found at " + path);

    }
}

[System.Serializable]
public class CardQtyMap
{
    public string cardNo;
    public int quantity;
}

[System.Serializable]
public class DeckData

{
    public string deckName;
    public string deckID;
    public int totalCards;
    public List<CardQtyMap> cards;
}