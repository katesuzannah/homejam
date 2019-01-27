using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

[RequireComponent(typeof(Renderer))]
public class Clickable : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
  Renderer m_renderer;
  private void Start() {
    m_renderer = GetComponent<Renderer>();
  }
  public void OnPointerClick(PointerEventData eventData) {

    //Debug.Log(gameObject.name + " is being clicked");
   
  }

  public void OnPointerEnter(PointerEventData eventData) {
    //Debug.Log(gameObject.name + " is hit");
    //MaterialPropertyUtil.SetMaterialFloat(m_renderer.material, Shader.PropertyToID("_RimPower"), 1);


  }

  public void OnPointerExit(PointerEventData eventData) {
    //Debug.Log(gameObject.name + " is exited");
    //MaterialPropertyUtil.SetMaterialFloat(m_renderer.material, Shader.PropertyToID("_RimPower"), 0);

  }

  // Start is called before the first frame update
  

}
