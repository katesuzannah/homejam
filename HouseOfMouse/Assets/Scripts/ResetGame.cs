using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{

	public float timeout = 3f;
	int escCount = 0;
	float timeSinceLastPress = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
			escCount++;
		}

		if (escCount >= 3) {
			escCount = 0;
			SceneManager.LoadScene(0);
		}

		if (escCount > 0f) {
			timeSinceLastPress += Time.deltaTime;
			if (timeSinceLastPress >= timeout) {
				timeSinceLastPress = 0f;
			}
		}
	}
}
