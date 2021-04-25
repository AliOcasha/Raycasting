using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject RayPrefab;
    public int maxRayCount = 1000;

    private GameObject Ray;
    private LineRenderer LineRenderer;
    private GameObject[] Rays;

    private Vector3 Offset = Vector3.zero;
    private float maxRadius = 0.1f;
    private float currentRadius;
    private void Start()
    { 
        for (int i = 0; i < maxRayCount; i++)
        {        
            Instantiate(RayPrefab,Vector3.zero, Quaternion.identity);
        }    
    }
    private void Update()
    {
        if (currentRadius < maxRadius)
        {
            currentRadius += 0.005f;
        }
        Rays = GameObject.FindGameObjectsWithTag("Ray");
        for (int i = 0; i < Rays.Length; i++)
        {
            Ray = Rays[i];
            LineRenderer = Ray.GetComponent<LineRenderer>();

            Offset.x = Mathf.Sin(i * 2 * Mathf.PI / maxRayCount)*currentRadius;
            Offset.y = Mathf.Cos(i * 2 * Mathf.PI / maxRayCount)*currentRadius;
            LineRenderer.SetPosition(1, LineRenderer.GetPosition(0) + Offset);
        }
    }
}
