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


  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {

    if (Input.GetMouseButtonDown(0)) {
      m_checkRay = m_fpsCam.ScreenPointToRay(Input.mousePosition);
      m_isRayHit = Physics.Raycast(m_checkRay, out m_raycastHit, 50);
      if (m_isRayHit) {
        Debug.Log("Hit");
        Renderer r = m_raycastHit.transform.GetComponent<Renderer>();
        if (m_colorPreset != null) {
         m_colorPreset.AssignRandomColorRegular(r.material);

          StartCoroutine(MaterialPropertyUtil.LerpMaterialFloat(r.material, Shader.PropertyToID("_SwipRange"), 0f, 1f, 0.5f));
        
        }
   
      }


    }

  }
 
}
