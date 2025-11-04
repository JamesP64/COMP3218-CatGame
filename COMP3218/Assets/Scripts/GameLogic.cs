using System;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    // This ONLY keeps track of the current state of the game, win or lose
    // The actual win logic is attached to the exit
    // The actual lost logic is attached to the cat
    Boolean win;
    void Start()
    {
        Debug.Log("Win condition: " + win);
        win = false;
    }
    public void setWin(Boolean win)
    {
        Debug.Log("Win condition set to: " + win);
        this.win = win;
    }

    public Boolean getWin()
    {
        return win;
    }
}
