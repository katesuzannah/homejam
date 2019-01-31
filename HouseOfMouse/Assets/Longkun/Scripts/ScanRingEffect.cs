using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[ImageEffectAllowedInSceneView]
public class ScanRingEffect : MonoBehaviour
{
  public Camera m_camera;
  public Material m_effectMaterial;
    // Start is called before the first frame update
    void Start()
    {
    if (m_camera == null) {
      m_camera = GetComponent<Camera>();
    }
    }
  private void OnRenderImage(RenderTexture source, RenderTexture destination) {
    //Shader.SetGlobalMatrix("_CameraToWorld", m_camera.cameraToWorldMatrix);
    Graphics.Blit(source, destination, m_effectMaterial);
  }


}
