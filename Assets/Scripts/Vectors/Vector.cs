using System;
using UnityEngine;

public class Vector : MonoBehaviour
{
    // Starting point
    public Transform tail;

    public Transform origin;
    // End point (object)
    public GameObject tip;
    private Renderer tipRenderer;
    private bool isRendered = true;

    public float minSize = 0.0025f;

    public LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        if (lineRenderer == null) { lineRenderer = GetComponent<LineRenderer>(); }
        if (tipRenderer == null) {  tipRenderer = tip.GetComponent<Renderer>(); }
    }

    public void refreshPosition()
    {
        lineRenderer.SetPosition(0, tail.position);
        lineRenderer.SetPosition(1, tip.transform.position);
        tip.transform.LookAt(tail.position);
    }

    public Vector3 toVector3()
    {
        return tip.transform.position - tail.position;
    }

    public void setTailPosition(Vector3 pos)
    {
        tail.position = pos;
    }

    public void setVector(Vector3 vector, float scale)
    {
        tip.transform.position = tail.position + vector*scale;
    }

    public void setVector(Vector3 vector)
    {
        setVector(vector, 1);
    }

    public void setRender(bool rendered)
    {
        this.isRendered = rendered;
        lineRenderer.enabled = rendered;
        tipRenderer.enabled = rendered;
    }

    // Update is called once per frame
    void Update()
    {
        refreshPosition();

        if (origin)
        {
            setTailPosition(origin.position);
        }

        bool renderVector = false;

        // Check if vector length is too short
        float length = (tip.transform.position - tail.position).magnitude;
        renderVector = length >= minSize;
        
        // Update rendering if necessary
        if (isRendered != renderVector)
        {
            setRender(renderVector);
        }

        //TODO: Make sure tip is facing outwards
        tip.transform.LookAt(tail);
    }
}
