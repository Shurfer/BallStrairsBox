
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Scriptable/GameSettings", order = 1)]


public class GameSettings : ScriptableObject
{
    public Vector2  timeToSpawnEnemy; 
    public Vector2  wichEnemyDestroy; 
}
