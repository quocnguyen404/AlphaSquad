using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinUIHandler : EndGameUIHandler
{
    private void OnEnable()
    {
        GameManager.Instance.OnWin += TurnOn;
    }

    private void nDisable()
    {
        GameManager.Instance.OnWin -= TurnOn;
    }
}
