using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings;
    [SerializeField] private GameObject enemyBoxPrefab;
    [SerializeField] private GameObject enemySpikePrefab;
    [SerializeField] private Stairs stairsSc;

    private Vector3 staiUpPos;
    
    void Start()
    {
        EnemyGenerate();
    }

    void EnemyGenerate()
    {
        staiUpPos = stairsSc.stairsTr[stairsSc.stairsTr.Length - 1].position;
        int random = Random.Range(-5, 5);
      GameObject prefab =  Instantiate(enemyBoxPrefab, staiUpPos + new Vector3(random, .5f, 0),transform.rotation);
      prefab.transform.SetParent(transform);
      
      random = Random.Range(0, 3);
      if (random == 1)
      {
          random = Random.Range(-5, 5);
          prefab =  Instantiate(enemySpikePrefab, staiUpPos + new Vector3(random, .5f, 0),transform.rotation);
          prefab.transform.SetParent(transform);
      }
      
        StartCoroutine(nextEnemy());
    }


    IEnumerator nextEnemy()
    {
        float time = Random.Range(gameSettings.timeToSpawnEnemy.x, gameSettings.timeToSpawnEnemy.y);
        yield return new WaitForSeconds(time);
        EnemyGenerate();
    }
}
