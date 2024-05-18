using UnityEngine;

public interface IWeapon 
{
    public Transform transform { get; }
    public Rigidbody RigidBody { get; }
    public MeshCollider MeshCollider { get; }
    public void Shoot();
    public void Reload();
    public void InitializeWeapon();
}
