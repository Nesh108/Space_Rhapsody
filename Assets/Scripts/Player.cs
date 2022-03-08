using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D playerRigidbody2D;
    public AudioSource ShootAudioSource;
    public GameObject BulletObject;
    public GameObject[] GunHolders;
    
    [Header("Settings")]
    [Tooltip("Numero non-negativo da 0 a 10.000")]
    [Range(0, 10000)]
    public float MoveSpeed = 100;
    [Tooltip("Numero non-negativo")]
    public int NumberOfGuns = 2;

    private float _hAxis, _vAxis;
    private float _hMove, _vMove;

    void Awake()
    {
        if(playerRigidbody2D == null)
        {
            Debug.LogError("[IF] Ti sei dimenticato di impostare il `playerRigidbody2D`!!!");
            playerRigidbody2D = GetComponent<Rigidbody2D>();
            if (playerRigidbody2D != null)
            {
                Debug.LogWarning("Me lo sono trovato io!");
            }
            else
            {
                Debug.LogError("Non l'ho trovato!");
            }
        }

        if(NumberOfGuns <= 0)
        {
            Debug.LogError("[IF] `NumberOfGuns` meno di 0!!!");
            NumberOfGuns = 2;
            Debug.LogWarning("Utillizando il valore di default: `2`");
        }

        // Integrity-Check
        Debug.Assert(playerRigidbody2D != null, "[ASSERT] Ti sei dimenticato di impostare il `playerRigidbody2D`!!!");
        Debug.Assert(ShootAudioSource != null, "[ASSERT] Ti sei dimenticato di impostare il `ShootAudioSource`!!!");
        Debug.Assert(BulletObject != null, "[ASSERT] Ti sei dimenticato di impostare il `BulletObject`!!!");
        Debug.Assert(GunHolders != null, "[ASSERT] Ti sei dimenticato di impostare il `GunHolders`!!!");
        Debug.Assert(GunHolders.Length > 0, "[ASSERT] Non si sono pistole nel `GunHolders`!!!");
        Debug.Assert(NumberOfGuns > 0, "[ASSERT] `NumberOfGuns` meno di 0!!!");
        Debug.Assert(NumberOfGuns < GunHolders.Length, "[ASSERT] `NumberOfGuns` piu del massimo!!!");
    }

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
        for (int i = 0; i < NumberOfGuns; i++)
        {
            if (i < GunHolders.Length)
            {
                GameObject.Instantiate(BulletObject, GunHolders[i].transform.position, BulletObject.transform.rotation, null);
            }
        }

        ShootAudioSource.Play();
        Debug.Log("Sparo supersonico!!!");
    }

    public void SetMaxGuns()
    {
        NumberOfGuns = GunHolders.Length;
    }
}
