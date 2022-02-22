using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D BulletRigidBody;

    [Header("Settings")]
    public float Speed = 10f;
    public bool IsPlayer = true;
    public float BulletDuration = 1f;

    void Start()
    {
        Destroy(gameObject, BulletDuration);    
    }

    void FixedUpdate()
    {
        BulletRigidBody.velocity = new Vector2(0f, Speed * -transform.up.x);
    }
}
