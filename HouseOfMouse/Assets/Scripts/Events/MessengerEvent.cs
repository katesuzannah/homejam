using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MessageParameters {
	readonly float enterValue;
	readonly float enterLerpTime;
	readonly float exitValue;
	readonly float exitLerpTime;

	public MessageParameters(float enterVal, float enterTime, float exitVal, float exitTime) {
		enterValue = enterVal;
		enterLerpTime = enterTime;
		exitValue = exitVal;
		exitLerpTime = exitTime;
	}
}

public class MessengerEvent : EnterExitControl {

	public GameObject messageReceiver;

	MessageParameters parameters;

	protected override void Start() {
		base.Start();

		parameters = new MessageParameters(enterValue, enterLerpTime, exitValue, exitLerpTime);
	}

	protected override void FireEnter() {
		messageReceiver.SendMessage("OnEventTriggerVolumeEnter", parameters);
	}

	protected override void FireExit() {
		messageReceiver.SendMessage("OnEventTriggerVolumeExit", parameters);
	}
}

public interface MessengerEventReceiver {
	void OnEventTriggerVolumeEnter(MessageParameters parameters);
	void OnEventTriggerVolumeExit(MessageParameters parameters);
}
