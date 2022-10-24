using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCivil : MonoBehaviour
{
    [SerializeField] private GameObject Center;
    [SerializeField] private int maxTimerCiv;

    System.Random randomCivil = new System.Random();
    int x, y, z;
    private float moveTimerCiv;

    private void MovePerson()
    {
        x = randomCivil.Next(-10, 10);
        y = 0;
        z = randomCivil.Next(-10, 10);

        GetComponent<Rigidbody>().AddForce(x, y, z, ForceMode.Impulse);
    }

    private void UpdateMoveTimer()
    {
        MovePerson();
        moveTimerCiv = randomCivil.Next(1, maxTimerCiv);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    void Update()
    {
        moveTimerCiv -= Time.deltaTime;
        if (moveTimerCiv <= 0)
        {
            UpdateMoveTimer();
        }

        transform.position = Vector3.MoveTowards(transform.position, Center.transform.position, 0.02f);
    }
}