using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    private LineRenderer Ray;
    private Vector3 MousePos;
    private Vector3 WorldPos;

    private void Start()
    {
        Ray = gameObject.GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        MousePos = Input.mousePosition;
        MousePos.z = Camera.main.nearClipPlane;
        WorldPos = Camera.main.ScreenToWorldPoint(MousePos);
        Ray.SetPosition(0, WorldPos);
        
        if (Ray.GetPosition(0).x <= -0.3f)
        {
            Ray.SetPosition(0, new Vector3(-0.3f, Ray.GetPosition(0).y, Ray.GetPosition(0).z));
        }
        if (Ray.GetPosition(0).x >=0.3f)
        {
            Ray.SetPosition(0, new Vector3(0.3f, Ray.GetPosition(0).y, Ray.GetPosition(0).z));
        }

        if (Ray.GetPosition(0).y >= 1.1675f)
        {
            Ray.SetPosition(0, new Vector3(Ray.GetPosition(0).x, 1.1675f, Ray.GetPosition(0).z));
        }
        if (Ray.GetPosition(0).y <= 0.835f)
        {
            Ray.SetPosition(0, new Vector3(Ray.GetPosition(0).x, 0.835f, Ray.GetPosition(0).z));
        }
    }

}
