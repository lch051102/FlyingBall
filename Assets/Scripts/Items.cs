using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public float rotatespeed;

    void Update()
    {
        transform.Rotate(Vector3.up * rotatespeed * Time.deltaTime, Space.World);    
    }
}
