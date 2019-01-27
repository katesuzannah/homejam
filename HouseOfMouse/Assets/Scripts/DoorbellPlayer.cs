using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorbellPlayer : MonoBehaviour, MessengerEventReceiver
{

	public float timeToWait = 15f;
	public AudioSource source;

	public void OnEventTriggerVolumeEnter(MessageParameters parameters) {
		StartCoroutine(WaitAndPlayDoorbell());
	}

	public void OnEventTriggerVolumeExit(MessageParameters parameters) {
		//do nothing
	}


	IEnumerator WaitAndPlayDoorbell() {
		yield return new WaitForSeconds(timeToWait);
		source.Play();
	}
}
