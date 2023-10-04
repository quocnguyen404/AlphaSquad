using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoseUIHandler : EndGameUIHandler
{
    private void OnEnable()
    {
        GameManager.Instance.OnLose += TurnOn;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnLose -= TurnOn;
    }
}
