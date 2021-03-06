﻿using UnityEngine;

public class ControllableBox : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject hitGroundEffect;
    
    private bool atRest;
    private bool hasCollided;
    public bool affectedByExplosion;
    public bool IsPickedUp;

    public static event System.Action NextBlock;
    public static event System.Action Fail;

    private void OnEnable()
    {
        //Explosion.ExplosionForce += ExplosionInpulse;
    }

    private void OnDisable()
    {
        //Explosion.ExplosionForce -= ExplosionInpulse;
    }

    private void ExplosionInpulse (float force)
    {
        Debug.Log("IMPULSE");

        if (affectedByExplosion)
        {
            rb.AddForce(Vector3.left * force, ForceMode.Impulse);

        }

    }

    public void Drop ()
    {
        rb.useGravity = true;
        rb.isKinematic = false;
        transform.SetParent(null);
    }

    private void Update()
    {
        if (rb.velocity.magnitude < 0.1f && hasCollided)
        {
            //Debug.Log ("SLEEPING");
            //NextBlock.Invoke ();
            enabled = false;
        }
    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.layer == 4)
        {
            Debug.Log("FAIL");
            Fail?.Invoke();
        }

        
        hasCollided = true;
        
        if (collision.impulse.magnitude > 1)
        {
            var rotation = Quaternion.Euler (0, transform.rotation.y, 0);
            Instantiate (hitGroundEffect, collision.contacts[0].point, rotation);
        }
    }
}