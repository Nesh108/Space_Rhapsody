using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D playerRigidbody2D;
    public AudioSource ShootAudioSource;
    public GameObject BulletObject;
    public GameObject[] GunHolders;

    [Header("Settings")]
    public float MoveSpeed = 100;
    public int NumberOfGuns = 2;

    private float _hAxis, _vAxis;
    private float _hMove, _vMove;

    // Update is called once per frame
    void Update()
    {
        _hAxis = Input.GetAxisRaw("Horizontal");
        _vAxis = Input.GetAxisRaw("Vertical");

        if(Input.GetButtonUp("Fire1"))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(_hAxis) > 0.001 || Mathf.Abs(_vAxis) > 0.001)
        {
            _hMove = _hAxis * MoveSpeed * Time.fixedDeltaTime;
            _vMove = _vAxis * MoveSpeed * Time.fixedDeltaTime;
            playerRigidbody2D.AddForce(new Vector2(_hMove, _vMove));
        }
        else
        {
            playerRigidbody2D.velocity = new Vector2(0f, 0f);
        }
    }

    void Shoot()
    {
        for(int i = 0; i < NumberOfGuns; i++)
        {
            if (i < GunHolders.Length)
            {
                GameObject.Instantiate(BulletObject, GunHolders[i].transform.position, BulletObject.transform.rotation, null);
            }
        }

        ShootAudioSource.Play();
        Debug.Log("Sparo supersonico!!!");
    }
}
