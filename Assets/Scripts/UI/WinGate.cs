using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WinGate : MonoBehaviour
{
    [SerializeField] private Vector3 winGatePos;
    [SerializeField] private float appearTime = 0.5f;

    private void OnEnable()
    {
        GameManager.Instance.OnWin += GateAppear;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnWin -= GateAppear;
    }

    private void GateAppear()
    {
        transform.DOMove(winGatePos, appearTime).SetAutoKill();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Load to next level");
    }


}
