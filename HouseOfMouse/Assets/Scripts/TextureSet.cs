using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureSet : MonoBehaviour
{

	public List<Material> materials;
	int currMaterialIndex;

	MeshRenderer render;

    // Start is called before the first frame update
    void Start()
    {
		render = GetComponent<MeshRenderer>();
    }

	public void SwitchMaterials() {
		//Material newMat = materials[Random.Range(0, materials.Count - 1)];

		int newMaterialIndex = Random.Range(0, materials.Count - 1);

		while (newMaterialIndex == currMaterialIndex)
			newMaterialIndex = Random.Range(0, materials.Count - 1);

		render.material = materials[newMaterialIndex];
		currMaterialIndex = newMaterialIndex;
	}
}
