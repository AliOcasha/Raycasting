using UnityEngine;

public class Ray : MonoBehaviour
{    
    private Vector3 MousePos;
    private Vector3 WorldPos;

    // Creating a Ray
    public void CreateRay()
    {
        Instantiate(gameObject);
    }

    public void DrawRay(LineRenderer Ray, Vector3 Direction)
    {
        // Projection Mouse Position from Raw Window Position into Camera and World
        MousePos = Input.mousePosition;
        MousePos.z = Camera.main.nearClipPlane;
        WorldPos = Camera.main.ScreenToWorldPoint(MousePos);
        Ray.SetPosition(0, WorldPos);
        // Direction and Length of Ray depending on Input
        Ray.SetPosition(1, Ray.GetPosition(0) + Direction);
    }
}
