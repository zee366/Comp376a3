using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkSpawner : MonoBehaviour
{
    public GameObject prefab;

    // spawn a shark every 3 seconds
    void Start()
    {
        InvokeRepeating("SpawnShark", 3.0f, 3.0f);
    }

    // choose a random shark spawn point to instantiate a shark
    void SpawnShark() {
        int index = Random.Range(0, transform.childCount);
        Vector3 position = transform.GetChild(index).transform.position;
        Instantiate(prefab, position, Quaternion.identity);
    }
}
