using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    private LineRenderer Ray;
    private Vector3 MousePos;
    private Vector3 WorldPos;
    private Vector3 offset = new Vector3(0.1f, 0.1f, 0);
    // Start is called before the first frame update
    private void Start()
    {
        Ray = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        MousePos = Input.mousePosition;
        MousePos.z = Camera.main.nearClipPlane;
        WorldPos = Camera.main.ScreenToWorldPoint(MousePos);
        Ray.SetPosition(0, WorldPos);
        Ray.SetPosition(1, WorldPos + offset);
    }
}
