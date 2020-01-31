using UnityEngine;

public class ControllableBox : MonoBehaviour
{
    [SerializeField] private Transform transform;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;

    private Vector3 previousInput;

    void Update ()
    {
        Vector3 input = new Vector3 (Input.GetAxis ("Vertical"), 0f, -Input.GetAxis ("Horizontal"));

        input = Quaternion.Euler (0, -45, 0) * input;

        transform.Translate (input * speed);

        if (previousInput != Vector3.zero && input == Vector3.zero)
        {
            Debug.Log("END");
            rb.useGravity = true;
            enabled = false;
        }

        previousInput = input;
    }
}