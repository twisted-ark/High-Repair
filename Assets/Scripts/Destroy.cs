using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    [SerializeField] private Animator animator;
    
    private void OnCollisionEnter (Collision other)
    {
        if (!other.collider.attachedRigidbody)
            return;

        if (!other.collider.attachedRigidbody.GetComponent<ControllableBox> ())
            return;

        Instantiate (effect, transform.position, transform.rotation);
        gameObject.SetActive (false);
        Invoke (nameof (ReEnable), Random.Range (5, 8));

        //animator.keepAnimatorControllerStateOnDisable = false;
    }

    private void ReEnable ()
    {
        gameObject.SetActive (true);
    }
}
