using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ParabollicBullet : Bullet
{
    Rigidbody rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Destroy(gameObject,2); 
    }

    public override Rigidbody GetRigidbody()
    {
        return rigidBody;
    }
}
