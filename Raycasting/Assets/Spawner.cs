using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Ray;
    private void Start()
    {
        for (int i = 0; i < 1; i++)
            Instantiate(Ray,Vector3.zero, Quaternion.identity);
       
    }
}
