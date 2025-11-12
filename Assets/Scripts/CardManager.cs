using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    List<CardData> cardDataList = new List<CardData>();
    List<Card> cards = new List<Card>();

    string filepath_allCards = "braverse_data/card_data_mapped.json";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadCardData();
        CreateCards();
        Debug.Log($"Created {cards.Count} cards");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LoadCardData()
    {
        string path = Path.Combine(Application.dataPath, filepath_allCards);

        if (File.Exists(path))
        {
            string jsonText = File.ReadAllText(path);
            Debug.Log("Loaded card data JSON: \n" + jsonText);
            string wrappedJson = "{ \"cards\": " + jsonText + "}";
            CardDataWrapper wrapper = JsonUtility.FromJson<CardDataWrapper>(wrappedJson);

            cardDataList = wrapper.cards;
            Debug.Log($"Imported all cards. There are a total of {cardDataList.Count} unique cards.");
        }
        else
            Debug.Log("Card list not found at " + path);
    }

    void CreateCards()
    {
        for (int i = 0; i < cardDataList.Count; i++)
        {
            if (cardDataList[i].cardType == "cookie")
            {
                CookieCard card = new CookieCard();
                card.name = cardDataList[i].title;
                card.productTitle = cardDataList[i].field_productTitle;
                card.desc = cardDataList[i].field_cardDesc;
                card.rarity = cardDataList[i].field_rare_tzsrperf;
                card.cardNo = cardDataList[i].field_cardNo_suyeowsc;
                card.fieldGrade = cardDataList[i].field_grade;
                card.cardType = cardDataList[i].cardType;
                card.energyType = cardDataList[i].energyType;
                card.imagePath = cardDataList[i].localImage;

                if (int.TryParse(cardDataList[i].cardLevelTitle, out int level))
                    card.level = level;
                else
                    card.level = -1;

                if (int.TryParse(cardDataList[i].field_hp_zbxcocvx, out int hp))
                    card.fieldHP = hp;
                else
                    card.fieldHP = 0;

                cards.Add(card);
            }
            else if (cardDataList[i].cardType == "item")
            {
                ItemCard card = new ItemCard();
                card.name = cardDataList[i].title;
                card.productTitle = cardDataList[i].field_productTitle;
                card.desc = cardDataList[i].field_cardDesc;
                card.rarity = cardDataList[i].field_rare_tzsrperf;
                card.cardNo = cardDataList[i].field_cardNo_suyeowsc;
                card.fieldGrade = cardDataList[i].field_grade;
                card.cardType = cardDataList[i].cardType;
                card.energyType = cardDataList[i].energyType;
                card.imagePath = cardDataList[i].localImage;

                cards.Add(card);
            }
            else if (cardDataList[i].cardType == "trap")
            {
                TrapCard card = new TrapCard();
                card.name = cardDataList[i].title;
                card.productTitle = cardDataList[i].field_productTitle;
                card.desc = cardDataList[i].field_cardDesc;
                card.rarity = cardDataList[i].field_rare_tzsrperf;
                card.cardNo = cardDataList[i].field_cardNo_suyeowsc;
                card.fieldGrade = cardDataList[i].field_grade;
                card.cardType = cardDataList[i].cardType;
                card.energyType = cardDataList[i].energyType;
                card.imagePath = cardDataList[i].localImage;

                cards.Add(card);
            }
            else if (cardDataList[i].cardType == "stage")
            {
                StageCard card = new StageCard();
                card.name = cardDataList[i].title;
                card.productTitle = cardDataList[i].field_productTitle;
                card.desc = cardDataList[i].field_cardDesc;
                card.rarity = cardDataList[i].field_rare_tzsrperf;
                card.cardNo = cardDataList[i].field_cardNo_suyeowsc;
                card.fieldGrade = cardDataList[i].field_grade;
                card.cardType = cardDataList[i].cardType;
                card.energyType = cardDataList[i].energyType;
                card.imagePath = cardDataList[i].localImage;

                cards.Add(card);
            }
        }
    }
}

[System.Serializable]
public class CardData

{
    public string title;
    public string field_artistTitle;
    public string field_productTitle;
    public string field_cardDesc;
    public string field_rare_tzsrperf;
    public string field_hp_zbxcocvx;
    public string field_cardNo_suyeowsc;
    public string field_grade;
    public string cardImage;
    public string productCategory;
    public string productCategoryTitle;
    public string cardType;
    public string cardTypeTitle;
    public string energyType;
    public string energyTypeTitle;
    public string cardLevel;
    public string cardLevelTitle;
    public string localImage;
}

public class CardDataWrapper
{
    public List<CardData> cards;
}