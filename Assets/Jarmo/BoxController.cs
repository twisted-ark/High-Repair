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

    private void Awake ()
    {
        controllableBox = Instantiate (box, spanwPoint.position, Quaternion.identity).GetComponent<ControllableBox> ();
        controllableBox.transform.SetParent (spanwPoint);
    }

    private void OnEnable ()
    {
        ControllableBox.NextBlock += Spawn;
    }

    private void OnDisable ()
    {
        ControllableBox.NextBlock -= Spawn;
    }

    void Update ()
    {
        if (controlsDisabled)
            return;

        Vector3 input = new Vector3 (Input.GetAxis ("Vertical"), 0f, -Input.GetAxis ("Horizontal"));

        input = Quaternion.Euler (0, -45, 0) * input;

        if (crane)
            crane.transform.Translate (input * speed);

        if (previousInput != Vector3.zero && input == Vector3.zero)
        {
            controllableBox.Drop ();
            controlsDisabled = true;
        }

        previousInput = input;
    }

    private void Spawn ()
    {
        controlsDisabled = false;
        crane.position += new Vector3 (0, 1, 0);
        controllableBox = Instantiate (box, spanwPoint.position, Quaternion.identity).GetComponent<ControllableBox> ();
        controllableBox.transform.SetParent (spanwPoint);
    }
}