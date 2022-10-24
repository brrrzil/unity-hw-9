using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    //[SerializeField] private GameObject Center;
    [SerializeField] private int maxTimer, SpeedSM, SpeedBG, SpeedCiv, powerSM, powerBG, powerCiv;
    bool moveSM = false, moveBG = false, moveCiv = false;

    //private GameObject center;

    System.Random random = new System.Random();
    int x, y, z;
    private float moveTimer;

    private void MovePerson()
    {
        int speed = 0;
        string whomove = WhoMoves();

        if (whomove == "moveSM") { SpeedBG = 0; SpeedCiv = 0; }
        else if (whomove == "moveBG") { SpeedSM = 0; SpeedCiv = 0; }
        else if (whomove == "moveCiv") { SpeedSM = 0; SpeedBG = 0; }

        switch (gameObject.name)
        {
            case "Superman": speed = SpeedSM; break;
            case "BadGuy": speed = SpeedBG; break;
            case "Civil": speed = SpeedCiv; break;
        }

        if (!moveSM) { } 

        x = random.Next(-5, 5) * speed;
        y = 0;
        z = random.Next(-5, 5) * speed;

        GetComponent<Rigidbody>().AddForce(x, y, z, ForceMode.Impulse);
    }

    private void UpdateMoveTimer()
    {
        MovePerson();
        moveTimer = random.Next(1, maxTimer);
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

    private string WhoMoves()
    {
        if (!moveSM)
        {
            moveSM = true; moveBG = false; moveCiv = false; return "moveSM";
        }
        else if (!moveBG)
        {
            moveBG = true; moveSM = false; moveCiv = false; return "moveBG";
        }
        else if(!moveCiv)
        {
            moveCiv = true; moveSM = false; moveBG = false; return "moveCiv";
        }
        else
        {
            moveSM = false; moveBG = false; moveCiv = false; return "moveSM";
        }
    }

    private void Start()
    {

    }

    void Update()
    {
        moveTimer -= Time.deltaTime;
        if (moveTimer <= 0)
        {
            UpdateMoveTimer();
        }

        Debug.Log(WhoMoves());
        //transform.position = Vector3.MoveTowards(transform.position, center.transform.position, 0.03f);
    }
} 