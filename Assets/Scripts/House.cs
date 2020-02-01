using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Vector2Int startHeight;
    [SerializeField] private Floor floorPiece;
    
    [SerializeField] private Rigidbody baseFloor;
    
    private List<Floor> attachedFloors = new List<Floor> ();

    private FixedJoint groundJoint;
    
    private Vector3[] corners = new []
    {
        new Vector3 (1, 0, 1),
        new Vector3 (1, 0, -1),
        new Vector3 (-1, 0, 1),
        new Vector3 (-1, 0, -1),
    };

    public bool HasFloors => attachedFloors.Count > 0;
    
    private void Start ()
    {
        var floorsToPlace = Random.Range (startHeight.x, startHeight.y + 1);
        var worldPosition = transform.position;
        
        for (var i = 0; i < floorsToPlace; i++)
        {
            var position = worldPosition + new Vector3 (0, floorPiece.Heigth * i, 0);
            var floor = Instantiate (floorPiece, position, Quaternion.identity, transform);
            AttachFloor (floor);
        }
        
        World.Active.AddHouse (this);

        groundJoint = gameObject.AddComponent<FixedJoint> ();
        groundJoint.connectedBody = World.Active.Ground;
        groundJoint.enableCollision = true;
    }

    private void AttachFloor (Floor floor)
    {
        var connectToFloor = attachedFloors.Count > 0 ? attachedFloors.Last ().AttachedRigidbody : baseFloor;
        attachedFloors.Add (floor);
        floor.Connect (connectToFloor);
    }

    public void DetachTopFloor (float force)
    {
        if (attachedFloors.Count == 0)
            return;

        var floor = attachedFloors.Last ();
        floor.Detach ();
        
        var explosionPosition = floorPiece.transform.position;
        explosionPosition += corners[Random.Range (0, corners.Length)];
        
        floor.AttachedRigidbody.AddExplosionForce (force, explosionPosition, 40, 0.1f, ForceMode.VelocityChange);
        attachedFloors.RemoveAt (attachedFloors.Count - 1);
    }
}
