using UnityEngine;

public class Vector : MonoBehaviour
{
    // Starting point
    public Transform tail;
    // End point (object)
    public GameObject tip;
    private Renderer tipRenderer;
    private bool isRendered = true;

    public float minSize = 0.0025f;

    public LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        if (lineRenderer == null) { lineRenderer = GetComponent<LineRenderer>(); }
        if (tipRenderer == null) {  tipRenderer = tip.GetComponent<Renderer>(); }
    }

    public void refreshPosition()
    {
        lineRenderer.SetPosition(0, tail.position);
        lineRenderer.SetPosition(1, tip.transform.position);
    }

    public Vector3 toVector3()
    {
        return tip.transform.position - tail.position;
    }

    public void setPosition(Vector3 vector, float scale)
    {
        tip.transform.position = tail.position + vector*scale;
    }

    public void setPosition(Vector3 vector)
    {
        setPosition(vector, 1);
    }

    // Update is called once per frame
    void Update()
    {
        refreshPosition();

        // Check if vector length is too short
        float length = (tip.transform.position - tail.position).magnitude;
        bool renderVector = length >= minSize;
        
        // Update rendering if necessary
        if (isRendered != renderVector)
        {
            isRendered = renderVector;
            lineRenderer.enabled = isRendered;
            tipRenderer.enabled = isRendered;
        }

        //TODO: Make sure tip is facing outwards
    }
}
