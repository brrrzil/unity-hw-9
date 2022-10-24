using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravityScript : MonoBehaviour
{
    //[SerializeField] private Material mat1, mat2, mat3, mat4;
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().useGravity = false;
        other.GetComponent<Renderer>().material.color = Color.cyan;
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<Rigidbody>().useGravity = true;        
        other.GetComponent<Renderer>().material.color = Color.white;
    }
}
