using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBoomScript : MonoBehaviour
{
    public float boomTime;
    public float power;
    public float radius;

    public void Boom()
    {
        Rigidbody[] fragments = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody r in fragments)
        {
            if(Vector3.Distance(transform.position, r.transform.position) < radius)
            {
                Vector3 direction = r.transform.position - transform.position;
                r.AddForce(direction.normalized * power * (radius - Vector3.Distance(transform.position, r.transform.position)), ForceMode.Impulse);
            }
        }

        boomTime = 3;
    }

    private void Update()
    {
        boomTime -= Time.deltaTime;

        if (boomTime <= 0) Boom();        
    }
}