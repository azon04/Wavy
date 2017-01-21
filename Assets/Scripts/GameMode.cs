using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour {

    public enum GameState { BRIEFING, PLAYING, WIN, LOSE };

    GameState gameState = GameState.BRIEFING;

    bool win = false;
    bool lose = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if(gameState == GameState.BRIEFING && IsBriefingEnd())
        {
            ChangeState(GameState.PLAYING);
        } else if(gameState == GameState.PLAYING && IsWin())
        {
            ChangeState(GameState.WIN);
        } else if(gameState == GameState.PLAYING && IsLose())
        {
            ChangeState(GameState.LOSE);
        }
	}

    protected virtual bool IsBriefingEnd()
    {
        return false;
    }

    protected virtual void StartPlaying()
    {

    }

    protected virtual bool IsWin()
    {
        return win;
    }

    protected virtual bool IsLose()
    {
        return lose;
    }

    protected virtual void StartWin()
    {
        print("WIN");
    }

    protected virtual void StartLose()
    {

    }

    void ChangeState(GameState _gameState)
    {
        gameState = _gameState;
        if(gameState == GameState.PLAYING)
        {
            StartPlaying();
        } else if (gameState == GameState.WIN)
        {
            StartWin();
        } else if(gameState == GameState.LOSE)
        {
            StartLose();
        }
    }
}
