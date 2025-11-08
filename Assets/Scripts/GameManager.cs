using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Player player1;
    Player player2;

    public string phase;
    public bool player1turn;
    public int turn_no;

    public bool gameIsOngoing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameIsOngoing = true;

        if (player1turn == true)
        {
            Debug.Log("Player 1's turn");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CheckForLoseCondition()
    {
        if (player1.breakArea.breakLevel > 10 || player2.breakArea.breakLevel > 10)
        {
            gameIsOngoing = false;
        }
    }

    void EndTurn()
    {
        if (player1turn == true)
            player1turn = false;
        else{
            player1turn = true;
            turn_no++;
        }
    }
}
