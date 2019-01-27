using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnterExitControl : MonoBehaviour
{

	static List<EnterExitControl> allControllers = new List<EnterExitControl>();

	public static void OnEnterCollision(Collider col) {
		Debug.Log(col.name);
		foreach (EnterExitControl controller in allControllers) {
			if (controller.triggerVolume == col) {
				controller.FireEnter();
			}
		}
	}

	public static void OnExitCollision(Collider col) {
		foreach (EnterExitControl controller in allControllers) {
			if (controller.triggerVolume == col) {
				controller.FireExit();
			}
		}
	}


	//public float controlValue;
	public Collider triggerVolume;

	//public bool fireOnce;
	//bool fired;

	public float enterValue = 1f;
	public float enterLerpTime = 1f;
	public float exitValue = 0f;
	public float exitLerpTime = 1f;

	//enum CollisionState {
	//	Outside,
	//	Entering,
	//	Inside,
	//	Exiting
	//}

	//private CollisionState collisionState = CollisionState.Outside;

	protected virtual void Start()
    {
        if (!triggerVolume.isTrigger) {
			Debug.LogError("Trigger volume " + triggerVolume.name + " must have 'is trigger' enabled!");
			return;
		}

		allControllers.Add(this);

	} 

	protected void OnDisable() {
		allControllers.Remove(this);
	}

	protected abstract void FireEnter();
	//{
	//	LerpTo(enterValue, enterLerpTime);
	//}

	protected abstract void FireExit();
	// {
	//	LerpTo(exitValue, exitLerpTime);
	//}

	protected IEnumerator LerpFloatTo(float controlValue, float targetVal, float timeToLerp) {
		float timeElapsed = 0f;
		float startingVal = controlValue;

		while (timeElapsed < timeToLerp) {
			Debug.Log("control value = " + controlValue);
			controlValue = Mathf.Lerp(startingVal, targetVal, timeElapsed / timeToLerp);
			timeElapsed += Time.deltaTime;
			yield return null;
		}
	}

	//protected void ManageFiredState() {
	//	if (fireOnce) {
	//		fired = true;
	//	}
	//}

}
