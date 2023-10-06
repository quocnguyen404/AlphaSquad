using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Level", fileName = "LevelData")]
public class LevelSO : ScriptableObject
{
    public int level;
    public int enemyAmount = 0;
    public Vector3 playerInitPos = Vector3.zero;
    public List<WayPoint> wayPoints = new List<WayPoint>();
}
