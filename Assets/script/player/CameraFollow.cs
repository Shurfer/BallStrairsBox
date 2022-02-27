using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] Transform playerTr;
    [SerializeField] float speed;

    private Vector3 position;
    void FixedUpdate()
    {
        if(playerTr!=null)
        {
            position = Vector3.Lerp(transform.position, playerTr.position - new Vector3(-5, -5, 5),
                Time.fixedDeltaTime * speed);
            transform.position = position;
        }
    }
}
