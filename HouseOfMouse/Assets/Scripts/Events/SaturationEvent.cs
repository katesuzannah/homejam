using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaturationEvent : EnterExitControl {

	public Material desaturationMaterial;

	protected override void FireEnter() {
		StartCoroutine(LerpSaturationTo(enterValue, enterLerpTime));
	}

	protected override void FireExit() {
		//no effect
	}

	protected IEnumerator LerpSaturationTo(float targetVal, float timeToLerp) {
		float timeElapsed = 0f;
		float startingVal = desaturationMaterial.GetFloat("_Intensity");

		while (timeElapsed < timeToLerp) {
			desaturationMaterial.SetFloat("_Intensity", Mathf.Lerp(startingVal, targetVal, timeElapsed / timeToLerp));
			timeElapsed += Time.deltaTime;
			yield return null;
		}
	}
}
