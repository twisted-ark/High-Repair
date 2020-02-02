using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private Transform raycastPoint;
    [SerializeField] private PhysicMaterial physicMaterial;
    [SerializeField] private List<ControllableBox> boxes = new List<ControllableBox> ();
    private bool delay = true; 

    private void OnEnable ()
    {
        Explosion.ExplosionForce += ExplosionHappening;
        Invoke (nameof(DelayTrigger), 1f);
    }

    private void OnDisable ()
    {
        Explosion.ExplosionForce -= ExplosionHappening;
    }

    private void DelayTrigger ()
    {
        delay = false;
    }

    private void OnTriggerEnter (Collider other)
    {
        if (delay)
            return;

        if (other.GetComponent<ControllableBox> ())
        {
            other.GetComponent<Collider>().material = null;
            boxes.Add (other.GetComponent<ControllableBox>());

            other.GetComponentInChildren<ScorePopUp>().ShowScorePopUp();
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.GetComponent<ControllableBox>())
        {
            other.GetComponent<Collider>().material = null;
            boxes.Remove (other.GetComponent<ControllableBox>());
        }
    }

    private void ExplosionHappening (float force)
    {
        int rand = Random.Range (0, 3);

        if (rand > boxes.Count - 1)
            rand = boxes.Count;

        //Debug.Log("Random " + rand + " This " + this.gameObject.name);
        //int integer = 0;

        for (int i = 0; i < rand; i++)  //(int i = boxes.Count - 1; i >= 0; i--)
        {
            //if (integer > rand)
            //    break;
            Debug.Log(i);
            boxes [boxes.Count - 1].gameObject.GetComponent<Collider>().material = physicMaterial;
            boxes[boxes.Count - 1].gameObject.GetComponent<Rigidbody>().AddForce(Quaternion.Euler(0, Random.Range(0, 360), 0) * Vector3.right * 3f, ForceMode.Impulse);
            boxes.RemoveAt(boxes.Count - 1);
            //integer++;
        }

        /*Vector3 direction = Quaternion.Euler (Random.Range (0, 10), 0, Random.Range (0, 10)) * Vector3.up;
        Debug.Log ("Direction " + direction);

        if (Physics.Raycast(raycastPoint.position, Vector3.down * 10f, out RaycastHit hit))
        {
            Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody> ();
            rb.AddForce (direction * force, ForceMode.Impulse);
        }*/
    }
}