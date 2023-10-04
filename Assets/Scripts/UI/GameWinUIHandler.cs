using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinUIHandler : EndGameUIHandler
{
    private void OnEnable()
    {
        GameManager.Instance.OnWin += TurnOn;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnWin -= TurnOn;
    }
}
