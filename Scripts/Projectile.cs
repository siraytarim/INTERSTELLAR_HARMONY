using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject[] planets;

    private Vector2 target;

    public float speed;

    private GameMaster gm;

    private void Start()
    {
        gm=GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        planets=GameObject.FindGameObjectsWithTag("Planet");

        int rand=Random.Range(0,planets.Length);    
        target=planets[rand].transform.position;

    }
    private void Update()
    {
        transform.position=Vector2.MoveTowards(transform.position,target,speed*Time.deltaTime);
        if(Vector2.Distance(target,transform.position) < 0.2f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Planet"))
        {
            gm.GameOver();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
