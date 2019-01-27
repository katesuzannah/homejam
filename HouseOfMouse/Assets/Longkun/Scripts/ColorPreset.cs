using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ColorPreset : ScriptableObject
{
  public Color[] m_colors;
  MaterialPropertyBlock m_matPropertyBlock;
  int m_colorNameID = Shader.PropertyToID("_Color");

  private void OnEnable() {
    m_matPropertyBlock = new MaterialPropertyBlock();
  }
  public void AssignRandomColorMaterialBlock(Renderer render) {
    if (m_colors == null || m_colors.Length == 0) {
      Debug.Log("This preset contains 0 texture");
      return;
    }
    Color colorToSet = m_colors[(int)Random.Range(0, m_colors.Length)];
    m_matPropertyBlock.SetColor(m_colorNameID, colorToSet);
    render.SetPropertyBlock(m_matPropertyBlock);
  }

  public void AssignRandomColorRegular(Material mat) {
    if (m_colors == null || m_colors.Length == 0) {
      Debug.Log("This preset contains 0 texture");
      return;
    }
    Color colorToSet = m_colors[(int)Random.Range(0, m_colors.Length)];
    
    
    //if (mat.HasProperty(m_textureNameID)) {
    //  mat.SetTexture(m_textureNameID, textureToSet);
    //} else {
    //  Debug.Log("Texture property not found");
    //}
    mat.color = colorToSet;

  }


}
