using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class UIHandler : MonoBehaviour
{
    protected CanvasGroup cv = null;
    protected RectTransform popRect = null;
    protected float popTime = 0.7f;

    protected void Awake()
    {
        cv = GetComponent<CanvasGroup>();
    }

    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void TurnOn()
    {
        gameObject.SetActive(true);
        popRect.DOScale(Vector3.one, popTime).SetAutoKill();
    }


    public void TurnOff() 
    {
        popRect.DOScale(Vector3.one, popTime)
            .OnComplete(() =>
            {
                gameObject.SetActive(false);
            })
            .SetAutoKill();

    }
}
