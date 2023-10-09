using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevelHandler : MonoBehaviour
{
    //spawn prefab player
    //spawn prefab enemies
    //spawn waypoint
    
    public void Init()
    {

    }

    public void SpawnPlayer(Joystick joystick)
    {
        HeroBrain player = Resources.Load<GameObject>("Prefabs/Player/Player").GetComponent<HeroBrain>();
        player.joyStick = joystick;
        GameManager.Instance.player = Instantiate(player, GameManager.Instance.LevelData.playerInitPos, Quaternion.identity);
    }
    
    public void SpawnEnemyAndWayPoint()
    {

        foreach (WayPoint wp in GameManager.Instance.LevelData.wayPoints)
        {
            EnemyBrain enemyPrefab = Resources.Load<GameObject>(string.Format("Prefabs/Enemies/{0}", wp.targetEnemy)).GetComponent<EnemyBrain>();
            EnemyBrain enemy = Instantiate(enemyPrefab, wp.points[0], Quaternion.identity);
            enemy.wayPoints.AddRange(wp.points);
            GameManager.Instance.enemies.Add(enemy);
        }
    }
}
