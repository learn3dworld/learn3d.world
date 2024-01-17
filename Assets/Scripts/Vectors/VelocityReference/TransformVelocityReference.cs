using UnityEngine;

public class TransformVelocityReference : IVelocityReference
{
    private Vector3 lastPos;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 posDiff = transform.position - lastPos;
        velocity = posDiff / Time.fixedDeltaTime;
        lastPos = transform.position;
        //Debug.Log("Velocity: " + getVelocity().ToString() + "Position: " + getPosition().ToString());
    }

    public override Vector3 getVelocity()
    {
        return velocity;
    }

    public override Vector3 getPosition()
    {
        return transform.position;
        //return lastPos;
    }

    // Update is called once per frame
    void Update() {}
}
