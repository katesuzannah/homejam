using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageReceiver : MonoBehaviour, MessengerEventReceiver {
	public void OnEventTriggerVolumeEnter(MessageParameters parameters) {
		Debug.Log("received enter event with params " + parameters.ToString());
	}

	public void OnEventTriggerVolumeExit(MessageParameters parameters) {
		Debug.Log("received exit event");
	}
}
