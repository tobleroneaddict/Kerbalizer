using UnityEngine;

public class TwitterAndroidEventListener : MonoBehaviour
{
	private void OnEnable()
	{
		TwitterAndroidManager.loginDidSucceedEvent += loginDidSucceedEvent;
		TwitterAndroidManager.loginDidFailEvent += loginDidFailEvent;
		TwitterAndroidManager.requestSucceededEvent += requestSucceededEvent;
		TwitterAndroidManager.requestFailedEvent += requestFailedEvent;
		TwitterAndroidManager.twitterInitializedEvent += twitterInitializedEvent;
	}

	private void OnDisable()
	{
		TwitterAndroidManager.loginDidSucceedEvent -= loginDidSucceedEvent;
		TwitterAndroidManager.loginDidFailEvent -= loginDidFailEvent;
		TwitterAndroidManager.requestSucceededEvent -= requestSucceededEvent;
		TwitterAndroidManager.requestFailedEvent -= requestFailedEvent;
		TwitterAndroidManager.twitterInitializedEvent -= twitterInitializedEvent;
	}

	private void loginDidSucceedEvent(string username)
	{
	}

	private void loginDidFailEvent(string error)
	{
	}

	private void requestSucceededEvent(object response)
	{
		ResultLogger.logObject(response);
	}

	private void requestFailedEvent(string error)
	{
	}

	private void twitterInitializedEvent()
	{
	}
}
