using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAssigner : MonoBehaviour
{
  public Camera m_fpsCam;
  Ray m_checkRay;
  RaycastHit m_raycastHit;
  bool m_isRayHit;
  public ColorPreset m_colorPreset;
  Transform m_lastHitObject;
  Transform m_currentHitObject;
  LayerMask m_defaultLayer;

	public ClickSFXPlayer sfx;


  // Start is called before the first frame update
  void Start() {
    m_defaultLayer = LayerMask.NameToLayer("Default");
  }

  // Update is called once per frame
  void Update() {

  
      m_checkRay = m_fpsCam.ScreenPointToRay(Input.mousePosition);
      m_isRayHit = Physics.Raycast(m_checkRay, out m_raycastHit, 50,1<<m_defaultLayer);
    if (m_lastHitObject && m_lastHitObject != m_raycastHit.transform) {
      Renderer r = m_lastHitObject.GetComponent<Renderer>();
      MaterialPropertyUtil.SetMaterialFloat(r.material, Shader.PropertyToID("_RimPower"), 0);
      m_lastHitObject = null;
    }
      if (m_isRayHit) {
        Debug.Log("Hit");
        m_currentHitObject = m_raycastHit.transform;
        Renderer r = m_currentHitObject.GetComponent<Renderer>();
    
      if (m_lastHitObject != m_currentHitObject) {
        if (r != null) {
          MaterialPropertyUtil.SetMaterialFloat(r.material, Shader.PropertyToID("_RimPower"), 1);
        }
        m_lastHitObject = m_currentHitObject;
      }
      if (Input.GetMouseButtonDown(0)) {
        if (m_colorPreset != null) {
          if (r != null) {
						sfx.PlaySFX();
            m_colorPreset.AssignRandomColorRegular(r.material);

            StartCoroutine(MaterialPropertyUtil.LerpMaterialFloat(r.material, Shader.PropertyToID("_SwipRange"), 0f, 1f, 0.5f));
          }
        

        }
      }

      } else {
      m_lastHitObject = null;
      }


  

  }
 
}
