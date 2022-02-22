using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D EnemyRigidBody;

    [Header("Settings")]
    public float Speed = 10f;
    public float EnemyDuration = 1f;

    void Start()
    {
        Destroy(gameObject, EnemyDuration);    
    }

    void FixedUpdate()
    {
        EnemyRigidBody.velocity = new Vector2(0f, Speed * -transform.up.y);
    }
}
