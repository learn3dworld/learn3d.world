using UnityEngine;

public class ComponentVector : MonoBehaviour
{
    public Vector mainVector;
    public Vector newVector;

    private Vector3 axis;
    private float axisLengthSquared;
    public float scale;

    // Start is called before the first frame update
    void Start()
    {
        if (axis == null) { setAxis(Vector3.forward); }
    }

    public void setAxis(Vector3 vector)
    {
        axis = vector;
        axisLengthSquared = axis.magnitude * axis.magnitude; 
    }

    // Update is called once per frame
    void Update()
    {
        if (mainVector == null) { return; }

        newVector.setTailPosition(mainVector.transform.position);
        Vector3 original = mainVector.toVector3();
        float length = Vector3.Dot(original, axis) / axisLengthSquared;
        newVector.setVector(axis, length * scale);
    }
}
