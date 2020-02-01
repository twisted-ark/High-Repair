using System;
using System.Collections;
using UnityEngine;

public class ControllableBox : MonoBehaviour
{
    [SerializeField] private Transform transform;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private GameObject box;
    [SerializeField] private GameObject boxToControl;

    private Vector3 previousInput;

    //public static event Action Dropped;
    //public static event Action Landed;

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
            //Dropped.Invoke ();
            StartCoroutine (SpawnTimer ());
        }

        previousInput = input;
    }

    private IEnumerator SpawnTimer ()
    {
        yield return new WaitForSeconds (2);

        Spawn ();
    }

    private void Spawn ()
    {
        Instantiate(box, new Vector3(0, 5f, 0), Quaternion.identity);
    }
}