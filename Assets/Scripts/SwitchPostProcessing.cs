using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityStandardAssets.Water;

public class SwitchPostProcessing : MonoBehaviour
{
    public PostProcessingProfile normal;
    public PostProcessingProfile underwater;

    private PostProcessingBehaviour cameraFx;
    private Water water;

    void Start()
    {
        cameraFx = FindObjectOfType<PostProcessingBehaviour>();
        water = GameObject.Find("WaterSurface").GetComponent<Water>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) {
            cameraFx.profile = underwater;
            water.waterMode = Water.WaterMode.Refractive;
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")) {
            cameraFx.profile = normal;
            water.waterMode = Water.WaterMode.Reflective;
        }
    }
}
