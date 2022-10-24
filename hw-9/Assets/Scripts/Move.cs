using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private GameObject CenterPoint;

    int x, y, z;
    float timer = 1;
    string nameX = "Superman";
    System.Random r = new System.Random();

    private void MovePerson(int x, int y, int z, string nameX)
    {
        Rigidbody[] rb = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody e in rb)
        {
            if (e.name.Contains(nameX) && timer <= 0)
            {
                e.AddForce(x, y, z, ForceMode.Impulse);
            }
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        x = r.Next(-10, 11);
        y = 0;
        z = r.Next(-10, 11);
        nameX = "Superman";
        MovePerson(x, y, z, nameX);
        x = r.Next(-10, 11);
        y = 0;
        z = r.Next(-10, 11);
        nameX = "BadGuy";
        MovePerson(x, y, z, nameX);
        x = r.Next(-10, 11);
        y = 0;
        z = r.Next(-10, 11);
        nameX = "Civil";
        MovePerson(x, y, z, nameX);

        if (timer < 0) timer = 1;

        Rigidbody[] rb2 = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody r in rb2)
        {
            if (!r.name.Contains("Border") && !r.name.Contains("Ground"))
            {
                r.transform.position = Vector3.MoveTowards(r.transform.position, CenterPoint.transform.position, 0.03f);
            }
        }
    }
}