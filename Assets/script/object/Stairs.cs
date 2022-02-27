using System.Collections;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public Transform[] stairsTr;

    private Transform oldStairTr;

    private void Awake()
    {
        EventManager.OnTapScreen.AddListener(StairUp);
    }
    
    IEnumerator nextEnemy()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < stairsTr.Length - 1; i++)
        {
            oldStairTr = stairsTr[i];
            stairsTr[i] = stairsTr[i + 1];
            stairsTr[i + 1] = oldStairTr;
        }

        stairsTr[stairsTr.Length - 1].position = stairsTr[stairsTr.Length - 2].position + new Vector3(0, 1, 1);
    }

    public void StairUp()
    {
        StartCoroutine(nextEnemy());
    }
}