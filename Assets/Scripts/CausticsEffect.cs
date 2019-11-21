using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CausticsEffect : MonoBehaviour
{
    public float fps = 30.0f;
    public Texture2D[] frames;

    private int frameIndex;
    private Projector projector;

    void Start() {
        projector = GetComponent<Projector>();
        NextFrame();
        InvokeRepeating("NextFrame", 1 / fps, 1 / fps);
    }

    // Play caustic effect on underwater surfaces at 30fps
    void NextFrame() {
        projector.material.SetTexture("_ShadowTex", frames[frameIndex]);
        frameIndex = (frameIndex + 1) % frames.Length;
    }
}
