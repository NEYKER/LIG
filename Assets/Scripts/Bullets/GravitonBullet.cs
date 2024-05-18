using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class GravitonBullet : Bullet
{
    Rigidbody rigidBody;
    [SerializeField] float attractionForce;
    [SerializeField] float attractionRange;
    [SerializeField] float orbitSpeed;  // You'll need to add this to your script and set it in the Inspector

    List<Rigidbody> rigidbodies = new List<Rigidbody>();

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
    }

    void Start()
    {
        Invoke(nameof(DestroyGraviton), 10);
    }

    public override Rigidbody GetRigidbody()
    {
        return rigidBody;
    }

    void DestroyGraviton()
    {
        for (int i = 0; i < rigidbodies.Count; i++)
        {
            if (!rigidbodies[i])
            {
                rigidbodies.RemoveAt(i);
                i--;
                continue;
            }
            rigidbodies[i].useGravity = true;
        }
        DestroyImmediate(gameObject);
    }

    void FixedUpdate()
    {
        AttractObjectsAround();
    }

    private void AttractObjectsAround()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attractionRange);
        List<Collider> tempColliders = new List<Collider>();

        foreach (Collider collider in colliders)
        {
            tempColliders.Add(collider);

            Rigidbody rigidBody = collider.GetComponent<Rigidbody>();
            if (rigidBody != null)
            {
                rigidBody.useGravity = false;
                Vector3 directionToAttractor = (transform.position - collider.transform.position).normalized;

                // Adding the tangential orbit force
                Vector3 tangentialForce = Vector3.Cross(Vector3.up, directionToAttractor).normalized * orbitSpeed;
                Vector3 totalForce = directionToAttractor * attractionForce + tangentialForce;

                rigidBody.AddForce(totalForce * Time.fixedDeltaTime, ForceMode.Acceleration);

                if (!rigidbodies.Contains(rigidBody))
                {
                    rigidbodies.Add(rigidBody);
                }
            }
        }

        for (int i = 0; i < rigidbodies.Count; i++)
        {
            Collider collider = tempColliders.Find(x => x.GetComponent<Rigidbody>() == rigidbodies[i]);
            if (collider == null)
            {
                if (!rigidbodies[i])
                {
                    rigidbodies.RemoveAt(i);
                    i--;
                    continue;
                }
                rigidbodies[i].useGravity = true;
                rigidbodies.RemoveAt(i);
                i--;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attractionRange);
    }
}