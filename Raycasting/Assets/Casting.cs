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
    public float Length = 1;
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
            Boundary.SetPosition(1, Boundary.GetPosition(0) + B_Offset*Length);
            if (B_Offset != Offset)
            {
                // Isolate T1 for both equations, getting rid of T1
                T1 = (s_px + s_dx * T2 - r_px) / r_dx = (s_py + s_dy * T2 - r_py) / r_dy

                // Multiply both sides by r_dx * r_dy
                s_px* r_dy +s_dx * T2 * r_dy - r_px * r_dy = s_py * r_dx + s_dy * T2 * r_dx - r_py * r_dx

                // Solve for T2!
                T2 = (r_dx * (s_py - r_py) + r_dy * (r_px - s_px)) / (s_dx * r_dy - s_dy * r_dx)

                // Plug the value of T2 to get T1
                T1 = (s_px + s_dx * T2 - r_px) / r_dx
            }
        }
    }
}
