using System;
using System.Collections;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [SerializeField] private Transform transform;
    private ControllableBox controllableBox;
    [SerializeField] private float speed;
    [SerializeField] private GameObject box;

    [SerializeField] private Transform target;

    private Vector3 previousInput;

    //public static event Action Dropped;
    //public static event Action Landed;

    private void Awake ()
    {
        controllableBox = Instantiate (box, target.position, Quaternion.identity).GetComponent<ControllableBox> ();
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
        Vector3 input = new Vector3 (Input.GetAxis ("Vertical"), 0f, -Input.GetAxis ("Horizontal"));

        input = Quaternion.Euler (0, -45, 0) * input;

        if (controllableBox)
            controllableBox.transform.Translate (input * speed);

        if (previousInput != Vector3.zero && input == Vector3.zero)
        {
            controllableBox.Drop ();
            //enabled = false;
        }

        previousInput = input;
    }

    /*private void Drop()
    {
        Debug.Log("END");
        controllableBox.rb.useGravity = true;
        enabled = false;
        //Dropped.Invoke ();
        //StartCoroutine(SpawnTimer());
    }*/

    private IEnumerator SpawnTimer ()
    {
        yield return new WaitForSeconds (2);

        Spawn ();
    }

    private void Spawn ()
    {
        //enabled = true;
        target.position += new Vector3 (0, 1, 0);
        controllableBox = Instantiate (box, target.position, Quaternion.identity).GetComponent<ControllableBox> ();
    }
}