using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("References")]
    public GameObject BulletObject;
    public GameObject[] GunHolders;

    [Header("Settings")]
    public Vector2 ShootFrequency = new Vector2(0.5f, 3f);

    private float _shootTimer;
    private float _chosenShootFrequency;

    // Start is called before the first frame update
    void Start()
    {
        _shootTimer = 0f;
        _chosenShootFrequency = Random.Range(ShootFrequency.x, ShootFrequency.y);
    }

    // Update is called once per frame
    void Update()
    {
        _shootTimer += Time.deltaTime;
        if(_shootTimer >= _chosenShootFrequency)
        {
            _shootTimer = 0f;
            Shoot();
        }
    }

    void Shoot()
    {
        for (int i = 0; i < GunHolders.Length; i++)
        {
            GameObject.Instantiate(BulletObject, GunHolders[i].transform.position, BulletObject.transform.rotation, null);
        }
    }
}
