using UnityEngine;

public class Switcher : MonoBehaviour
{
	private void Awake()
	{
		if (Screen.width > 1200)
		{
			Application.LoadLevel(2);
		}
		else
		{
			Application.LoadLevel(1);
		}
	}
}
