using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ColorPreset : ScriptableObject
{
  public Color[] m_colors;
  MaterialPropertyBlock m_matPropertyBlock;
  int m_colorNameID = Shader.PropertyToID("_Color");
  int m_lastColor=0;

  private void OnEnable() {
    m_matPropertyBlock = new MaterialPropertyBlock();
  }
  public void AssignRandomColorMaterialBlock(Renderer render) {
    if (m_colors == null || m_colors.Length == 0) {
      Debug.Log("This preset contains 0 texture");
      return;
    }
    int currentColor = (int)Random.Range(0, m_colors.Length);
    if (currentColor == m_lastColor) {
      currentColor++;
      if (currentColor >= m_colors.Length) {
        currentColor = 0;
      }
    }

    Color colorToSet = m_colors[currentColor];
    m_matPropertyBlock.SetColor(m_colorNameID, colorToSet);
    render.SetPropertyBlock(m_matPropertyBlock);
    m_lastColor = currentColor;
  }

  public void AssignRandomColorRegular(Material mat) {
    if (m_colors == null || m_colors.Length == 0) {
      Debug.Log("This preset contains 0 texture");
      return;
    }
    int currentColor = (int)Random.Range(0, m_colors.Length);
    if (currentColor == m_lastColor) {
      currentColor++;
      if (currentColor >= m_colors.Length) {
        currentColor = 0;
      }
    }

    Color colorToSet = m_colors[currentColor];
    
    
    //if (mat.HasProperty(m_textureNameID)) {
    //  mat.SetTexture(m_textureNameID, textureToSet);
    //} else {
    //  Debug.Log("Texture property not found");
    //}
    mat.color = colorToSet;
    m_lastColor = currentColor;
  }


}
