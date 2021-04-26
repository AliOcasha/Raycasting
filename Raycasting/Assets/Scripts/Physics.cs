using UnityEngine;

public class Physics : MonoBehaviour
{
    public int maxRayCount = 1000;
    public GameObject RayPrefab;
    public Ray Rays;
    public LineRenderer Boundary;

    private float cLength;
    private float u;    
    private float Length = 0.01f;
    private GameObject[] AllRays;
    private LineRenderer RayDraw;
    private Vector3 Direction = Vector3.zero;
    private Vector3 B_Direction = Vector3.zero;


    private void Start()
    {
        for (int i = 0; i < maxRayCount; i++)
            Rays.CreateRay();

        B_Direction = Boundary.GetPosition(1) - Boundary.GetPosition(0);
    }

    private void FixedUpdate()
    {
        AllRays = GameObject.FindGameObjectsWithTag("Ray");
        for (int i = 0; i < AllRays.Length; i++)
        {
            Direction.x = Mathf.Sin(i * 2 * Mathf.PI / maxRayCount);
            Direction.y = Mathf.Cos(i * 2 * Mathf.PI / maxRayCount);
            RayDraw = AllRays[i].GetComponent<LineRenderer>();
            intersection(RayDraw, Boundary);
            Rays.DrawRay(RayDraw, Direction*Length);
            
        }

    }

    void intersection(LineRenderer R, LineRenderer B)
    {
        u = B.GetPosition(0).x;
        cLength = (Boundary.GetPosition(0).x + B_Direction.x * u - R.GetPosition(0).x) / Direction.x;
        if (cLength > 0)
        {
            if (cLength < 5)
                Length = cLength;
            else
                Length = 5;
        }
        else
            Length = 5;
    }
}
