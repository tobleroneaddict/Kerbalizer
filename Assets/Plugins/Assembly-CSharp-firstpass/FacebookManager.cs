using System;
using Prime31;
using UnityEngine;

public class FacebookManager : MonoBehaviour
{
	public static event Action loginSucceededEvent;

	public static event Action preLoginSucceededEvent;

	public static event Action<string> loginFailedEvent;

	public static event Action loggedOutEvent;

	public static event Action<DateTime> accessTokenExtendedEvent;

	public static event Action failedToExtendTokenEvent;

	public static event Action sessionInvalidatedEvent;

	public static event Action dialogCompletedEvent;

	public static event Action<string> dialogFailedEvent;

	public static event Action dialogDidNotCompleteEvent;

	public static event Action<string> dialogCompletedWithUrlEvent;

	public static event Action<object> customRequestReceivedEvent;

	public static event Action<string> customRequestFailedEvent;

	public static event Action<bool> facebookComposerCompletedEvent;

	public static event Action<string> facebookReauthorizationWithReadPermissionsFailedEvent;

	public static event Action facebookReauthorizationWithReadPermissionsSucceededEvent;

	public static event Action<string> facebookReauthorizationWithPublishPermissionsFailedEvent;

	public static event Action facebookReauthorizationWithPublishPermissionsSucceededEvent;

	private void Awake()
	{
		base.gameObject.name = GetType().ToString();
		UnityEngine.Object.DontDestroyOnLoad(this);
	}

	public void facebookLoginSucceeded(string empty)
	{
		if (FacebookManager.preLoginSucceededEvent != null)
		{
			FacebookManager.preLoginSucceededEvent();
		}
		if (FacebookManager.loginSucceededEvent != null)
		{
			FacebookManager.loginSucceededEvent();
		}
	}

	public void facebookLoginDidFail(string error)
	{
		if (FacebookManager.loginFailedEvent != null)
		{
			FacebookManager.loginFailedEvent(error);
		}
	}

	public void facebookDidLogout(string empty)
	{
		if (FacebookManager.loggedOutEvent != null)
		{
			FacebookManager.loggedOutEvent();
		}
	}

	public void facebookDidExtendToken(string secondsSinceEpoch)
	{
		if (FacebookManager.accessTokenExtendedEvent != null)
		{
			double value = double.Parse(secondsSinceEpoch);
			DateTime obj = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(value);
			FacebookManager.accessTokenExtendedEvent(obj);
		}
	}

	public void facebookFailedToExtendToken(string empty)
	{
		if (FacebookManager.failedToExtendTokenEvent != null)
		{
			FacebookManager.failedToExtendTokenEvent();
		}
	}

	public void facebookSessionInvalidated(string empty)
	{
		if (FacebookManager.sessionInvalidatedEvent != null)
		{
			FacebookManager.sessionInvalidatedEvent();
		}
	}

	public void facebookDialogDidComplete(string empty)
	{
		if (FacebookManager.dialogCompletedEvent != null)
		{
			FacebookManager.dialogCompletedEvent();
		}
	}

	public void facebookDialogDidCompleteWithUrl(string url)
	{
		if (FacebookManager.dialogCompletedWithUrlEvent != null)
		{
			FacebookManager.dialogCompletedWithUrlEvent(url);
		}
	}

	public void facebookDialogDidNotComplete(string empty)
	{
		if (FacebookManager.dialogDidNotCompleteEvent != null)
		{
			FacebookManager.dialogDidNotCompleteEvent();
		}
	}

	public void facebookDialogDidFailWithError(string error)
	{
		if (FacebookManager.dialogFailedEvent != null)
		{
			FacebookManager.dialogFailedEvent(error);
		}
	}

	public void facebookDidReceiveCustomRequest(string result)
	{
		if (FacebookManager.customRequestReceivedEvent != null)
		{
			object obj = MiniJSON.jsonDecode(result);
			FacebookManager.customRequestReceivedEvent(obj);
		}
	}

	public void facebookCustomRequestDidFail(string error)
	{
		if (FacebookManager.customRequestFailedEvent != null)
		{
			FacebookManager.customRequestFailedEvent(error);
		}
	}

	public void facebookComposerCompleted(string result)
	{
		if (FacebookManager.facebookComposerCompletedEvent != null)
		{
			FacebookManager.facebookComposerCompletedEvent(result == "1");
		}
	}

	public void facebookReauthorizationWithReadPermissionsFailed(string error)
	{
		if (FacebookManager.facebookReauthorizationWithReadPermissionsFailedEvent != null)
		{
			FacebookManager.facebookReauthorizationWithReadPermissionsFailedEvent(error);
		}
	}

	public void facebookReauthorizationWithReadPermissionsSucceeded(string empty)
	{
		if (FacebookManager.facebookReauthorizationWithReadPermissionsSucceededEvent != null)
		{
			FacebookManager.facebookReauthorizationWithReadPermissionsSucceededEvent();
		}
	}

	public void facebookReauthorizationWithPublishPermissionsFailed(string error)
	{
		if (FacebookManager.facebookReauthorizationWithPublishPermissionsFailedEvent != null)
		{
			FacebookManager.facebookReauthorizationWithPublishPermissionsFailedEvent(error);
		}
	}

	public void facebookReauthorizationWithPublishPermissionsSucceeded(string empty)
	{
		if (FacebookManager.facebookReauthorizationWithPublishPermissionsSucceededEvent != null)
		{
			FacebookManager.facebookReauthorizationWithPublishPermissionsSucceededEvent();
		}
	}
}
