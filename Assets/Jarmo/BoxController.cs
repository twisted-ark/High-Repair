using System.Collections;
using UnityEngine;

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
    private Transform objectToPickUp;
    [SerializeField] private bool isCarrying;

    private void Awake ()
    {
        //controllableBox = Instantiate (box, spanwPoint.position, Quaternion.identity).GetComponent<ControllableBox> ();
        //controllableBox.transform.SetParent (spanwPoint);
    }

    private void OnEnable ()
    {
        //ControllableBox.NextBlock += Drop;
    }

    private void OnDisable ()
    {
        //ControllableBox.NextBlock -= Drop;
    }

    void Update ()
    {
        if (controlsDisabled)
            return;

        Vector3 input = new Vector3 (Input.GetAxis ("Vertical"), 0f, -Input.GetAxis ("Horizontal"));

        input = Quaternion.Euler (0, -45, 0) * input;

        if (crane)
            crane.transform.Translate (input * speed);

        if (previousInput != Vector3.zero && input == Vector3.zero && isCarrying)
        {
            controllableBox.Drop ();
            controlsDisabled = true;
            isCarrying = false;
        }

        //previousInput = input;

        if (Physics.Raycast (crane.transform.position, Vector3.down * 10f, out RaycastHit hit))
        {
            if (hit.collider.GetComponent<ControllableBox>())
            {
                canPickUp = true;
                objectToPickUp = hit.collider.transform;
                Debug.Log ("CANPICKUP");
            }
            else
            {
                canPickUp = false;
                objectToPickUp = null;
            }
        }
    }

    public void TryPickUp ()
    {
        if (canPickUp && !isCarrying)
        {
            //objectToPickUp.position = spanwPoint.position;
            objectToPickUp.parent = spanwPoint;
            objectToPickUp.GetComponent<Rigidbody>().isKinematic = true;
            StartCoroutine (Pull (objectToPickUp));
            isCarrying = true;
            canPickUp = false;
        }
        else if (isCarrying)
        {
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

            Debug.Log(1 - Vector3.Distance(t.position, end) / distance);

            t.rotation = Quaternion.Lerp(t.rotation, Quaternion.Euler (0, 15, 0), 1 - Vector3.Distance(t.position, end) / distance);

            yield return null;
        }
    }

    private void Drop ()
    {
        //controlsDisabled = false;
        //crane.position += new Vector3 (0, 1, 0);
        //controllableBox = Instantiate (box, spanwPoint.position, Quaternion.identity).GetComponent<ControllableBox> ();
        //controllableBox.transform.SetParent (spanwPoint);
    }
}