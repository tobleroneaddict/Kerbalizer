using System;
using Prime31;
using UnityEngine;

public class TwitterAndroidManager : MonoBehaviour
{
	public static event Action<string> loginDidSucceedEvent;

	public static event Action<string> loginDidFailEvent;

	public static event Action<object> requestSucceededEvent;

	public static event Action<string> requestFailedEvent;

	public static event Action twitterInitializedEvent;

	private void Awake()
	{
		base.gameObject.name = GetType().ToString();
		UnityEngine.Object.DontDestroyOnLoad(this);
	}

	public void loginDidSucceed(string username)
	{
		if (TwitterAndroidManager.loginDidSucceedEvent != null)
		{
			TwitterAndroidManager.loginDidSucceedEvent(username);
		}
	}

	public void loginDidFail(string error)
	{
		if (TwitterAndroidManager.loginDidFailEvent != null)
		{
			TwitterAndroidManager.loginDidFailEvent(error);
		}
	}

	public void requestSucceeded(string response)
	{
		if (TwitterAndroidManager.requestSucceededEvent != null)
		{
			TwitterAndroidManager.requestSucceededEvent(MiniJSON.jsonDecode(response));
		}
	}

	public void requestFailed(string error)
	{
		if (TwitterAndroidManager.requestFailedEvent != null)
		{
			TwitterAndroidManager.requestFailedEvent(error);
		}
	}

	public void twitterInitialized(string empty)
	{
		if (TwitterAndroidManager.twitterInitializedEvent != null)
		{
			TwitterAndroidManager.twitterInitializedEvent();
		}
	}
}
