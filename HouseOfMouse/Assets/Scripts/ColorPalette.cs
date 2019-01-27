using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorPalette 
{

	public static float warmth = 0f; //[0,1]

	public static IEnumerator LerpWarmthTo(float targetVal, float timeToLerp) {
		float timeElapsed = 0f;
		float startingVal = warmth;

		while (timeElapsed < timeToLerp) {
			warmth = Mathf.Lerp(startingVal, targetVal, timeElapsed / timeToLerp);
			timeElapsed += Time.deltaTime;
			yield return null;
		}
	}

}
