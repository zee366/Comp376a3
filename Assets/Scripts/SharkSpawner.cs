using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkSpawner : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnShark", 3.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnShark() {
        int index = Random.Range(0, transform.childCount);
        Vector3 position = transform.GetChild(index).transform.position;
        Instantiate(prefab, position, Quaternion.identity);
    }
}
