using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Canvas cv = null;


    private void Awake()
    {
        cv = GetComponent<Canvas>();
    }

}
