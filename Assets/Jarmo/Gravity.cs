using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float force;

    private void FixedUpdate ()
    {
        rb.AddForce (Vector3.down * force);
    }
}