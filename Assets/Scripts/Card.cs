using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public string name;
    public string productTitle;
    public string desc;
    public string rarity;
    public string cardNo;
    public string fieldGrade;
    public string cardType;
    public string energyType;
    public string imagePath;
}

public class CookieCard : Card
{
    public int level;
    public int fieldHP;
    public List<Card> hpCards;
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