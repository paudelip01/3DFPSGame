﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] enemies;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;
    int randEnemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());
    }
    void Update()
    {
        spawnWait = Random.Range (spawnLeastWait, spawnMostWait);
    }

    // Update is called once per frame
    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(1);

        while(true)
        {
            randEnemy = Random.Range(0,2);
            Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 1, Random.Range (-spawnValues.z, spawnValues.z) );
            Instantiate (enemies[randEnemy], spawnPosition + transform.TransformPoint(0,0,0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait); 
        } 
    }
}
