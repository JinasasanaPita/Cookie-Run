using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Area
{
    public string areaName;
    public string areaDescription;
    public List<Card> cards;
}

public class BreakArea : Area
{

}

public class BattleArea : Area
{
    
}

public class SupportArea : Area
{
    
}

public class StageArea : Area
{
    
}

public class Trash : Area
{
    
}
