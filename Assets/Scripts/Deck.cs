using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class Deck
{
    List<Card> deck;
    int max_size = 60;
    Dictionary<string, int> cardQty = new Dictionary<string, int>();

    Card Pop()
    {
        Card poppedCard = deck[deck.Count - 1];
        deck.RemoveAt(deck.Count - 1);
        return poppedCard;
    }

    List<Card> Pop(int n)
    {
        List<Card> poppedCards = new List<Card>();
        for (int i = 0; i < n; i++)
        {
            if (deck.Count == 0)
            {
                if (poppedCards.Count == 0)
                {
                    Debug.Log("Deck is empty, no cards to pop. Returning null");
                    return null;
                }
                else
                    return poppedCards;
            }
            Card poppedCard = Pop();
            poppedCards.Add(poppedCard);            
        }

        return poppedCards;
    }

    void CheckMaxSize()
    {
        if (deck.Count > max_size)
            Debug.Log("There are more cards in this deck then the maximum allowed deck size");
    }
}
