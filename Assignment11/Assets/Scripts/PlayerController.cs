using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Sam Ferstein
 * PlayerController.cs
 * Assignment 11
 * This controls the player.
 */

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject barrel1;
    public GameObject barrel2;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public GameObject bulletPrefab3;
    public float horizontalInput;
    public float moveSpeed = 15;
    public float xRange = 10;
    public BulletManagerFacade bulletFacade;
    public bool colorChange;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * moveSpeed);
        if(colorChange == true)
        {
            barrel1.SetActive(true);
            barrel2.SetActive(false);
        }
        if (colorChange == false)
        {
            barrel1.SetActive(false);
            barrel2.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bulletFacade.FireBullets();
            colorChange = !colorChange;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnRedBullet();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnBlueBullet();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpawnYellowBullet();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            gameManager.gameOver();
        }
    }

    void SpawnRedBullet()
    {
        Instantiate(bulletPrefab.transform, firePoint.transform.position, firePoint.transform.rotation);
    }

    void SpawnBlueBullet()
    {
        Instantiate(bulletPrefab2.transform, firePoint.transform.position, firePoint.transform.rotation);
    }

    void SpawnYellowBullet()
    {
        Instantiate(bulletPrefab3.transform, firePoint.transform.position, firePoint.transform.rotation);
    }
}
