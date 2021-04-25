using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{

    private LineRenderer LineRenderer;
    private void Start()
    {
        LineRenderer = gameObject.GetComponent<LineRenderer>();
    }
}
