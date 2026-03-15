using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TwitterUIManager : MonoBehaviour
{
	public static string error;

	private void Start()
	{
		error = string.Empty;
	}

	private void OnGUI()
	{
		float num = 5f;
		float left = 5f;
		float num2 = ((Screen.width < 800 && Screen.height < 800) ? 160 : 320);
		float num3 = ((Screen.width < 800 && Screen.height < 800) ? 30 : 70);
		float num4 = num3 + 10f;
		if (GUI.Button(new Rect(left, num, num2, num3), "Initialize Twitter"))
		{
			TwitterAndroid.init("CQKjXuqXsU7lnUiC2nn1Hw", "n6AP9FsmBFQPg0vPBZtzC3KcclMg17HDfG6PLBZl2Y");
		}
		if (GUI.Button(new Rect(left, num += num4, num2, num3), "Login"))
		{
			TwitterAndroid.showLoginDialog();
		}
		if (GUI.Button(new Rect(left, num += num4, num2, num3), "Is Logged In?"))
		{
			bool flag = TwitterAndroid.isLoggedIn();
		}
		if (GUI.Button(new Rect(left, num += num4, num2, num3), "Post Update with Image"))
		{
			string path = Application.persistentDataPath + "/" + FacebookUIManager.screenshotFilename;
			byte[] image = File.ReadAllBytes(path);
			TwitterAndroid.postUpdateWithImage("test update from Unity!", image);
		}
		if (GUI.Button(new Rect(left, num += num4, num2, num3), "Facebook Scene"))
		{
			Application.LoadLevel("FacebookTestScene");
		}
		left = (float)Screen.width - num2 - 5f;
		num = 5f;
		if (GUI.Button(new Rect(left, num, num2, num3), "Logout"))
		{
			TwitterAndroid.logout();
		}
		if (GUI.Button(new Rect(left, num += num4, num2, num3), "Post Update"))
		{
			TwitterAndroid.postUpdate("im an update from the Twitter Android Plugin");
		}
		if (GUI.Button(new Rect(left, num += num4, num2, num3), "Get Home Timeline"))
		{
			TwitterAndroid.getHomeTimeline();
		}
		if (GUI.Button(new Rect(left, num += num4, num2, num3), "Get Followers"))
		{
			TwitterAndroid.getFollowers();
		}
		if (GUI.Button(new Rect(left, num += num4, num2, num3), "Custom Request"))
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("screen_name", "prime_31");
			dictionary.Add("test", "paramters");
			dictionary.Add("test2", "asdf");
			dictionary.Add("test3", "wer");
			dictionary.Add("test4", "vbn");
			TwitterAndroid.performRequest("get", "/1/users/show.json", dictionary);
		}
		GUI.Label(new Rect((float)Screen.width * 0.2f, (float)Screen.height * 0.2f, (float)Screen.width * 0.6f, (float)Screen.height * 0.6f), error);
	}
}
