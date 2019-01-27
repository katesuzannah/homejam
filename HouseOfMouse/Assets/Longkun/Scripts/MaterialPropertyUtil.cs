using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPropertyUtil 
{
  public static IEnumerator LerpMaterialFloat(Material mat, int floatPropertyID, float from, float to, float duration) {
    float t = 0;
    while (t < duration) {
      float f = Mathf.Lerp(from, to, t / duration);
      SetMaterialFloat(mat, floatPropertyID, f);



      t += Time.deltaTime;
      yield return null;
    }

  }

  public static void SetMaterialFloat(Material mat, int floatPropertyID, float floatVal) {
    if (mat.HasProperty(floatPropertyID)) {
      mat.SetFloat(floatPropertyID, floatVal);
    }
  }

  public static void SetPropertyBlockFloat(Renderer renderer, int floatPropertyID, float floatVal) {
    MaterialPropertyBlock block = new MaterialPropertyBlock();
    block.SetFloat(floatPropertyID, floatVal);
    renderer.SetPropertyBlock(block);

    
  }
  public static IEnumerator LerpPropertyBlockFloat(Renderer renderer, int floatPropertyID, float from, float to, float duration) {
    float t = 0;
    while (t < duration) {
      float f = Mathf.Lerp(from, to, t / duration);
      SetPropertyBlockFloat(renderer, floatPropertyID, f);



      t += Time.deltaTime;
      yield return null;
    }

  }
}
