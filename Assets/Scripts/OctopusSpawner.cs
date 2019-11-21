using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusSpawner : MonoBehaviour {
    public GameObject prefab;


    void Start() {
        float firstSpawn = Random.Range(10.0f, 20.0f);
        float repeatRate = Random.Range(20.0f, 30.0f);

        // spawn octopus at random times (see range above)
        InvokeRepeating("SpawnOctopus", firstSpawn, repeatRate);
    }

    // choose a random spawn point for the octopus
    void SpawnOctopus() {
        int index = Random.Range(0, transform.childCount);
        Vector3 position = transform.GetChild(index).transform.position;
        Instantiate(prefab, position, Quaternion.identity);
    }
}