using System;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    // This keeps track of the current state of the game, win or lose
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Boolean win;
    void Start()
    {
        win = false;
    }

    public void setWin(Boolean win)
    {
        this.win = win;
    }

    public Boolean getWin()
    {
        return win;
    }
}
