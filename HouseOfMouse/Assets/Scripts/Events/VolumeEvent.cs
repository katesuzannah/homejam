using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VolumeEvent : EnterExitControl {

	AudioSource source;

	new protected virtual void Start() {
		base.Start();

		source = GetComponent<AudioSource>();
	}

	protected override void FireEnter() {
		StartCoroutine(LerpVolumeTo(enterValue, enterLerpTime));
	}

	protected override void FireExit() {
		StartCoroutine(LerpVolumeTo(exitValue, exitLerpTime));
	}

	protected IEnumerator LerpVolumeTo(float targetVal, float timeToLerp) {
		float timeElapsed = 0f;
		float startingVal = source.volume;

		while (timeElapsed < timeToLerp) {
			Debug.Log("control value = " + source.volume);
			source.volume = Mathf.Lerp(startingVal, targetVal, timeElapsed / timeToLerp);
			timeElapsed += Time.deltaTime;
			yield return null;
		}
	}
}
