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
        if (phase == Phase.START)
            StartGame();
        CheckForLoseCondition();
        if (player1turn == true)
        {
            ExecutePlayerTurn(ref phase, player1);
        }
        else
        {
            ExecutePlayerTurn(ref phase, player2);
        }
    }

    public void StartGame()
    {
        // TODO: Each player draw 6

        // TOOD: Check for mulligan
        // TODO: (Low prio) Rock paper scissors stone to decide who goes first
        phase = Phase.ACTIVE;
    }

    public void ExecutePlayerTurn(ref Phase phase, Player player)
    {
        switch (phase)
        {
            case Phase.ACTIVE:
                ExecuteActivePhase(player);
                break;
            case Phase.DRAW:
                ExecuteDrawPhase(player);
                break;
            case Phase.SUPPORT:
                ExecuteSupportPhase(player);
                break;
            case Phase.MAIN:
                ExecuteMainPhase(player);
                break;
            case Phase.END:
                ExecuteEndPhase(player);
                break;
        }
    }

    public void ExecuteActivePhase(Player player)
    {
        
    }

    public void ExecuteDrawPhase(Player player)
    {
        
    }

    public void ExecuteSupportPhase(Player player)
    {
        
    }

    public void ExecuteMainPhase(Player player)
    {
        
    }

    public void ExecuteEndPhase(Player player)
    {
        
    }

    public void EndTurn()
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
    
    public void EndPhase()
    {
        if (phase == Phase.ACTIVE)
            phase = Phase.DRAW;
        else if (phase == Phase.DRAW)
            phase = Phase.SUPPORT;
        else if (phase == Phase.SUPPORT)
            phase = Phase.MAIN;
        else if (phase == Phase.MAIN)
            phase = Phase.END;
        else if (phase == Phase.END)
            EndTurn();
    }

    void CheckForLoseCondition()
    {
        if (player1.breakArea.breakLevel > 10 || player2.breakArea.breakLevel > 10)
        {
            gameIsOngoing = false;
        }
    }
}