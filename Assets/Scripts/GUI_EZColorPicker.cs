using System;
using UnityEngine;

public class GUI_EZColorPicker : MonoBehaviour
{
	public struct ColorInterpValue
	{
		public Vector2 pixelPosition;

		public Vector3 spacePosition;
	}

	public Transform colorPalette;

	private UIButton colorPaletteBtn;

	private Texture2D colorPaletteTxt;

	public Transform colorIndicator;

	private IUIObject thisIUIObject;

	private RaycastHit hitInfo;

	private IUIObject hitIUIObject;

	private Collider hitCollider;

	private Vector2 pixelUV;

	private Vector2 position;

	private Color paletteColor;

	private ColorPicker_ColorChangeDel colorChangeDel;

	public ColorToChange colorPickerChange;

	private ColorInterpValue[,,] colorInterpTable;

	private Vector3 workVector3;

	private Color workColor;

	private void Awake()
	{
		colorPaletteBtn = colorPalette.GetComponent<UIButton>();
	}

	private void Start()
	{
		colorPaletteBtn.AddInputDelegate(HandleColorPaletteInput);
		colorPaletteTxt = (Texture2D)colorPaletteBtn.renderer.material.mainTexture;
		pixelUV.x = (float)colorPaletteTxt.width / 2f;
		pixelUV.y = (float)colorPaletteTxt.height / 2f;
		paletteColor = colorPaletteTxt.GetPixel((int)pixelUV.x, (int)pixelUV.y);
		ResetMeshCollider();
		thisIUIObject = (IUIObject)colorPaletteBtn.GetComponent(typeof(IUIObject));
		InitColorValueInterpolation();
	}

	public void ResetMeshCollider()
	{
		MeshCollider meshCollider = (MeshCollider)colorPalette.collider;
		MeshFilter component = colorPalette.GetComponent<MeshFilter>();
		meshCollider.sharedMesh = component.sharedMesh;
	}

	public void HandleColorPaletteInput(ref POINTER_INFO eventInfo)
	{
		if (eventInfo.evt != POINTER_INFO.INPUT_EVENT.PRESS && eventInfo.evt != POINTER_INFO.INPUT_EVENT.DRAG)
		{
			return;
		}
		hitInfo = eventInfo.hitInfo;
		hitCollider = hitInfo.collider;
		if (!(hitCollider != null))
		{
			return;
		}
		hitIUIObject = (IUIObject)hitInfo.collider.gameObject.GetComponent(typeof(IUIObject));
		if (hitIUIObject == thisIUIObject)
		{
			colorPaletteTxt = (Texture2D)hitCollider.renderer.material.mainTexture;
			pixelUV = hitInfo.textureCoord;
			pixelUV.x *= colorPaletteTxt.width;
			pixelUV.y *= colorPaletteTxt.height;
			paletteColor = colorPaletteTxt.GetPixel((int)pixelUV.x, (int)pixelUV.y);
			if (colorPickerChange == ColorToChange.FIRST)
			{
				ColorWheel.getnewColor1(paletteColor);
			}
			else
			{
				ColorWheel.getnewColor2(paletteColor);
			}
			position.x = hitInfo.point.x;
			position.y = hitInfo.point.y;
			workVector3.x = position.x;
			workVector3.y = position.y;
			workVector3.z = colorIndicator.position.z;
			colorIndicator.position = workVector3;
			if (colorChangeDel != null)
			{
				colorChangeDel(paletteColor);
			}
		}
	}

	public void SetValueChangeDel(ColorPicker_ColorChangeDel del)
	{
		colorChangeDel = del;
	}

	public void AddValueChangeDel(ColorPicker_ColorChangeDel del)
	{
		colorChangeDel = (ColorPicker_ColorChangeDel)Delegate.Combine(colorChangeDel, del);
	}

	public void RemoveValueChangeDel(ColorPicker_ColorChangeDel del)
	{
		colorChangeDel = (ColorPicker_ColorChangeDel)Delegate.Remove(colorChangeDel, del);
	}

	public void SetColorValue(Color newColor)
	{
		int num = (int)(255f * newColor.r / 16f);
		int num2 = (int)(255f * newColor.g / 16f);
		int num3 = (int)(255f * newColor.b / 16f);
		ColorInterpValue colorInterpValue = colorInterpTable[num, num2, num3];
		colorIndicator.position = colorPaletteBtn.transform.TransformPoint(colorInterpValue.spacePosition);
		if (colorIndicator.localPosition.z > -2f)
		{
			workVector3 = colorIndicator.localPosition;
			workVector3.z = -2f;
			colorIndicator.localPosition = workVector3;
		}
		pixelUV = colorInterpValue.pixelPosition;
	}

	private void InitColorValueInterpolation()
	{
		colorInterpTable = new ColorInterpValue[16, 16, 16];
		Vector3[] vertices = colorPaletteBtn.GetVertices();
		Vector3 vector = vertices[0];
		ColorInterpValue colorInterpValue = default(ColorInterpValue);
		for (int i = 0; i < colorPaletteTxt.width; i++)
		{
			for (int j = 0; j < colorPaletteTxt.height; j++)
			{
				workColor = colorPaletteTxt.GetPixel(i, j);
				int num = (int)(255f * workColor.r / 16f);
				int num2 = (int)(255f * workColor.g / 16f);
				int num3 = (int)(255f * workColor.b / 16f);
				workVector3.x = vector.x + (float)i / (float)colorPaletteTxt.width * colorPaletteBtn.width;
				workVector3.y = vector.y - (float)j / (float)colorPaletteTxt.height * colorPaletteBtn.height;
				workVector3.z = -2f;
				colorInterpValue.pixelPosition.x = i;
				colorInterpValue.pixelPosition.y = j;
				colorInterpValue.spacePosition = workVector3;
				colorInterpTable[num, num2, num3] = colorInterpValue;
			}
		}
	}
}
