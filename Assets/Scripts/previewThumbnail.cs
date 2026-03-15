using UnityEngine;

public class previewThumbnail : MonoBehaviour
{
	public void changeTextureToShow(Texture newTex)
	{
		base.gameObject.renderer.material.mainTexture = newTex;
	}
}
