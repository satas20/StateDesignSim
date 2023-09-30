using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;
    
    public static event Action<GameState> OnGameStateChange;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void updateGameState(GameState newGameState)
    {
        switch (newGameState)
        {
            case GameState.ColletctorWin:
                break;
            case GameState.GuardWin:
                break;
            case GameState.OnPLay:
                break;
            case GameState.OnPause:
                break;
        }

        OnGameStateChange(newGameState);
    }
    public enum GameState 
{
    ColletctorWin,GuardWin,OnPLay,OnPause
}
}