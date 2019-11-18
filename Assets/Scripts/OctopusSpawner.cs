using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusSpawner : MonoBehaviour {
    public GameObject prefab;
    // Start is called before the first frame update
    void Start() {
        float firstSpawn = Random.Range(10.0f, 20.0f);
        float repeatRate = Random.Range(20.0f, 30.0f);
        InvokeRepeating("SpawnOctopus", firstSpawn, repeatRate);
    }

    // Update is called once per frame
    void Update() {

    }

    void SpawnOctopus() {
        int index = Random.Range(0, transform.childCount);
        Vector3 position = transform.GetChild(index).transform.position;
        Instantiate(prefab, position, Quaternion.identity);
    }
}