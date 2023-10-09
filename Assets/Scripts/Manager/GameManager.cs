using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;

[DefaultExecutionOrder(-1000)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [SerializeField] private SpawnLevelHandler spawnLevelHandler = null;
    [SerializeField] private Joystick joystick = null;

    private LevelSO levelData = null;
    public LevelSO LevelData
    {
        get
        {
            if (levelData == null)
            {
                levelData = Resources.Load<LevelSO>(string.Format("LevelSO/Level {0}", UserData.currentLevel));
            }

            return levelData;
        }
    }

    public List<EnemyBrain> enemies = null;
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
    }
    #endregion


    private UserData _userData = null;

    public UserData UserData
    {
        get 
        {
            if (_userData == null)
            {
                _userData = GameConfig.LoadUserData();
            }

            return _userData; 
        }

        set
        {
            _userData = value;
            GameConfig.SaveUserData(_userData);
        }
    }

    private void OnEnable()
    {
        OnEnemyDie += EnemyDie;
        OnPlayerDie += PlayerDie;

        spawnLevelHandler.Init();
        spawnLevelHandler.SpawnPlayer(joystick);
        spawnLevelHandler.SpawnEnemyAndWayPoint();
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
