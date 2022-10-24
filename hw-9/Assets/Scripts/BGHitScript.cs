using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGHitScript : MonoBehaviour
{
    public int BGpower;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Civil") || collision.gameObject.name.Contains("Superman"))
        {
            Debug.Log("SM hit BG");
            Vector3 hitDirection = collision.transform.position - transform.position;
            collision.rigidbody.AddForce(hitDirection * BGpower, ForceMode.Impulse);
        }

    }
}