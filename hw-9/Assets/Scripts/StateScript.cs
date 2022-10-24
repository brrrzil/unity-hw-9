using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateScript : MonoBehaviour
{
    [SerializeField] GameObject task1, task2, task3;

   public void Button1()
    {
        task1.SetActive(true);
        task2.SetActive(false);
        task3.SetActive(false);
    }
    
    public void Button2()
    {
        task1.SetActive(false);
        task2.SetActive(true);
        task3.SetActive(false);
    }
    
    public void Button3()
    {
        task1.SetActive(false);
        task2.SetActive(false);
        task3.SetActive(true);
    }
}
