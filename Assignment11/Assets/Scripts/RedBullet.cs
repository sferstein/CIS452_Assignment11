using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Sam Ferstein
 * RedBullet.cs
 * Assignment 11
 * This is one of the submethods for the Facade pattern.
 */

public class RedBullet : MonoBehaviour
{
    public float speed;
    private float maxDistance = 5;
    public bool fired = false;

    void Update()
    {
        if (fired == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            if (transform.position.z > maxDistance)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Fire()
    {
        fired = !fired;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
