using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Pause : MonoBehaviour {
    public GameObject player;
    public GameObject pauseCanvas;
    public GameObject reticleCanvas;
    bool paused = false;
    
    void Start() {
        pauseCanvas.SetActive(false);
    }
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!paused) {
                this.PlayPause();
            }
        }
    }

    public void PlayPause() {
        if (!paused) {
            paused = true;
            reticleCanvas.SetActive(false);
            player.SetActive(false);
            pauseCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
        }
        else {
            reticleCanvas.SetActive(true);
            paused = false; 
            player.SetActive(true);
            pauseCanvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            player.GetComponent<FirstPersonController>().enabled = true;
            Cursor.visible = false;
        }
    }

    public void Quit() {
        SceneManager.LoadScene(0);
    }
}
