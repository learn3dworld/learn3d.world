using UnityEngine;

public class SmoothedTransformVelocityReference : IVelocityReference
{
    private Vector3 lastPos;
    private Vector3 velocity;
    private Vector3 resultant;
    public float alpha = 0.6f;
    private float oneMinusAlpha;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
        oneMinusAlpha = 1 - alpha;
        resultant = Vector3.zero;
    }

    private void FixedUpdate()
    {
        Vector3 posDiff = transform.position - lastPos;
        velocity = posDiff / Time.fixedDeltaTime;

        resultant = alpha * resultant + oneMinusAlpha * velocity;
        lastPos = transform.position;
        //Debug.Log("Velocity: " + getVelocity().ToString() + "Position: " + getPosition().ToString());
    }

    public override Vector3 getVelocity()
    {
        return resultant;
    }

    public override Vector3 getPosition()
    {
        return transform.position;
    }

    // Update is called once per frame
    void Update() {}
}
