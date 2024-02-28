using System;
using UnityEngine;

public class Vector : MonoBehaviour
{
    // Starting point
    public Transform tail;
    public Transform origin;

    // End point (object)
    public GameObject tip;
    private Renderer[] tipRenderers;
    private bool isRendered = true;

    public float minSize = 0.0025f;

    public LineRenderer lineRenderer;

    public bool tipIsInteractable = true;
    public bool tailIsInteractable = true;
    private bool tipCurrentlyInteractable = true;
    private bool tailCurrentlyInteractable = true;

    // Start is called before the first frame update
    void Awake()
    {
        if (lineRenderer == null) { lineRenderer = GetComponent<LineRenderer>(); }
        if (tipRenderers == null) { tipRenderers = tip.GetComponentsInChildren<Renderer>(); }
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
        foreach (Renderer renderer in tipRenderers)
        {
            renderer.enabled = rendered;
        }
    }

    // Update is called once per frame
    void Update()
    {
        refreshPosition();

        //if (origin)
        //{
        //    setTailPosition(origin.position);
        //}

        if (tipIsInteractable != tipCurrentlyInteractable)
        {
            foreach (Rigidbody rb in tip.GetComponentsInChildren<Rigidbody>())
            {
                rb.isKinematic = !tipIsInteractable;
            }
            tipCurrentlyInteractable = tipIsInteractable;
        }
        if (tailIsInteractable != tailCurrentlyInteractable)
        {
            foreach (Rigidbody rb in tail.GetComponents<Rigidbody>())
            {
                rb.isKinematic = !tailIsInteractable;
            }
            tailCurrentlyInteractable = tailIsInteractable;
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
