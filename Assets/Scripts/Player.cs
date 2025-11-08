using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class Player
{
    public Deck deck = new Deck();
    public Area breakArea = new Area();

    public string GetBreakAreaName()
    {
        return breakArea.areaName;
    }
}
