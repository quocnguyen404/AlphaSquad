using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[DefaultExecutionOrder(-1000)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    [SerializeField] private SpawnLevelHandler spawnLevelHandler = null;


    [SerializeField] private Joystick joystick = null;

    public LevelSO levelData = null;
    private UserData userData = new UserData();
    public UserData UserData => userData;
    public int levelIndex => UserData.currentLevel;

    public List<EnemyBrain> enemies = null;
    //public List<WayPoint> enemiesWaypoint = null;
    public HeroBrain player = null;

    public System.Action OnPlayerDie = null;
    public System.Action OnEnemyDie = null;
    public System.Action OnWin = null;
    public System.Action OnLose = null;

    #region Singleton
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        levelData = Resources.Load<LevelSO>(string.Format("LevelSO/Level {0}", levelIndex));

        spawnLevelHandler.Init();
        spawnLevelHandler.SpawnPlayer(joystick);
        spawnLevelHandler.SpawnEnemyAndWayPoint();
    }
    #endregion

    private void OnEnable()
    {
        OnEnemyDie += EnemyDie;
        OnPlayerDie += PlayerDie;
    }

    private void OnDisable()
    {
        OnEnemyDie -= EnemyDie;
        OnPlayerDie -= PlayerDie;
    }

    private void PlayerDie()
    {
        OnLose?.Invoke();
    }

    private void EnemyDie()
    {
        if (!enemies.Any(e => e.ALive == true))
        {
            OnWin?.Invoke();
        }
    }
}
