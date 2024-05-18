using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class ExplosionBullet : Bullet
{
    [SerializeField] float explosionForce = 500f;
    [SerializeField] float explosionRadius = 5f;
    [SerializeField] float explosionDelay = 1f;
    Rigidbody rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Destroy(gameObject, 10);
    }

    public void OnCollisionEnter(Collision collision)
    {
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;

        StartCoroutine(ExplodeAfterDelay());
    }

    IEnumerator ExplodeAfterDelay()
    {
        yield return new WaitForSeconds(explosionDelay);
        Explode();
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        Destroy(gameObject);
    }

    public override Rigidbody GetRigidbody()
    {
        return rigidBody;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}