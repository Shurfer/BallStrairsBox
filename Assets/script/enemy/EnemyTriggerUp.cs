using System.Collections;
using UnityEngine;

public class EnemyTriggerUp : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings;
    [SerializeField] private Stairs stairsSc;

    private int random;

    private void OnTriggerEnter(Collider other)
    {
        random = (int) Random.Range(gameSettings.wichEnemyDestroy.x, gameSettings.wichEnemyDestroy.y);
        if (random == 1)
            Destroy(other.gameObject);
        else
        {
            TrailRenderer trail = other.gameObject.GetComponent<TrailRenderer>();
            trail.time = 0;
            Vector3 staiUpPos = stairsSc.stairsTr[stairsSc.stairsTr.Length - 1].position;
            random = Random.Range(-5, 5);
            other.transform.position = staiUpPos + new Vector3(random, .5f, 0);
            StartCoroutine(nexVelocity(trail));
        }
    }

    IEnumerator nexVelocity(TrailRenderer trail)
    {
        yield return new WaitForSeconds(0.3f);
        trail.time = 1;
    }
}