using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text gameTracker;
    public GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameStateDisplay();
    }

    void UpdateGameStateDisplay()
    {
        gameTracker.text = "Current player's turn: " + GetPlayerTurn()
            + "\nCurrent phase: " + gameManager.phase
            + "\nTurn number: " + gameManager.turn_no;
    }

    string GetPlayerTurn()
    {
        if (gameManager.player1turn == true)
            return "Player 1";
        else
            return "Player 2";
    }
}
