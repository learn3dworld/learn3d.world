using UnityEngine;

public class VelocityVector : MonoBehaviour
{
    public float minSize = 0.0025f;
    public float scale = 0.25f;

    public Rigidbody referenceObject;
    private Vector3 unitVector;
    [SerializeField]
    private new Renderer renderer;
    [SerializeField]
    private GameObject tip;
    private Renderer tipRenderer;

    private bool isRendered = true;

    [SerializeField]
    private float offset = 0.5f;

    private Vector3 posOffset;
    private Vector3 negOffset;

    // Start is called before the first frame update
    void Awake()
    {
        // referenceObject = GetComponentInParent<Rigidbody>();

        if (renderer == null)
            renderer = GetComponent<Renderer>();

        tipRenderer = tip.GetComponent<Renderer>();
    }

    private void Start()
    {
        // Direction the vector is pointing (parent transform is at root of vector)
        unitVector = (transform.position - transform.parent.position).normalized;
        posOffset = unitVector * offset;
        negOffset = posOffset * -1;
    }

    public void setOffset(float offset)
    {
        this.offset = offset;
        posOffset = unitVector * offset;
        negOffset = posOffset * -1;
    }

    public void setColor(Color color)
    {
        renderer.material.SetColor("_Color", color);
        tipRenderer.material.SetColor("_Color", color);
    }

    // Update is called once per frame
    void Update()
    {
        if (referenceObject == null) { return; }


        // Get the velocity in the direction of the unit vector
        float velocity = Vector3.Dot(referenceObject.velocity, unitVector);
        float length = Mathf.Sqrt(Mathf.Abs(scale * velocity)) * Mathf.Sign(velocity * scale);

        // Disable rendering if the arrow is too small
        bool renderVector = System.Math.Abs(length) >= minSize;
        if (isRendered != renderVector)
        {
            isRendered = renderVector;
            renderer.enabled = isRendered;
            tipRenderer.enabled = isRendered;
        }

        // Move the vector to the outside of the object
        transform.parent.parent.localPosition = (length > 0 ? posOffset : negOffset);
        transform.parent.parent.position = referenceObject.position;

        // Scale the X-axis to make the arrow the right length
        Vector3 arrowScale = this.transform.parent.localScale;
        arrowScale.x = length;
        this.transform.parent.localScale = arrowScale;

        tip.transform.localPosition = new Vector3(2*length, 0, 0);
    }
}
