using UnityEngine;

[ExecuteInEditMode]
public class LookAtPosition : MonoBehaviour
{
    [SerializeField] private float lookAtX;
    [SerializeField] private float lookAtZ;

    private void Update ()
    {
        var posY = transform.position.y;
        transform.LookAt (new Vector3 (lookAtX, posY, lookAtZ));
    }
}