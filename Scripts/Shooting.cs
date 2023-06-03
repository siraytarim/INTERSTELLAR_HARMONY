using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shotPos;

    public GameObject projectile;

    public float timeBtwnSht;
    public float startTimeBtwnSht;

    private void Update()
    {
        if (timeBtwnSht <= 0)
        {
            Instantiate(projectile,shotPos.position, Quaternion.identity);
            timeBtwnSht = startTimeBtwnSht;
        }
        else
        {
            timeBtwnSht -= Time.deltaTime;
        }
    }
}
