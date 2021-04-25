using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{
    public GameObject RayPrefab;
    public LineRenderer Boundary;

    public LineRenderer[] Objects;
    public int maxRayCount = 1000;

    private GameObject Ray;
    private LineRenderer LineRenderer;
    private GameObject[] Rays;

    private Vector3 Offset = Vector3.zero;
    private readonly float maxRadius = 0.5f;
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

            if (LineRenderer.GetPosition(1).x <= -0.3f)

                LineRenderer.SetPosition(1, new Vector3(-0.3f, LineRenderer.GetPosition(1).y, LineRenderer.GetPosition(1).z));
            
            if (LineRenderer.GetPosition(1).x >= 0.3f)
                LineRenderer.SetPosition(1, new Vector3(0.3f, LineRenderer.GetPosition(1).y, LineRenderer.GetPosition(1).z));

            if (LineRenderer.GetPosition(1).y >= 1.1675f)
                LineRenderer.SetPosition(1, new Vector3(LineRenderer.GetPosition(1).x, 1.1675f, LineRenderer.GetPosition(1).z));

            if (LineRenderer.GetPosition(1).y <= 0.835f)
                LineRenderer.SetPosition(1, new Vector3(LineRenderer.GetPosition(1).x, 0.835f, LineRenderer.GetPosition(1).z));

            intersection(LineRenderer.GetPosition(0), LineRenderer.GetPosition(1));
        }
    }

    private void intersection( Vector3 r1, Vector3 r2)
    {
        float steigungr = r2.x - r1.x / r2.y - r1.y; 
    }
}
