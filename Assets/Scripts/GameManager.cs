using System;
using UnityEngine;

public enum Phase
{
    START,
    ACTIVE,
    DRAW,
    SUPPORT,
    MAIN,
    END
}

public class GameManager : MonoBehaviour
{
    public Player player1;
    public Player player2;

    public Phase phase;
    public bool player1turn;
    public int turn_no = 1;

    public bool gameIsOngoing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameIsOngoing = true;
        player1turn = true;
        phase = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StartGame();
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

    public void StartGame()
    {
        // Rock paper scissors stone to decide who goes first
        phase = Phase.ACTIVE;
    }

    public void ExecutePlayerTurn(Phase phase, Player player)
    {
        switch (phase)
        {
            case Phase.START:
                ExecuteActivePhase(phase, player);
                break;
            case Phase.DRAW:
                ExecuteDrawPhase(phase, player);
                break;
            case Phase.SUPPORT:
                ExecuteSupportPhase(phase, player);
                break;
            case Phase.MAIN:
                ExecuteMainPhase(phase, player);
                break;
            case Phase.END:
                ExecuteEndPhase(phase, player);
                break;
        }
    }

    public void ExecuteActivePhase(Phase phase, Player player)
    {
        Debug.Log("Executing active phase");
        phase = Phase.DRAW;
    }

    public void ExecuteDrawPhase(Phase phase, Player player)
    {
        Debug.Log("Executing draw phase");
        phase = Phase.SUPPORT;
    }

    public void ExecuteSupportPhase(Phase phase, Player player)
    {
        Debug.Log("Executing support phase");
        phase = Phase.MAIN;
    }

    public void ExecuteMainPhase(Phase phase, Player player)
    {
        Debug.Log("Executing main phase");
        phase = Phase.END;
    }

    public void ExecuteEndPhase(Phase phase, Player player)
    {
        Debug.Log("Executing end phase");
        EndTurn(phase);
    }

    public void EndTurn(Phase phase)
    {
        if (player1turn == true)
            player1turn = false;
        else
        {
            player1turn = true;
            turn_no++;
        }
        phase = Phase.ACTIVE;
    }
    
    void CheckForLoseCondition()
    {
        if (player1.breakArea.breakLevel > 10 || player2.breakArea.breakLevel > 10)
        {
            gameIsOngoing = false;
        }
    }
}