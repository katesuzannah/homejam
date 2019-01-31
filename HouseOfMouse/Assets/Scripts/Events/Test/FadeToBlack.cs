using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeToBlack : MonoBehaviour, MessengerEventReceiver
{

	public Image blackImg;
	public AudioSource bgm;

	public float fadeOutTime = 5f;

	public void OnEventTriggerVolumeEnter(MessageParameters parameters) {
		Debug.Log("Trigger fadeout");
		// blackImg.CrossFadeAlpha(1f, fadeOutTime, false);
		StartCoroutine(FadeOutThenRestart());
	}

	IEnumerator FadeOutThenRestart() {
		// yield return new WaitForSeconds(fadeOutTime * 1.5f);
		float timer = 0f;
		while (timer < fadeOutTime) {
			timer += Time.deltaTime;
			Color tmp = blackImg.color;
			tmp.a = timer / fadeOutTime;
			blackImg.color = tmp;
			yield return null;
		}

		timer = 0;

		while (timer <= fadeOutTime) {
			timer += Time.deltaTime;
			bgm.volume = (fadeOutTime - timer) / fadeOutTime;
			yield return null;
		}

		SceneManager.LoadScene(0);
	}

	public void OnEventTriggerVolumeExit(MessageParameters parameters) {
		//do nothing
	}
}
