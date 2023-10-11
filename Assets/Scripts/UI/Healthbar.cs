using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Canvas cv = null;
    [SerializeField] private Camera cam = null;
    [SerializeField] private Image healthBarImage = null;

    private float maxHealth;


    private void Awake()
    {
        cv = GetComponent<Canvas>();
        cam = Camera.main;
        cv.worldCamera = cam;
    }

    private void Update()
    {
        cv.transform.rotation = Quaternion.identity;
        cv.transform.forward = cam.transform.forward;
    }



    public void InitHealthbar(float maxHealth)
    {
        this.maxHealth = maxHealth;
        healthBarImage.fillAmount = 1f;
    }

    public void HealthbarOnChangeValue(float currentHealth)
    {
        float currentAmount = currentHealth / maxHealth;
        healthBarImage.DOFillAmount(currentAmount, 0.5f).SetAutoKill();
    }
}
