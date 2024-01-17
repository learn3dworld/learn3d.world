using UnityEngine;

public class VelocityVector : MonoBehaviour
{
    private Vector vector;
    public float scale = 0.25f;
    public IVelocityReference referenceObject;

    // Start is called before the first frame update
    void Start()
    {
        if (vector == null) { vector = GetComponent<Vector>(); }
        if (vector == null) { vector = GetComponentInChildren<Vector>(); }
    }

    // Update is called once per frame
    void Update()
    {
        if (referenceObject == null) { return; }

        Vector3 velocity = referenceObject.getVelocity();
        vector.setPosition(velocity, scale);
    }
}
