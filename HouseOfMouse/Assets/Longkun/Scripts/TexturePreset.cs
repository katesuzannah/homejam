using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TexturePreset : ScriptableObject
{
  public Texture2D[] m_textures;
  MaterialPropertyBlock m_matPropertyBlock;
  int m_textureNameID = Shader.PropertyToID("_MainTex");

  private void OnEnable() {
    m_matPropertyBlock = new MaterialPropertyBlock();
  }
  public void AssignRandomTextureMaterialBlock(Renderer render) {
    if (m_textures==null || m_textures.Length == 0) {
      Debug.Log("This preset contains 0 texture");
      return;
    }
    Texture textureToSet = m_textures[(int)Random.Range(0,m_textures.Length)];
    m_matPropertyBlock.SetTexture(m_textureNameID, textureToSet);
    render.SetPropertyBlock(m_matPropertyBlock);
  }

  public void AssignRandomTextureRegular(Material mat) {
    if (m_textures == null || m_textures.Length == 0) {
      Debug.Log("This preset contains 0 texture");
      return;
    }
    Texture2D textureToSet = m_textures[(int)Random.Range(0, m_textures.Length)];
    //if (mat.HasProperty(m_textureNameID)) {
    //  mat.SetTexture(m_textureNameID, textureToSet);
    //} else {
    //  Debug.Log("Texture property not found");
    //}
    mat.mainTexture = textureToSet;
   
  }
}
