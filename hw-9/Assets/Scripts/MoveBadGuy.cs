using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBadGuy : MonoBehaviour
{
    [SerializeField] private GameObject Center;
    [SerializeField] private int maxTimerBG, SpeedSM, SpeedBG, SpeedCiv, powerSM, powerBG, powerCiv;

    System.Random randomBG = new System.Random();
    int x, y, z, speed;
    private float moveTimerBG;

    private void MovePerson()
    {
        switch (gameObject.name)
        {
            case "Superman": speed = SpeedSM; break;
            case "BadGuy": speed = SpeedBG; break;
            case "Civil": speed = SpeedCiv; break;
        }

        x = randomBG.Next(-20, 20) * speed;
        y = 0;
        z = randomBG.Next(-20, 20) * speed;

        GetComponent<Rigidbody>().AddForce(x, y, z, ForceMode.Impulse);
    }

    private void UpdateMoveTimer()
    {
        MovePerson();
        moveTimerBG = randomBG.Next(1, maxTimerBG);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Ground")
        {
            //collision.gameObject.transform.position = collision.gameObject.GetComponent<Rigidbody>().AddForce(0, 5, 0);
            //collision.gameObject.transform.position = -Vector3.MoveTowards(transform.position, collision.gameObject.transform.position, 0.0001f);
        }
    }

    void Update()
    {
        moveTimerBG -= Time.deltaTime;
        if (moveTimerBG <= 0)
        {
            UpdateMoveTimer();
        }

        transform.position = Vector3.MoveTowards(transform.position, Center.transform.position, 0.03f);
    }
}