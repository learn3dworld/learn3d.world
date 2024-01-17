using UnityEngine;

public class ComponentVector : MonoBehaviour
{
    public Vector mainVector;
    public Vector newVector;

    public Vector3 axis;

    // Start is called before the first frame update
    void Start()
    {
        if (axis == null) { axis = Vector3.forward; }
    }

    // Update is called once per frame
    void Update()
    {
        if (mainVector == null) { return; }

        Vector3 original = mainVector.toVector3();
        float length = Vector3.Dot(original, axis);
        newVector.setPosition(axis, length);
    }
}
