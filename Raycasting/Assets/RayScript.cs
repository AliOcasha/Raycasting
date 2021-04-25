using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    private LineRenderer Ray;
    private Vector3 MousePos;
    private Vector3 WorldPos;
    private Vector3 Offset = new Vector3(0.1f, 0.1f, 0);
    private Vector3 C_Offset = Vector3.zero;
    // Start is called before the first frame update
    private void Start()
    {
        Ray = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //if (C_Offset.x < Offset.x)
        //{
        //    C_Offset.x += 0.005f;
        //}
        //if (C_Offset.y < Offset.y)
        //{
        //    C_Offset.y += 0.005f;
        //}
        MousePos = Input.mousePosition;
        MousePos.z = Camera.main.nearClipPlane;
        WorldPos = Camera.main.ScreenToWorldPoint(MousePos);
        Ray.SetPosition(0, WorldPos);
    }
}
