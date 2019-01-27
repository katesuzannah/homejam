using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayTrackOnEnter : MonoBehaviour
{

	AudioSource source;

	bool played;

    // Start is called before the first frame update
    void Start()
    {
		source = GetComponent<AudioSource>();
    }

	private void OnTriggerEnter(Collider other) {
		if (!played && other.GetComponent<PlayerTriggerController>() != null) {
			played = true;
			source.Play();
		}
	}
}
