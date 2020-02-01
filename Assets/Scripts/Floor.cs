using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private Vector3 dimensions;
    [SerializeField] private Rigidbody attachedRigidbody;
    private SpringJoint connectingJoint;

    public Rigidbody AttachedRigidbody => attachedRigidbody;
    public float Heigth => dimensions.y;

    public void Connect (Rigidbody floorBelow)
    {
        connectingJoint = gameObject.AddComponent<SpringJoint> ();
        connectingJoint.connectedBody = floorBelow;
        connectingJoint.enableCollision = true;
        connectingJoint.spring = 1000;
        connectingJoint.damper = 1;
    }

    public void Detach ()
    {
        Destroy (connectingJoint);
    }
    
    private void OnDrawGizmos ()
    {
        Gizmos.DrawWireCube (transform.position, dimensions);
    }
}
