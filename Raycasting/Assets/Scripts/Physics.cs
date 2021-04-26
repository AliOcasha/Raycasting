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

    // Creating n Rays at Start and Detecting B_Direction
    private void Start()
    {
        for (int i = 0; i < maxRayCount; i++)
            Rays.CreateRay();

        B_Direction = Boundary.GetPosition(1) - Boundary.GetPosition(0);
    }

    private void FixedUpdate()
    {
        // Getting all Rays in Scene
        AllRays = GameObject.FindGameObjectsWithTag("Ray");
        for (int i = 0; i < AllRays.Length; i++)
        {
            // Distrubuting Rays evenly around Mouse Position
            Direction.x = Mathf.Sin(i * 2 * Mathf.PI / maxRayCount);
            Direction.y = Mathf.Cos(i * 2 * Mathf.PI / maxRayCount);
            // Getting Line Renderer of current Ray
            RayDraw = AllRays[i].GetComponent<LineRenderer>();
            // Detecting intersection with Boundary
            Intersection(RayDraw, Boundary);
            // Drawing Ray
            Rays.DrawRay(RayDraw, Direction*Length);
            
        }

    }

    void Intersection(LineRenderer R, LineRenderer B)
    {
        // Trying to Detect a Collision with a Boundary and modifying Length as Reaction
        // NOT WORKING -- Currently makin invisble Barrier in middle of Screen
        u = B.GetPosition(0).x;
        cLength = (Boundary.GetPosition(0).x + B_Direction.x * u - R.GetPosition(0).x) / Direction.x;
        // Only Apply Resicing when Ray is poiting in right direction
        // Limpiting Ray Length to 5 cause of Unity not liking infinite Rays
        if (cLength < 0)
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
