using UnityEngine;

public abstract class IVelocityReference : MonoBehaviour
{
    public abstract Vector3 getPosition();
    public abstract Vector3 getVelocity();
}
