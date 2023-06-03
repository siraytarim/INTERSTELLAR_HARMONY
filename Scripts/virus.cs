using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class virus : MonoBehaviour
{
    Transform muzzle1,muzzle2,muzzle3,muzzle4;
    public Transform bullet;
    public Transform[] muzzles;
    public float speed;
    public float timeBetweenShot;

    public GameObject deathEffect;

    GameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        muzzles[0] = transform.GetChild(0);
        muzzles[1] = transform.GetChild(1);
        muzzles[2] = transform.GetChild(2);
        muzzles[3] = transform.GetChild(3);
    }
    void Update()
    {
        if (Time.time > timeBetweenShot)
        {
            ShootBullet();
            timeBetweenShot = Time.time + timeBetweenShot;
        }
        void ShootBullet()
        {
            Transform tempBullet;
            tempBullet = Instantiate(bullet, muzzles[Random.Range(0,muzzles.Length)].position, Quaternion.identity);
            tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzles[Random.Range(0, muzzles.Length)].forward * speed); //f?rlatmak için
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            gm.GameOver();
        }
    }
}
