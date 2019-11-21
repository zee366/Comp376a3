using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // called when user clicks UI buttons
    public void LoadLevel(string name) {
        SceneManager.LoadScene(name);
    }

    // called when user clicks quit game
    public void QuitGame() {
        Application.Quit();
    }
}
