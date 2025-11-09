using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Player player1;
    Player player2;

    public string phase;
    public bool player1turn;
    public int turn_no = 1;

    public bool gameIsOngoing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameIsOngoing = true;
        player1turn = true;
        phase = "support";
    }

    // Update is called once per frame
    void Update()
    {
        CheckForLoseCondition();
        if (player1turn == true)
        {
            ExecutePlayerTurn(phase, player1);
        }
        else
        {
            ExecutePlayerTurn(phase, player2);   
        }
    }

    void CheckForLoseCondition()
    {
        if (player1.breakArea.breakLevel > 10 || player2.breakArea.breakLevel > 10)
        {
            gameIsOngoing = false;
        }
    }

    public void EndTurn()
    {
        if (player1turn == true)
            player1turn = false;
        else{
            player1turn = true;
            turn_no++;
        }
    }

    public void ExecutePlayerTurn(string phase, Player player)
    {
        switch (phase)
        {
            case "active":
                ExecuteActivePhase(phase, player);
                break;
            case "draw":
                ExecuteDrawPhase(phase, player);
                break;
            case "support":
                ExecuteSupportPhase(phase, player);
                break;
            case "main":
                ExecuteMainPhase(phase, player);
                break;
            case "end":
                ExecuteEndPhase(player);
                break;
        }
    }

    public void ExecuteActivePhase(string phase, Player player)
    {
        Debug.Log("Executing active phase");
        phase = "draw";
    }

    public void ExecuteDrawPhase(string phase, Player player)
    {
        Debug.Log("Executing draw phase");
        phase = "support";
    }

    public void ExecuteSupportPhase(string phase, Player player)
    {
        Debug.Log("Executing support phase");
        phase = "main";
    }

    public void ExecuteMainPhase(string phase, Player player)
    {
        Debug.Log("Executing main phase");
        phase = "end";
    }

    public void ExecuteEndPhase(Player player)
    {
        Debug.Log("Executing end phase");
        EndTurn();
    }
}
