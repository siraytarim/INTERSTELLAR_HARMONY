using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRed : MonoBehaviour
{
    public float lifetime;
    public GameObject deathEffect;

    private GameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Planet"))
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            gm.GameOver();
        }
        else
        {
            Destroy(gameObject, 2f);
        }
    }
}
