using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureAssigner : MonoBehaviour
{
  public Camera m_fpsCam;
  Ray m_checkRay;
  RaycastHit m_raycastHit;
  bool m_isRayHit;
  public TexturePreset m_texturePreset;
  public LineRenderer m_lineRenderer;

	public ClickSFXPlayer sfx;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
   
    if (Input.GetMouseButtonDown(0)) {
      m_checkRay = m_fpsCam.ScreenPointToRay(Input.mousePosition);
      m_isRayHit = Physics.Raycast(m_checkRay, out m_raycastHit, 50);
      if (m_isRayHit) {
        Debug.Log("Hit");

				sfx.PlaySFX();

        Renderer r = m_raycastHit.transform.GetComponent<Renderer>();
        if (m_texturePreset != null) {
          m_texturePreset.AssignRandomTextureRegular(r.material);
        }
        m_lineRenderer.SetPositions(new Vector3[] { transform.position, m_raycastHit.point });
      }
     
    }
    if (Input.GetMouseButtonUp(0)) {
      m_lineRenderer.SetPositions(new Vector3[] { Vector3.zero, Vector3.zero });
    }
    }
}
