using System.Collections.Generic;
using UnityEngine;

public class Card
{
    string name;
    string cost;
    bool hasFlip;
}

public class CookieCard : Card
{
    int level;
    int hp;
    List<Card> hpCards;
}

public class ItemCard : Card
{
    
}

public class TrapCard : Card
{

}

public class StageCard : Card
{
    
}