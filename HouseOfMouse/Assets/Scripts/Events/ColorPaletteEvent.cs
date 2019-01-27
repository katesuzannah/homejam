using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPaletteEvent : EnterExitControl {

	protected  void Start() {
		base.Start();
		triggerVolume = GetComponent<Collider>();
	}

	protected override void FireEnter() {
		StartCoroutine(ColorPalette.LerpWarmthTo(enterValue, enterLerpTime));
	}

	protected override void FireExit() {
		StartCoroutine(ColorPalette.LerpWarmthTo(exitValue, exitLerpTime));
	}
}
