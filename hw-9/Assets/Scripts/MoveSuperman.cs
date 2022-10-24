using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSuperman : MonoBehaviour
{
    [SerializeField] private GameObject Center;
    [SerializeField] private int maxTimerSM;

    System.Random randomSM = new System.Random();
    int x, y, z;
    private float moveTimerSM;

    private void MovePerson()
    {
        x = randomSM.Next(-30, 30);
        y = 0;
        z = randomSM.Next(-30, 30);

        GetComponent<Rigidbody>().AddForce(x, y, z, ForceMode.Impulse);
    }

    private void UpdateMoveTimer()
    {
        MovePerson();
        moveTimerSM = randomSM.Next(1, maxTimerSM);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Ground")
        {
            //collision.gameObject.transform.position = collision.gameObject.GetComponent<Rigidbody>().AddForce(0, 50, 0, ForceMode.Impulse);
            //collision.gameObject.transform.position = - Vector3.MoveTowards(transform.position, collision.gameObject.transform.position, 1f);
        }
    }

    void Update()
    {
        moveTimerSM -= Time.deltaTime;
        if (moveTimerSM <= 0)
        {
            UpdateMoveTimer();
        }

        transform.position = Vector3.MoveTowards(transform.position, Center.transform.position, 0.04f);
    }
}