using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorByPalette : MonoBehaviour
{

	Material mat;

	private void Start() {
		mat = GetComponent<MeshRenderer>().material;
	}

	// Update is called once per frame
	void Update()
    {
		mat.color = Color.Lerp(Color.white, Color.blue, ColorPalette.warmth);
    }
}
