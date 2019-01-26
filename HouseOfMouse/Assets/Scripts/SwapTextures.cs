using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapTextures : MonoBehaviour

{

	public Camera cam;
	public float maxDistance = 1f;
	public ParticleSystem particleSystem;

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Mouse0))
			SwapTexture();
	}

	private void SwapTexture() {
		//get object pointed at
		RaycastHit rch;
		if (Physics.Raycast(cam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0)), 
						cam.transform.forward, out rch, maxDistance)) {


			//if has Texture Set, swap

			TextureSet textures = rch.transform.GetComponent<TextureSet>();
			if (textures != null) {
				textures.SwitchMaterials();
				particleSystem.Play();
			}
		}
	}

	//private void OnDrawGizmos() {
	//	Gizmos.color = Color.red;
	//	Gizmos.DrawLine(cam.transform.position, 
	//		cam.transform.position + cam.transform.forward * maxDistance);

	//	Gizmos.color = Color.black;
	//	Gizmos.DrawSphere(cam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0f)), .1f);
	//}

}
