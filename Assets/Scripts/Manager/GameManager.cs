using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[DefaultExecutionOrder(-1000)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public List<EnemyBrain> enemies = null;
    public List<WayPoint> enemiesWaypoint = null;
    public HeroBrain player = null;

    public System.Action OnEnemyDie;
    public System.Action OnWin;
    public System.Action OnLose;

    #region Singleton
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    #endregion

    private void OnEnable()
    {
        OnEnemyDie += EnemyDie;
    }

    private void OnDisable()
    {
        OnEnemyDie -= EnemyDie;
    }

    private void EnemyDie()
    {
        if (!enemies.Any(e => e.ALive == true))
        {
            OnWin?.Invoke();
        }
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
