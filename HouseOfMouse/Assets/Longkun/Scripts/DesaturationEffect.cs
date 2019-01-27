using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
[ImageEffectAllowedInSceneView]
public class DesaturationEffect : MonoBehaviour
{

  public Material m_renderMat;

  // Start is called before the first frame update
  void Start() {
    if (!SystemInfo.supportsImageEffects || null == m_renderMat ||
           null == m_renderMat.shader || !m_renderMat.shader.isSupported) {
      enabled = false;
      return;
    }

		m_renderMat.SetFloat("_Intensity", -5f);
  }
    // Update is called once per frame
    void Update() {

    }
  private void OnRenderImage(RenderTexture source, RenderTexture destination) {
    if (m_renderMat != null) {
      Graphics.Blit(source, destination, m_renderMat);
    }
  }



}
