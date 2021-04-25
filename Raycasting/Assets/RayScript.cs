using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    private LineRenderer Ray;
    private Vector3 MousePos;
    private Vector3 WorldPos;

    private Vector3 RayPos = Vector3.zero;

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
    }

}
