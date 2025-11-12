using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Deck deck = new Deck();
    public Hand hand = new Hand();

    public BreakArea breakArea = new BreakArea();
    public BattleArea battleArea = new BattleArea();
    public SupportArea supportArea = new SupportArea();
    public StageArea stageArea = new StageArea();
    public Trash trash = new Trash();

    public void Draw()
    {
        
    }
}
