using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Vector1 : MonoBehaviour
{
    // Starting point
    public Transform tail;
    public Transform tip;
    public XRGrabInteractable tipInt;
    public XRGrabInteractable tailInt;

    public LineRenderer lineRenderer;

    public bool tailInteractable = true;
    public bool tipInteractable = true;

    private bool lastTailInteractable;
    private bool lastTipInteractable;

    public void setTailInteractable(bool interactable)
    {
        tailInteractable = interactable;
    }

    public void setTipInteractable(bool interactable)
    {
        tipInteractable = interactable;
    }


    // Start is called before the first frame update
    void Awake()
    {
        lastTailInteractable = tailInteractable;
        lastTipInteractable = tipInteractable;
        if (tipInt == null)
        {
            tipInt = tip.GetComponentInChildren<XRGrabInteractable>();
        }
        if (tailInt == null)
        {
            tailInt = tail.GetComponentInChildren<XRGrabInteractable>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tailInteractable != lastTailInteractable)
        {
            lastTailInteractable = tailInteractable;
            tailInt.enabled = tailInteractable;
        }
        if (tipInteractable != lastTipInteractable)
        {
            lastTipInteractable = tipInteractable;
            tipInt.enabled = tipInteractable;
        }

        lineRenderer.SetPosition(0, tail.position);
        lineRenderer.SetPosition(1, tip.transform.position);
        tip.LookAt(tail);
    }
}
