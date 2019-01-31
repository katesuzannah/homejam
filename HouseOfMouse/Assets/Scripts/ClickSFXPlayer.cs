using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ClickSFXPlayer : MonoBehaviour
{

	public List<AudioClip> clips;
	int lastPlayedIndex;
	public AudioSource source;



	public void PlaySFX() {
		int newIndex = Random.Range(0, clips.Count - 1);

		while (newIndex == lastPlayedIndex) {
			newIndex = Random.Range(0, clips.Count - 1);
		}

		source.PlayOneShot(clips[newIndex]);
		lastPlayedIndex = newIndex;
	}
}
