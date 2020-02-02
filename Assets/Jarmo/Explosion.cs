using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;

    public static event System.Action<float> ExplosionForce;

    void OnEnable()
    {


        /*
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }*/
    }

    public void Quake()
    {
        ExplosionForce.Invoke(power);
    }
}