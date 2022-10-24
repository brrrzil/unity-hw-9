using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float timer;
    public float power;
    public float radius;

    public void Boom()
    {
        Rigidbody[] fragments = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody B in fragments)
        {
            if(Vector3.Distance(transform.position, B.transform.position) < radius)
            {
                Vector3 direction = B.transform.position - transform.position;
                B.AddForce(direction.normalized * power * (radius - Vector3.Distance(transform.position, B.transform.position)), ForceMode.Impulse);
            }
        }

        timer = 10;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0) Boom();
    }
}