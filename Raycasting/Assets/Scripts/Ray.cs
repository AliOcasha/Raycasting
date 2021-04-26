using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour
{    
    private Vector3 MousePos;
    private Vector3 WorldPos;
    public void CreateRay()
    {
        Instantiate(gameObject);
    }

    public void DrawRay(LineRenderer Ray, Vector3 Direction)
    {
        MousePos = Input.mousePosition;
        MousePos.z = Camera.main.nearClipPlane;
        WorldPos = Camera.main.ScreenToWorldPoint(MousePos);
        Ray.SetPosition(0, WorldPos);
        Ray.SetPosition(1, Ray.GetPosition(0) + Direction);
    }
}
