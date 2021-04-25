using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    public GameObject[] Objects;

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
    }
}
