using System.Collections;
using UnityEngine;

public class Earthquaker : MonoBehaviour
{
    [SerializeField] private float force = 10;
    [SerializeField] private Vector3 groundMovement = new Vector3 (0.3f, 0.1f, 0.3f);
    [SerializeField] private Vector2Int floorsToDetach = new Vector2Int (3, 6);
    
    public void TriggerEarthquake ()
    {
        StartCoroutine (Quake ());
    }

    private IEnumerator Quake ()
    {
        Debug.Log ("Quake");

        var wait = new WaitForFixedUpdate ();
        yield return wait;

        var floorsToDetach = Random.Range (3, 6);
        var houses = World.Active.Houses;

        for (var i = 0; i < floorsToDetach; i++)
        {
            var house = houses[Random.Range (0,houses.Count)];
            if (house.HasFloors)
                house.DetachTopFloor (force);
            
            yield return wait;
            MoveGroundRandomly ();
            yield return new WaitForSeconds (0.1f);
        }
    }

    private void MoveGroundRandomly ()
    {
        var position = World.Active.Ground.position;
        position.x += Random.Range (-groundMovement.x, groundMovement.x);
        position.z += Random.Range (-groundMovement.y, groundMovement.y);
        position.y += Random.Range (-groundMovement.z, groundMovement.z);
        
        World.Active.Ground.MovePosition (position);
    }
    
    private IEnumerator LerpGroundToOrigin ()
    {
        yield break;
    }

    private void Update ()
    {
        if (Input.GetKeyDown (KeyCode.Q))
            TriggerEarthquake ();
    }
}
