using System;
using Unity.VisualScripting;
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

    public float length = 0;

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

    public void refreshLength()
    {
        if (tipIsInteractable || tailIsInteractable)
        {
            length = Math.Abs(tail.position.magnitude - tip.transform.position.magnitude);
        }
    }

    public void refreshPosition()
    {
        //Debug.Log(length);
        if (!tipIsInteractable && !tailIsInteractable)
        {
            if (Math.Abs(length) < minSize)
            {
                length = minSize;
            }

            Debug.Log(toRoundedVector3());

            setVector(toRoundedVector3().normalized * length);
            length = Math.Abs(length);
        }
        refreshLength();

        lineRenderer.SetPosition(0, tail.position);
        lineRenderer.SetPosition(1, tip.transform.position);
        tip.transform.LookAt(tail.position);
    }

    public Vector3 toVector3()
    {
        return tip.transform.position - tail.position;
    }

    public Vector3 toRoundedVector3()
    {
        return new Vector3((int)(Math.Round(tip.transform.position.x - tail.position.x)),
            (int)(Math.Round(tip.transform.position.y - tail.position.y)),
            (int)(Math.Round(tip.transform.position.z - tail.position.z)));
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
