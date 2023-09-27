using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1000)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public List<EnemyBrain> enemies = null;
    public List<WayPoint> enemiesWaypoint = null;
    public HeroBrain player = null;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
