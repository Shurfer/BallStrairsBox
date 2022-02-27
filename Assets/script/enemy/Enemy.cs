using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;
    [SerializeField]  bool box;
    
    float force=2;
    
    void Start()
    {
        if(box)
        {
            rigidbody.velocity = Vector3.up * force;
            StartCoroutine(nexVelocity());
        }
    }
    
   IEnumerator nexVelocity()
    {
        yield return new WaitForSeconds(.3f);
        rigidbody.velocity = Vector3.back * force*2;
        yield return new WaitForSeconds(1);
        StartCoroutine(nexVelocity());
    }


   private void OnTriggerEnter(Collider other)
   {
       if(other.gameObject.GetComponent<Ball>())
           other.gameObject.GetComponent<Ball>().HitPlayer();
   }
}
