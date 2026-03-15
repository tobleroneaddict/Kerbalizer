using UnityEngine;

public class ColorWheel : MonoBehaviour
{
	public static Color finalC1;

	public static Color finalC2;

	public static int showColors;

	public GUI_EZColorPicker picker1;

	public GUI_EZColorPicker picker2;

	public static ColorWheel cw;

	private void Awake()
	{
		showColors = 0;
		picker1.gameObject.SetActive(false);
		picker2.gameObject.SetActive(false);
		cw = GetComponent<ColorWheel>();
	}

	public static void getnewColor1(Color color1)
	{
		if (showColors != 0)
		{
			finalC1 = color1;
		}
	}

	public static void getnewColor2(Color color2)
	{
		if (showColors != 0)
		{
			finalC2 = color2;
		}
	}

	public static void showPickers()
	{
		if (showColors == 1)
		{
			cw.picker1.gameObject.SetActive(true);
			cw.picker2.gameObject.SetActive(false);
		}
		else if (showColors == 2)
		{
			cw.picker1.gameObject.SetActive(true);
			cw.picker2.gameObject.SetActive(true);
		}
		else if (showColors == 0)
		{
			cw.picker1.gameObject.SetActive(false);
			cw.picker2.gameObject.SetActive(false);
		}
	}
}
