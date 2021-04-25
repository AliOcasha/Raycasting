using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{
    public GameObject RayPrefab;
    public LineRenderer Boundary;

    public LineRenderer[] Objects;
    public int maxRayCount = 1000;

    private LineRenderer Ray;
    private GameObject[] Rays;

    private Vector3 Offset = Vector3.zero;
    private Vector3 B_Offset;
    private float Radius = 0.1f;
    private void Start()
    { 
        for (int i = 0; i < maxRayCount; i++)
        {        
            Instantiate(RayPrefab,Vector3.zero, Quaternion.identity);
        }    
    }
    private void Update()
    {
        Rays = GameObject.FindGameObjectsWithTag("Ray");
        for (int i = 0; i < Rays.Length; i++)
        {
            Ray = Rays[i].GetComponent<LineRenderer>();
            Offset.x = Mathf.Sin(i * 2 * Mathf.PI / maxRayCount);
            Offset.y = Mathf.Cos(i * 2 * Mathf.PI / maxRayCount);
            Ray.SetPosition(1, Ray.GetPosition(0) + Offset*Radius);
            
            B_Offset = Boundary.GetPosition(1) - Boundary.GetPosition(0);
            if (B_Offset != Offset)
            {
                Debug.Log("Collision possible");
            }
        }
    }
}
