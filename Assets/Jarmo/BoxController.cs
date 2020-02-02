using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class BoxController : MonoBehaviour
{
    private ControllableBox controllableBox;
    [SerializeField] private float speed;
    [SerializeField] private GameObject box;
    private bool controlsDisabled;

    [SerializeField] private Transform crane;
    [SerializeField] private Transform spanwPoint;

    private Vector3 previousInput;

    [SerializeField] private bool canPickUp;
    [SerializeField] private Transform objectToPickUp;
    [SerializeField] private bool isCarrying;

    [SerializeField] private Transform markerBox;

    private Camera mainCamera;

    private void Awake ()
    {
        mainCamera = Camera.main;
    }

    void Update ()
    {
        if (controlsDisabled)
            return;

        Vector3 input = new Vector3 (Input.GetAxis ("Vertical"), 0f, -Input.GetAxis ("Horizontal"));

        input = Quaternion.Euler (0, -45, 0) * input;

        if (crane)
        {
            crane.Translate (input * speed);
            //ClampCranePosition ();
        }


        if (previousInput != Vector3.zero && input == Vector3.zero && isCarrying)
        {
            controllableBox.Drop ();
            controlsDisabled = true;
            isCarrying = false;
        }
        
        if (Physics.Raycast (crane.position, Vector3.down * 10f, out RaycastHit hit))
        {
            if (hit.collider.GetComponent<ControllableBox>() && !isCarrying)
            {
                canPickUp = true;
                objectToPickUp = hit.collider.transform;
                //Debug.Log ("CANPICKUP");
            }
            else
            {
                canPickUp = false;

                if(!isCarrying)
                    objectToPickUp = null;
            }

            markerBox.position = hit.point;
        }
    }

    public void TryPickUp ()
    {
        if (canPickUp && !isCarrying)
        {
            objectToPickUp.parent = spanwPoint;
            objectToPickUp.GetComponent<Rigidbody>().isKinematic = true;
            StartCoroutine (Pull (objectToPickUp));
            objectToPickUp.GetComponent<Collider>().enabled = false;

            objectToPickUp.gameObject.layer = 2;

            isCarrying = true;
            canPickUp = false;
        }
        else if (isCarrying)
        {

            objectToPickUp.GetComponent<Collider>().enabled = true;
            objectToPickUp.gameObject.layer = 0;

            Debug.Log(objectToPickUp.GetComponent<Collider>().enabled);
            isCarrying = false;
            canPickUp = true;
            objectToPickUp.parent = null;
            objectToPickUp.GetComponent<ControllableBox>().Drop();
        }

    }

    private IEnumerator Pull (Transform t)
    {
        Vector3 start = t.position;
        Vector3 end = spanwPoint.position;


        float distance = Vector3.Distance (start, end);

        while (Vector3.Distance (t.position, spanwPoint.position) > 0.01f)
        {
            t.position = Vector3.MoveTowards (t.position, spanwPoint.position, 0.1f);

            //Debug.Log(1 - Vector3.Distance(t.position, end) / distance);

            t.rotation = Quaternion.Lerp(t.rotation, Quaternion.Euler (0, 15, 0), 1 - Vector3.Distance(t.position, end) / distance);

            yield return null;
        }
    }

    private void ClampCranePosition ()
    {
        var position = crane.position;
        var isoSize = mainCamera.orthographicSize;
        var camRotation = mainCamera.transform.rotation;
        var inverseCamRotation = Quaternion.Inverse (camRotation);

        position = camRotation * position;

        position.x = Mathf.Clamp (position.x, -isoSize, isoSize);
        position.z = Mathf.Clamp (position.z, -isoSize, isoSize);
        
        position = inverseCamRotation * position;
        crane.position = position;
    }
}