using System;
using UnityEngine;

public class FacebookEventListener : MonoBehaviour
{
	private void OnEnable()
	{
		FacebookManager.loginSucceededEvent += facebookLogin;
		FacebookManager.loginFailedEvent += facebookLoginFailed;
		FacebookManager.loggedOutEvent += facebookDidLogoutEvent;
		FacebookManager.accessTokenExtendedEvent += facebookDidExtendTokenEvent;
		FacebookManager.sessionInvalidatedEvent += facebookSessionInvalidatedEvent;
		FacebookManager.dialogCompletedEvent += facebokDialogCompleted;
		FacebookManager.dialogCompletedWithUrlEvent += facebookDialogCompletedWithUrl;
		FacebookManager.dialogDidNotCompleteEvent += facebookDialogDidntComplete;
		FacebookManager.dialogFailedEvent += facebookDialogFailed;
		FacebookManager.customRequestReceivedEvent += facebookReceivedCustomRequest;
		FacebookManager.customRequestFailedEvent += facebookCustomRequestFailed;
		FacebookManager.facebookComposerCompletedEvent += facebookComposerCompletedEvent;
		FacebookManager.facebookReauthorizationWithReadPermissionsFailedEvent += facebookReauthorizationWithReadPermissionsFailedEvent;
		FacebookManager.facebookReauthorizationWithReadPermissionsSucceededEvent += facebookReauthorizationWithReadPermissionsSucceededEvent;
		FacebookManager.facebookReauthorizationWithPublishPermissionsFailedEvent += facebookReauthorizationWithPublishPermissionsFailedEvent;
		FacebookManager.facebookReauthorizationWithPublishPermissionsSucceededEvent += facebookReauthorizationWithPublishPermissionsSucceededEvent;
	}

	private void OnDisable()
	{
		FacebookManager.loginSucceededEvent -= facebookLogin;
		FacebookManager.loginFailedEvent -= facebookLoginFailed;
		FacebookManager.loggedOutEvent -= facebookDidLogoutEvent;
		FacebookManager.accessTokenExtendedEvent -= facebookDidExtendTokenEvent;
		FacebookManager.sessionInvalidatedEvent -= facebookSessionInvalidatedEvent;
		FacebookManager.dialogCompletedEvent -= facebokDialogCompleted;
		FacebookManager.dialogCompletedWithUrlEvent -= facebookDialogCompletedWithUrl;
		FacebookManager.dialogDidNotCompleteEvent -= facebookDialogDidntComplete;
		FacebookManager.dialogFailedEvent -= facebookDialogFailed;
		FacebookManager.customRequestReceivedEvent -= facebookReceivedCustomRequest;
		FacebookManager.customRequestFailedEvent -= facebookCustomRequestFailed;
		FacebookManager.facebookComposerCompletedEvent -= facebookComposerCompletedEvent;
		FacebookManager.facebookReauthorizationWithReadPermissionsFailedEvent -= facebookReauthorizationWithReadPermissionsFailedEvent;
		FacebookManager.facebookReauthorizationWithReadPermissionsSucceededEvent -= facebookReauthorizationWithReadPermissionsSucceededEvent;
		FacebookManager.facebookReauthorizationWithPublishPermissionsFailedEvent -= facebookReauthorizationWithPublishPermissionsFailedEvent;
		FacebookManager.facebookReauthorizationWithPublishPermissionsSucceededEvent -= facebookReauthorizationWithPublishPermissionsSucceededEvent;
	}

	private void facebookLogin()
	{
	}

	private void facebookLoginFailed(string error)
	{
	}

	private void facebookDidLogoutEvent()
	{
	}

	private void facebookDidExtendTokenEvent(DateTime newExpiry)
	{
	}

	private void facebookSessionInvalidatedEvent()
	{
	}

	private void facebokDialogCompleted()
	{
	}

	private void facebookDialogCompletedWithUrl(string url)
	{
	}

	private void facebookDialogDidntComplete()
	{
	}

	private void facebookDialogFailed(string error)
	{
	}

	private void facebookReceivedCustomRequest(object obj)
	{
	}

	private void facebookCustomRequestFailed(string error)
	{
	}

	private void facebookComposerCompletedEvent(bool didSucceed)
	{
	}

	private void facebookReauthorizationWithReadPermissionsFailedEvent(string error)
	{
	}

	private void facebookReauthorizationWithReadPermissionsSucceededEvent()
	{
	}

	private void facebookReauthorizationWithPublishPermissionsFailedEvent(string error)
	{
	}

	private void facebookReauthorizationWithPublishPermissionsSucceededEvent()
	{
	}
}
