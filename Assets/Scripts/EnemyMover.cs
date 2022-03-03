using PathCreation;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D EnemyRigidBody;
    public EndOfPathInstruction EndOfPathInstruction;
    public PathCreator[] PathCreators;

    [Header("Settings")]
    public bool UsePath = true;
    public float Speed = 10f;
    public float EnemyDuration = 1f;

    private float _distanceTravelled;
    private PathCreator _chosenPath;

    void Start()
    {
        if (UsePath)
        {
            if (PathCreators != null && PathCreators.Length > 0)
            {
                _chosenPath = PathCreators[Random.Range(0, PathCreators.Length)];
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                _chosenPath.pathUpdated += OnPathChanged;
            }
        }
        else
        {
            Destroy(gameObject, EnemyDuration);
        }
    }

    void FixedUpdate()
    {
        if (UsePath)
        {
            if (_chosenPath != null)
            {
                _distanceTravelled += Speed * Time.deltaTime;
                EnemyRigidBody.MovePosition(_chosenPath.path.GetPointAtDistance(_distanceTravelled, EndOfPathInstruction));
                EnemyRigidBody.MoveRotation(_chosenPath.path.GetRotationAtDistance(_distanceTravelled, EndOfPathInstruction));

                if(Vector3.Distance(transform.position, _chosenPath.path.GetPoint(_chosenPath.path.NumPoints - 1)) < 0.1f)
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            EnemyRigidBody.velocity = new Vector2(0f, Speed * -transform.up.y);
        }
    }

    // If the path changes during the game, update the distance travelled so that the follower's position on the new path
    // is as close as possible to its position on the old path
    void OnPathChanged()
    {
        _distanceTravelled = _chosenPath.path.GetClosestDistanceAlongPath(transform.position);
    }
}
