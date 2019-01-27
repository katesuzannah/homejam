using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerTriggerController : MonoBehaviour
{

	Collider collider;

    // Start is called before the first frame update
    void Start()
    {
		collider = GetComponent<Collider>();
    }

	private void OnTriggerEnter(Collider other) {
		if (other.GetComponent<EnterExitControl>() != null) {
			Debug.Log("Trigger enter");
			EnterExitControl.OnEnterCollision(other);
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.GetComponent<EnterExitControl>() != null) {
			Debug.Log("Trigger exit");
			EnterExitControl.OnExitCollision(other);
		}
	}

}
