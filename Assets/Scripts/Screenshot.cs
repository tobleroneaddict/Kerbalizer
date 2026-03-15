using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
	public RenderTexture screenShot;

	private Texture2D tmpTexture;

	public static string mail = string.Empty;

	private int idImage;

	private string ref_link_screenshot_loader = "http://www.kerbalspaceport.com/avatarkerbal/loader.php";

	private string ref_link_screenshot_download = "http://www.kerbalspaceport.com/avatarkerbal/download.php";

	private string ref_link_screenshot_email = "http://www.kerbalspaceport.com/avatarkerbal/downloadAndSend.php";

	private string pathScreenShots = "http://www.kerbalspaceport.com/avatarkerbal/ScreenShots/";

	private void completionHandler(string error, object result)
	{
		if (error == null)
		{
			ResultLogger.logObject(result);
		}
	}

	private void Start()
	{
		tmpTexture = new Texture2D(screenShot.width, screenShot.height, TextureFormat.RGB24, false);
		FacebookAndroid.init("488090144556144");
	}

	private IEnumerator UploadPNGToFacebook()
	{
		HUD.enable = false;
		yield return new WaitForEndOfFrame();
		int width = Mathf.CeilToInt((float)Screen.width * 0.55f);
		int height = Mathf.CeilToInt((float)Screen.height * 0.85f);
		Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
		tex.ReadPixels(new Rect((float)Screen.width * 0.285f, (float)Screen.height * 0.15f, width, height), 0, 0);
		tex.SetPixel(0, 0, Color.white);
		tex.Apply();
		HUD.enable = true;
		HUD.isProcesing = true;
		byte[] bytes = tex.EncodeToPNG();
		UnityEngine.Object.Destroy(tex);
		WWWForm form = new WWWForm();
		if (idImage == 0)
		{
			int nb1 = UnityEngine.Random.Range(9, 99);
			int nb2 = UnityEngine.Random.Range(0, 9);
			int nb3 = UnityEngine.Random.Range(100, 999);
			string s_idImage = nb1.ToString() + nb2 + nb3;
			idImage = int.Parse(s_idImage);
		}
		string s_name = idImage + "_-_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
		s_name += ".png";
		form.AddField("frameCount", Time.frameCount.ToString());
		form.AddBinaryData("file", bytes, s_name, "image/png");
		WWW w = new WWW(ref_link_screenshot_loader, form);
		yield return w;
		if (w.error != null)
		{
			Application.ExternalCall("MessageError", w.error);
			HUD.isProcesing = false;
		}
		else
		{
			Application.ExternalCall("PostFeed", s_name);
			HUD.isProcesing = false;
		}
	}

	private IEnumerator UploadPNGToTwitter()
	{
		HUD.enable = false;
		yield return new WaitForEndOfFrame();
		int width = Screen.width;
		int height = Screen.height;
		Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
		tex.ReadPixels(new Rect(0f, 0f, width, height), 0, 0);
		tex.SetPixel(0, 0, Color.white);
		tex.Apply();
		HUD.enable = true;
		HUD.isProcesing = true;
		byte[] bytes = tex.EncodeToPNG();
		UnityEngine.Object.Destroy(tex);
		WWWForm form = new WWWForm();
		if (idImage == 0)
		{
			int nb1 = UnityEngine.Random.Range(9, 99);
			int nb2 = UnityEngine.Random.Range(0, 9);
			int nb3 = UnityEngine.Random.Range(100, 999);
			string s_idImage = nb1.ToString() + nb2 + nb3;
			idImage = int.Parse(s_idImage);
		}
		string s_name = idImage + "_-_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
		s_name += ".png";
		form.AddField("frameCount", Time.frameCount.ToString());
		form.AddBinaryData("file", bytes, s_name, "image/png");
		WWW w = new WWW(ref_link_screenshot_loader, form);
		yield return w;
		if (w.error != null)
		{
			Application.ExternalCall("MessageError", w.error);
		}
		else
		{
			Application.ExternalCall("PostTwitt", s_name);
			HUD.isProcesing = false;
		}
	}

	private IEnumerator UploadPNGToDownload()
	{
		HUD.enable = false;
		yield return new WaitForEndOfFrame();
		int width = Mathf.CeilToInt((float)Screen.width * 0.5f);
		int height = Mathf.CeilToInt((float)Screen.height * 0.8f);
		Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
		tex.ReadPixels(new Rect((float)Screen.width * 0.3f, 0f, width, height), 0, 0);
		tex.SetPixel(0, 0, Color.white);
		tex.Apply();
		HUD.enable = true;
		HUDEZ.isProcesing = true;
		byte[] bytes = tex.EncodeToPNG();
		UnityEngine.Object.Destroy(tex);
		WWWForm form = new WWWForm();
		if (idImage == 0)
		{
			int nb1 = UnityEngine.Random.Range(9, 99);
			int nb2 = UnityEngine.Random.Range(0, 9);
			int nb3 = UnityEngine.Random.Range(100, 999);
			string s_idImage = nb1.ToString() + nb2 + nb3;
			idImage = int.Parse(s_idImage);
		}
		string s_name = idImage + "_-_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
		s_name += ".png";
		RenderTexture.active = screenShot;
		tmpTexture.ReadPixels(new Rect(0f, 0f, screenShot.width, screenShot.height), 0, 0);
		tmpTexture.Apply();
		form.AddBinaryData("file", tmpTexture.EncodeToPNG(), s_name, "image/png");
		WWW w = new WWW(ref_link_screenshot_download, form);
		yield return w;
		if (w.error != null)
		{
			Application.ExternalCall("MessageError", w.error);
			yield break;
		}
		Application.ExternalCall("Download", s_name);
		HUDEZ.isProcesing = false;
		HUDEZ.changeShareButState("emailBut", 0);
	}

	private IEnumerator UploadPNGToMail()
	{
		HUD.enable = false;
		yield return new WaitForEndOfFrame();
		int width = Mathf.CeilToInt((float)Screen.width * 0.55f);
		int height = Mathf.CeilToInt((float)Screen.height * 0.85f);
		Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
		tex.ReadPixels(new Rect((float)Screen.width * 0.285f, (float)Screen.height * 0.15f, width, height), 0, 0);
		tex.SetPixel(0, 0, Color.white);
		tex.Apply();
		HUD.enable = true;
		HUD.isProcesing = true;
		byte[] bytes = tex.EncodeToPNG();
		UnityEngine.Object.Destroy(tex);
		WWWForm form = new WWWForm();
		if (idImage == 0)
		{
			int nb1 = UnityEngine.Random.Range(9, 99);
			int nb2 = UnityEngine.Random.Range(0, 9);
			int nb3 = UnityEngine.Random.Range(100, 999);
			string s_idImage = nb1.ToString() + nb2 + nb3;
			idImage = int.Parse(s_idImage);
		}
		string s_name = idImage + "_-_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
		s_name += ".png";
		form.AddField("frameCount", Time.frameCount.ToString());
		form.AddBinaryData("file", bytes, s_name, "image/png");
		WWW w = new WWW(ref_link_screenshot_loader, form);
		yield return w;
		if (w.error != null)
		{
			Application.ExternalCall("MessageError", w.error);
			yield break;
		}
		Application.ExternalCall("Mail", "kerbalizer/Screenshots/" + s_name, mail);
		HUD.isProcesing = false;
	}

	private IEnumerator PostToFacebook()
	{
		HUDEZ.isProcesing = true;
		yield return new WaitForEndOfFrame();
		WWWForm form = new WWWForm();
		if (idImage == 0)
		{
			int nb1 = UnityEngine.Random.Range(9, 99);
			int nb2 = UnityEngine.Random.Range(0, 9);
			int nb3 = UnityEngine.Random.Range(100, 999);
			string s_idImage = nb1.ToString() + nb2 + nb3;
			idImage = int.Parse(s_idImage);
		}
		string s_name = idImage + "_-_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
		s_name += ".png";
		RenderTexture.active = screenShot;
		tmpTexture.ReadPixels(new Rect(0f, 0f, screenShot.width, screenShot.height), 0, 0);
		tmpTexture.Apply();
		form.AddField("frameCount", Time.frameCount.ToString());
		form.AddBinaryData("file", tmpTexture.EncodeToPNG(), s_name, "image/png");
		WWW w = new WWW(ref_link_screenshot_download, form);
		yield return w;
		if (w.error != null)
		{
			Application.ExternalCall("MessageError", w.error);
			HUDEZ.isProcesing = false;
		}
		else
		{
			FacebookAndroid.showPostMessageDialogWithOptions(pathScreenShots + s_name, "A kerbalized creation", pathScreenShots + s_name, " The Kerbal");
			HUDEZ.isProcesing = false;
			HUDEZ.changeShareButState("fbButton", 0);
		}
	}

	private IEnumerator SendToEmail()
	{
		HUDEZ.isProcesing = true;
		yield return new WaitForEndOfFrame();
		WWWForm form = new WWWForm();
		if (idImage == 0)
		{
			int nb1 = UnityEngine.Random.Range(9, 99);
			int nb2 = UnityEngine.Random.Range(0, 9);
			int nb3 = UnityEngine.Random.Range(100, 999);
			string s_idImage = nb1.ToString() + nb2 + nb3;
			idImage = int.Parse(s_idImage);
		}
		string s_name = idImage + "_-_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
		s_name += ".png";
		RenderTexture.active = screenShot;
		tmpTexture.ReadPixels(new Rect(0f, 0f, screenShot.width, screenShot.height), 0, 0);
		tmpTexture.Apply();
		form.AddField("frameCount", Time.frameCount.ToString());
		form.AddBinaryData("file", tmpTexture.EncodeToPNG(), s_name, "image/png");
		WWW w = new WWW(ref_link_screenshot_download, form);
		yield return w;
		if (w.error != null)
		{
			Application.ExternalCall("MessageError", w.error);
			HUDEZ.isProcesing = false;
			yield break;
		}
		WWWForm mailForm = new WWWForm();
		mailForm.AddField("i", "ScreenShots/" + s_name);
		mailForm.AddField("email", mail);
		WWW sendMail = new WWW(ref_link_screenshot_email, mailForm);
		yield return sendMail;
		if (sendMail.error != null)
		{
			Debug.Log("error sending mail: " + sendMail.error);
		}
		else
		{
			Debug.Log("That's ok: " + sendMail.text);
		}
		HUDEZ.isProcesing = false;
		HUDEZ.changeShareButState("emailBut", 0);
	}

	private IEnumerator DownloadToDevice()
	{
		HUDEZ.isProcesing = true;
		yield return new WaitForEndOfFrame();
		WWWForm form = new WWWForm();
		if (idImage == 0)
		{
			int nb1 = UnityEngine.Random.Range(9, 99);
			int nb2 = UnityEngine.Random.Range(0, 9);
			int nb3 = UnityEngine.Random.Range(100, 999);
			string s_idImage = nb1.ToString() + nb2 + nb3;
			idImage = int.Parse(s_idImage);
		}
		string s_name = idImage + "_-_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
		s_name += ".png";
		RenderTexture.active = screenShot;
		tmpTexture.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height), 0, 0);
		tmpTexture.Apply();
		File.WriteAllBytes(bytes: tmpTexture.EncodeToPNG(), path: "/sdcard/DCIM/Camera/" + s_name);
		yield return new WaitForSeconds(2f);
		HUDEZ.changeShareButState("dlButton", 0);
		HUDEZ.isProcesing = false;
	}

	public void TakeScreenShot(TypeSocialMedia type)
	{
		switch (type)
		{
		case TypeSocialMedia.FACEBOOK:
			StartCoroutine(UploadPNGToFacebook());
			break;
		case TypeSocialMedia.TWITTER:
			StartCoroutine(UploadPNGToTwitter());
			break;
		case TypeSocialMedia.DOWNLOAD:
			StartCoroutine(UploadPNGToDownload());
			break;
		case TypeSocialMedia.MAIL:
			StartCoroutine(UploadPNGToDownload());
			break;
		}
	}

	public void TakeScreenShotMobile(TypeSocialMedia type)
	{
		switch (type)
		{
		case TypeSocialMedia.FACEBOOK:
			StartCoroutine(PostToFacebook());
			break;
		case TypeSocialMedia.MAIL:
			StartCoroutine(SendToEmail());
			break;
		case TypeSocialMedia.DOWNLOAD:
			StartCoroutine(DownloadToDevice());
			break;
		case TypeSocialMedia.TWITTER:
			break;
		}
	}
}
