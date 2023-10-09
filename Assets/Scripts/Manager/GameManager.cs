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

    public int MaxLevel = 3;

    private LevelSO levelData = null;
    public LevelSO LevelData
    {
        get
        {
            if (levelData == null)
            {
                int index = GameConfig.UserData.currentLevel;
                if (index > MaxLevel)
                {
                    index = 1;
                }

                Debug.Log("Load level " + index);
                levelData = Resources.Load<LevelSO>(string.Format("LevelSO/Level {0}", index));
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
            LevelUp();
        }
    }

    private void LevelUp()
    {
        UserData newData = (UserData)GameConfig.UserData.Clone();

        if (newData.currentLevel > MaxLevel)
            newData.currentLevel = 1;
        else
            newData.currentLevel++;

        GameConfig.UserData = newData;
        Debug.Log(GameConfig.UserData.currentLevel);
    }

}
