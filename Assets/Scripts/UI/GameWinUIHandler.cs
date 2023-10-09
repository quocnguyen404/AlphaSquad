using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWinUIHandler : EndGameUIHandler
{

    protected override void Awake()
    {
        base.Awake();
        closeBtn.onClick.AddListener(TurnOff);
    }

    private void OnEnable()
    {
        GameManager.Instance.OnWin += TurnOn;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnWin -= TurnOn;
    }
}
