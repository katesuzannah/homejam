using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPresetSelector : MonoBehaviour
{

	public ColorPreset preset;

	private void OnTriggerEnter(Collider other) {
		ColorAssigner assigner = other.GetComponent<ColorAssigner>();

		if (assigner != null) {
			assigner.m_colorPreset = preset;
		}
	}
}
