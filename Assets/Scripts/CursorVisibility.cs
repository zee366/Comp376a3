using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CursorVisibility : MonoBehaviour
{
    // ensure cursor can be used in main menu or game over screen
    void OnLevelWasLoaded(int level) {
        if(FindObjectOfType<RigidbodyFirstPersonController>() != null) {
            Cursor.visible = false;
        }
        else {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
