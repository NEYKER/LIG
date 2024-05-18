using UnityEngine;

public class Instructions : MonoBehaviour
{
    Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        rigidBody.isKinematic = false;
    }
}
