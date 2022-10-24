using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMHitScript : MonoBehaviour
{
    public int SMpower;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("BadGuy"))
        { 
            Debug.Log("SM hit BG");
            Vector3 hitDirection = collision.transform.position - transform.position;
            collision.rigidbody.AddForce(hitDirection * SMpower, ForceMode.Impulse );
        }

    }

    void Update()
    {
        
    }
}