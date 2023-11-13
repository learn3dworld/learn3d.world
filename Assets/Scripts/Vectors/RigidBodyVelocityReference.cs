using UnityEngine;

public class RigidBodyVelocityReference : IVelocityReference
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
    }

    public override Vector3 getVelocity()
    {
        return rb.velocity;
    }

    public override Vector3 getPosition()
    {
        return rb.position;
    }
}
