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
    private Vector3 B_Offset = new Vector3(-1.5f, -4f,0f);
    private float Radius = 0.1f;
    private float cRadius;
    public float Length = 1;
    private float cLength;
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
            Boundary.SetPosition(1, Boundary.GetPosition(0) + B_Offset);
            cLength = (Offset.x * (Boundary.GetPosition(0).y - Ray.GetPosition(0).y) + Offset.y * (Ray.GetPosition(0).x - Boundary.GetPosition(0).x)) / (B_Offset.x * Offset.y - B_Offset.y * Offset.x);
            cRadius = (Boundary.GetPosition(0).x + B_Offset.x * Length - Ray.GetPosition(0).x) / Offset.x;

            if (cRadius > 0 )
            {
                Radius = cRadius;
            }
            else
            {
                Radius = 2.5f;
            }

            Debug.Log("Length: " + Length);
            Debug.Log("Radius: " + Radius);
        }
    }
}
