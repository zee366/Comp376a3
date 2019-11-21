using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    public GameObject prefab;
    
    // spawn gold at 5 seconds, and every 10 seconds thereafter
    void Start()
    {
        InvokeRepeating("SpawnGold", 5.0f, 10.0f);
    }

    // choose a random gold spawn point to instantiate the gold object
    void SpawnGold() {
        int index = Random.Range(0, transform.childCount);
        Vector3 position = transform.GetChild(index).transform.position;
        Instantiate(prefab, position, Quaternion.identity);
    }
}
