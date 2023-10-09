using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class UIHandler : MonoBehaviour
{
    [SerializeField] protected RectTransform popRect = null;
    protected CanvasGroup cv = null;
    protected float popTime = 0.7f;

    protected virtual void Awake()
    {
        cv = GetComponent<CanvasGroup>();
    }

    public void Start()
    {
        //gameObject.SetActive(false);
        CanvasOff();
    }

    public void TurnOn()
    {
        CanvasOn();
        cv.alpha = 1f;
        popRect.DOScale(Vector3.one, popTime).SetAutoKill();
    }


    public void TurnOff()
    {
        popRect.DOScale(Vector3.one, popTime)
            .OnComplete(() =>
            {
                CanvasOff();
            })
            .SetAutoKill();

    }

    public void CanvasOff()
    {
        cv.alpha = 0f;
        cv.interactable = false;
        cv.blocksRaycasts = false;
    }

    public void CanvasOn()
    {
        cv.alpha = 1f;
        cv.interactable = true;
        cv.blocksRaycasts = true;
    }
}
