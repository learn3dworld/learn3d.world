using System;
using Unity.VisualScripting;
using UnityEngine;

public class Vector1 : MonoBehaviour
{
    // Starting point
    public Transform tail;
    public Transform tip;

    public LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, tail.position);
        lineRenderer.SetPosition(1, tip.transform.position);
        tip.LookAt(tail);
    }
}
