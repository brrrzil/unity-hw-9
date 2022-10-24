using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstShotScript : MonoBehaviour
{
    float time = 1;
    public int power;
    public float LeftRight;
    private void Shot()
    {
        GetComponent<Rigidbody>().AddForce(-LeftRight, 0, -power, ForceMode.Impulse);
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            Shot();
            time = 5;
        }
    }
}
