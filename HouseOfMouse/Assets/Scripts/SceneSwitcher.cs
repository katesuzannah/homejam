using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

	void Start() {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

    public void StartGame() {
    	Cursor.lockState = CursorLockMode.Locked;
    	Cursor.visible = false;
        SceneManager.LoadScene(1);
    }
    public void EndGame() {
        Application.Quit();
    }
}