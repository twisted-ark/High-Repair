using UnityEngine;

public class ControllableBox : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private bool atRest;
    private bool hasCollided;

    public static event System.Action NextBlock;
    public static event System.Action Fail;

    public void Drop ()
    {
        rb.useGravity = true;
        transform.SetParent(null);
    }

    private void Update()
    {
        if (rb.velocity.magnitude < 0.1f && hasCollided)
        {
            Debug.Log ("SLEEPING");
            NextBlock.Invoke ();
            enabled = false;
        }
    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.layer == 4)
        {
            Debug.Log("FAIL");
            Fail.Invoke();
        }


        hasCollided = true;
    }
}