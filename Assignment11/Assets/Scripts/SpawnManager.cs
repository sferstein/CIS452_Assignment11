using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Sam Ferstein
 * SpawnManager.cs
 * Assignment 11
 * This manages the enemies that spawn.
 */

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    private GameManager gameManager;
    private float spawnPosZ = 5;
    private float delay = 0.5f;
    private float spawnPosX1 = 0;
    private float spawnPosX2 = 8.08f;
    private float spawnInterval = 3;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnEnemy", delay, spawnInterval);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void spawnEnemy()
    {
        if (gameManager.isGameActive)
        {
            Vector3 spawnPos1 = new Vector3(spawnPosX1, 0, spawnPosZ);
            Vector3 spawnPos2 = new Vector3(spawnPosX2, 0, spawnPosZ);
            Vector3 spawnPos3 = new Vector3(-spawnPosX2, 0, spawnPosZ);
            int enemyIndex1 = Random.Range(0, enemyPrefab.Length);
            int enemyIndex2 = Random.Range(0, enemyPrefab.Length);
            int enemyIndex3 = Random.Range(0, enemyPrefab.Length);

            Instantiate(enemyPrefab[enemyIndex1], spawnPos1, enemyPrefab[enemyIndex1].transform.rotation);
            Instantiate(enemyPrefab[enemyIndex2], spawnPos2, enemyPrefab[enemyIndex2].transform.rotation);
            Instantiate(enemyPrefab[enemyIndex3], spawnPos3, enemyPrefab[enemyIndex3].transform.rotation);
        }
    }
}
