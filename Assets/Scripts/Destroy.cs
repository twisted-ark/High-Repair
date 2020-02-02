using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    
    private void OnCollisionEnter (Collision other)
    {
        if (!other.collider.attachedRigidbody)
            return;

        if (!other.collider.attachedRigidbody.GetComponent<ControllableBox> ())
            return;

        Instantiate (effect, transform.position, transform.rotation);
        Destroy (gameObject);
    }
}
