using UnityEngine;

public class HUDEZ : MonoBehaviour
{
	public previewThumbnail[] previews;

	public static HUDEZ thisHUD;

	public EditorContent editorContent;

	public EditorControl editorControl;

	public AnimationControl animControl;

	private ChangeType changeType;

	public Texture[] hairPreview;

	public Texture[] topPreview;

	public Texture[] bottomPreview;

	public Texture[] feetPreview;

	public Texture[] accsPreview;

	public Texture[] facialDetailsPreview;

	public Texture[] backsPreview;

	public Texture[] expressionsPreview;

	public Texture[] overallsPreview;

	private int pgIndex;

	private int hairSectionIndex;

	private int facialDetailsSectionIndex;

	private int topSectionIndex;

	private int bottomSectionIndex;

	private int shoesSectionIndex;

	private int accesoriesSectionIndex;

	private int hairIndex;

	private int facialDetailsIndex;

	private int topIndex;

	private int bottomIndex;

	private int shoesIndex;

	private int accesoriesIndex;

	private int backgroundIndex;

	private int backgroundSectionIndex;

	private int facialExpressionsIndex;

	private int facialExpressionsSectionIndex;

	private int overallsIndex;

	private int overallsSectionIndex;

	private int indexSectionTypeControl;

	private string email;

	public static bool enable;

	public static bool isProcesing;

	private float nativeHorizontalResolution;

	private float nativeVerticalResolution;

	private int currentSet;

	public UIButton hairTab;

	public UIButton faceTab;

	public UIButton topTab;

	public UIButton botTab;

	public UIButton feetTab;

	public UIButton accsTab;

	public UIButton expTab;

	public UIButton backTab;

	public UIButton overallTab;

	public UIButton prevBut;

	public UIButton nextBut;

	public UIButton prevTabBut;

	public UIButton nextTabBut;

	public MeshRenderer processing;

	public UIButton preview1;

	public UIButton preview2;

	public UIButton preview3;

	public UIButton preview4;

	public UIButton preview5;

	public UIButton preview6;

	public UIButton preview7;

	public UIButton preview8;

	public UIButton preview9;

	public UIButton preview10;

	public UIButton preview11;

	public UIButton preview12;

	public Transform firstTab;

	public Transform secondTab;

	public Transform thirdTab;

	public Transform playPauseBut;

	public Vector3 laVerga;

	public UIButton playBut;

	public UIButton pauseBut;

	public UISlider animationSlider;

	public UIButton resetBut;

	public UIButton undoBut;

	public UIButton fbButton;

	public UIButton emailBut;

	public UITextField emailTextField;

	public UIButton sendBut;

	public UIButton dismissBut;

	public UIButton downloadBut;

	private float maxPages;

	private int maxTimes;

	private bool multiplePages;

	private UIButton currentActiveBut;

	private void Start()
	{
		thisHUD = base.gameObject.GetComponent<HUDEZ>();
		changeType = ChangeType.FACIAL_DETAILS;
		currentActiveBut = faceTab;
		currentActiveBut.SetState(2);
		prevTabBut.SetState(3);
		pgIndex = 0;
		isProcesing = false;
		emailTextField.gameObject.SetActive(false);
		hairTab.SetValueChangedDelegate(editorChangedDel);
		faceTab.SetValueChangedDelegate(editorChangedDel);
		topTab.SetValueChangedDelegate(editorChangedDel);
		botTab.SetValueChangedDelegate(editorChangedDel);
		feetTab.SetValueChangedDelegate(editorChangedDel);
		accsTab.SetValueChangedDelegate(editorChangedDel);
		expTab.SetValueChangedDelegate(editorChangedDel);
		backTab.SetValueChangedDelegate(editorChangedDel);
		overallTab.SetValueChangedDelegate(editorChangedDel);
		prevBut.SetValueChangedDelegate(editorChangedDel);
		nextBut.SetValueChangedDelegate(editorChangedDel);
		prevTabBut.SetValueChangedDelegate(editorChangedDel);
		nextTabBut.SetValueChangedDelegate(editorChangedDel);
		preview1.SetValueChangedDelegate(editorChangedDel);
		preview2.SetValueChangedDelegate(editorChangedDel);
		preview3.SetValueChangedDelegate(editorChangedDel);
		preview4.SetValueChangedDelegate(editorChangedDel);
		preview5.SetValueChangedDelegate(editorChangedDel);
		preview6.SetValueChangedDelegate(editorChangedDel);
		preview7.SetValueChangedDelegate(editorChangedDel);
		preview8.SetValueChangedDelegate(editorChangedDel);
		preview9.SetValueChangedDelegate(editorChangedDel);
		preview10.SetValueChangedDelegate(editorChangedDel);
		preview11.SetValueChangedDelegate(editorChangedDel);
		preview12.SetValueChangedDelegate(editorChangedDel);
		playBut.SetValueChangedDelegate(editorChangedDel);
		pauseBut.SetValueChangedDelegate(editorChangedDel);
		animationSlider.AddValueChangedDelegate(editorChangedDel);
		resetBut.SetValueChangedDelegate(editorChangedDel);
		undoBut.SetValueChangedDelegate(editorChangedDel);
		fbButton.SetValueChangedDelegate(editorChangedDel);
		emailBut.SetValueChangedDelegate(editorChangedDel);
		dismissBut.SetValueChangedDelegate(editorChangedDel);
		sendBut.SetValueChangedDelegate(editorChangedDel);
		downloadBut.SetValueChangedDelegate(editorChangedDel);
		currentSet = 1;
		arrangeSets();
		maxPages = facialDetailsPreview.Length;
		maxTimes = (int)(maxPages / 12f);
		multiplePages = maxPages > 12f;
	}

	private void arrangeSets()
	{
		if (currentSet == 1)
		{
			faceTab.transform.position = firstTab.position;
			expTab.transform.position = secondTab.position;
			hairTab.transform.position = thirdTab.position;
			topTab.transform.position = laVerga;
			botTab.transform.position = laVerga;
			feetTab.transform.position = laVerga;
			backTab.transform.position = laVerga;
			overallTab.transform.position = laVerga;
			accsTab.transform.position = laVerga;
			prevTabBut.SetState(3);
			nextTabBut.SetState(0);
		}
		if (currentSet == 2)
		{
			faceTab.transform.position = laVerga;
			expTab.transform.position = laVerga;
			hairTab.transform.position = laVerga;
			topTab.transform.position = firstTab.position;
			botTab.transform.position = secondTab.position;
			feetTab.transform.position = thirdTab.position;
			backTab.transform.position = laVerga;
			overallTab.transform.position = laVerga;
			accsTab.transform.position = laVerga;
			prevTabBut.SetState(0);
			nextTabBut.SetState(0);
		}
		if (currentSet == 3)
		{
			faceTab.transform.position = laVerga;
			expTab.transform.position = laVerga;
			hairTab.transform.position = laVerga;
			topTab.transform.position = laVerga;
			botTab.transform.position = laVerga;
			feetTab.transform.position = laVerga;
			backTab.transform.position = thirdTab.position;
			overallTab.transform.position = firstTab.position;
			accsTab.transform.position = secondTab.position;
			prevTabBut.SetState(0);
			nextTabBut.SetState(3);
		}
	}

	private void Update()
	{
		currentActiveBut.SetState(2);
		if (maxPages < 1f && maxPages > 0f)
		{
			maxPages = 1f;
		}
		if (maxPages % 12f == 0f)
		{
			maxTimes = (int)(maxPages / 12f) - 1;
		}
		else
		{
			maxTimes = (int)(maxPages / 12f);
		}
		if ((float)pgIndex >= maxPages)
		{
			pgIndex = maxTimes * 12;
		}
		if (pgIndex < 0)
		{
			pgIndex = 0;
		}
		if (isProcesing)
		{
			processing.enabled = true;
		}
		else
		{
			processing.enabled = false;
		}
		switch (changeType)
		{
		case ChangeType.HAIR:
		{
			for (int j = pgIndex; j < 12 + pgIndex; j++)
			{
				if (j >= hairPreview.Length)
				{
					previews[j - pgIndex].transform.parent.gameObject.SetActive(false);
					continue;
				}
				previews[j - pgIndex].transform.parent.gameObject.SetActive(true);
				previews[j - pgIndex].changeTextureToShow(hairPreview[j]);
			}
			break;
		}
		case ChangeType.FACIAL_DETAILS:
		{
			for (int n = pgIndex; n < 12 + pgIndex; n++)
			{
				if (n >= facialDetailsPreview.Length)
				{
					previews[n - pgIndex].transform.parent.gameObject.SetActive(false);
					continue;
				}
				previews[n - pgIndex].transform.parent.gameObject.SetActive(true);
				previews[n - pgIndex].changeTextureToShow(facialDetailsPreview[n]);
			}
			break;
		}
		case ChangeType.SHOES:
		{
			for (int num2 = pgIndex; num2 < 12 + pgIndex; num2++)
			{
				if (num2 >= feetPreview.Length)
				{
					previews[num2 - pgIndex].transform.parent.gameObject.SetActive(false);
					continue;
				}
				previews[num2 - pgIndex].transform.parent.gameObject.SetActive(true);
				previews[num2 - pgIndex].changeTextureToShow(feetPreview[num2]);
			}
			break;
		}
		case ChangeType.ACCESORIES:
		{
			for (int l = pgIndex; l < 12 + pgIndex; l++)
			{
				if (l >= accsPreview.Length)
				{
					previews[l - pgIndex].transform.parent.gameObject.SetActive(false);
					continue;
				}
				previews[l - pgIndex].transform.parent.gameObject.SetActive(true);
				previews[l - pgIndex].changeTextureToShow(accsPreview[l]);
			}
			break;
		}
		case ChangeType.TOP:
		{
			for (int num3 = pgIndex; num3 < 12 + pgIndex; num3++)
			{
				if (num3 >= topPreview.Length)
				{
					previews[num3 - pgIndex].transform.parent.gameObject.SetActive(false);
					continue;
				}
				previews[num3 - pgIndex].transform.parent.gameObject.SetActive(true);
				previews[num3 - pgIndex].changeTextureToShow(topPreview[num3]);
			}
			break;
		}
		case ChangeType.BOTTOM:
		{
			for (int num = pgIndex; num < 12 + pgIndex; num++)
			{
				if (num >= bottomPreview.Length)
				{
					previews[num - pgIndex].transform.parent.gameObject.SetActive(false);
					continue;
				}
				previews[num - pgIndex].transform.parent.gameObject.SetActive(true);
				previews[num - pgIndex].changeTextureToShow(bottomPreview[num]);
			}
			break;
		}
		case ChangeType.BACKGROUND:
		{
			for (int m = pgIndex; m < 12 + pgIndex; m++)
			{
				if (m >= backsPreview.Length)
				{
					previews[m - pgIndex].transform.parent.gameObject.SetActive(false);
					continue;
				}
				previews[m - pgIndex].transform.parent.gameObject.SetActive(true);
				previews[m - pgIndex].changeTextureToShow(backsPreview[m]);
			}
			break;
		}
		case ChangeType.FACIAL_EXPRESSION:
		{
			for (int k = pgIndex; k < 12 + pgIndex; k++)
			{
				if (k >= expressionsPreview.Length)
				{
					previews[k - pgIndex].transform.parent.gameObject.SetActive(false);
					continue;
				}
				previews[k - pgIndex].transform.parent.gameObject.SetActive(true);
				previews[k - pgIndex].changeTextureToShow(expressionsPreview[k]);
			}
			break;
		}
		case ChangeType.OVERALL:
		{
			for (int i = pgIndex; i < 12 + pgIndex; i++)
			{
				if (i >= overallsPreview.Length)
				{
					previews[i - pgIndex].transform.parent.gameObject.SetActive(false);
					continue;
				}
				previews[i - pgIndex].transform.parent.gameObject.SetActive(true);
				previews[i - pgIndex].changeTextureToShow(overallsPreview[i]);
			}
			break;
		}
		}
	}

	private void resetPreviews()
	{
		preview1.SetState(0);
		preview2.SetState(0);
		preview3.SetState(0);
		preview4.SetState(0);
		preview5.SetState(0);
		preview6.SetState(0);
		preview7.SetState(0);
		preview8.SetState(0);
		preview9.SetState(0);
		preview10.SetState(0);
		preview11.SetState(0);
		preview12.SetState(0);
	}

	private void changeTheOutfit(int index)
	{
		resetPreviews();
		index += pgIndex;
		switch (changeType)
		{
		case ChangeType.FACIAL_DETAILS:
			editorControl.ChangeOutfitPro(ChangeType.FACIAL_DETAILS, index);
			break;
		case ChangeType.FACIAL_EXPRESSION:
			editorControl.ChangeOutfitPro(ChangeType.FACIAL_EXPRESSION, index);
			break;
		case ChangeType.HAIR:
			editorControl.ChangeOutfitPro(ChangeType.HAIR, index);
			break;
		case ChangeType.TOP:
			editorControl.ChangeOutfitPro(ChangeType.TOP, index);
			break;
		case ChangeType.BOTTOM:
			editorControl.ChangeOutfitPro(ChangeType.BOTTOM, index);
			break;
		case ChangeType.SHOES:
			editorControl.ChangeOutfitPro(ChangeType.SHOES, index);
			break;
		case ChangeType.OVERALL:
			editorControl.ChangeOutfitPro(ChangeType.OVERALL, index);
			break;
		case ChangeType.ACCESORIES:
			editorControl.ChangeOutfitPro(ChangeType.ACCESORIES, index);
			break;
		case ChangeType.BACKGROUND:
			editorControl.ChangeOutfitPro(ChangeType.BACKGROUND, index);
			break;
		}
	}

	public void setSilderVal(float val)
	{
		animationSlider.Value = val;
	}

	private void mailBox(string action)
	{
		switch (action)
		{
		case "show":
			emailTextField.gameObject.SetActive(true);
			break;
		case "dismiss":
			emailTextField.gameObject.SetActive(false);
			changeShareButState("emailBut", 0);
			break;
		case "send":
			Debug.Log("Is this right? " + emailTextField.Text);
			Screenshot.mail = emailTextField.Text;
			SendMessage("TakeScreenShotMobile", TypeSocialMedia.MAIL);
			emailTextField.gameObject.SetActive(false);
			break;
		}
	}

	public static void changeShareButState(string name, int state)
	{
		switch (name)
		{
		case "fbButton":
			thisHUD.fbButton.SetState(state);
			break;
		case "resetBut":
			thisHUD.resetBut.SetState(state);
			break;
		case "undoBut":
			thisHUD.undoBut.SetState(state);
			break;
		case "emailBut":
			thisHUD.emailBut.SetState(state);
			break;
		case "dlButton":
			thisHUD.downloadBut.SetState(state);
			break;
		}
	}

	private void editorChangedDel(IUIObject obj)
	{
		if (obj == hairTab)
		{
			currentActiveBut.SetState(0);
			resetPreviews();
			currentActiveBut = hairTab;
			currentActiveBut.SetState(2);
			changeType = ChangeType.HAIR;
			pgIndex = 0;
			maxPages = hairPreview.Length;
			previewThumbnail[] array = previews;
			foreach (previewThumbnail previewThumbnail2 in array)
			{
				previewThumbnail2.transform.parent.gameObject.SetActive(true);
			}
		}
		else if (obj == faceTab)
		{
			currentActiveBut.SetState(0);
			resetPreviews();
			currentActiveBut = faceTab;
			currentActiveBut.SetState(2);
			changeType = ChangeType.FACIAL_DETAILS;
			pgIndex = 0;
			maxPages = facialDetailsPreview.Length;
			previewThumbnail[] array2 = previews;
			foreach (previewThumbnail previewThumbnail3 in array2)
			{
				previewThumbnail3.transform.parent.gameObject.SetActive(true);
			}
		}
		else if (obj == topTab)
		{
			currentActiveBut.SetState(0);
			resetPreviews();
			currentActiveBut = topTab;
			currentActiveBut.SetState(2);
			changeType = ChangeType.TOP;
			pgIndex = 0;
			maxPages = topPreview.Length;
			previewThumbnail[] array3 = previews;
			foreach (previewThumbnail previewThumbnail4 in array3)
			{
				previewThumbnail4.transform.parent.gameObject.SetActive(true);
			}
		}
		else if (obj == botTab)
		{
			currentActiveBut.SetState(0);
			resetPreviews();
			currentActiveBut = botTab;
			currentActiveBut.SetState(2);
			changeType = ChangeType.BOTTOM;
			pgIndex = 0;
			maxPages = bottomPreview.Length;
			previewThumbnail[] array4 = previews;
			foreach (previewThumbnail previewThumbnail5 in array4)
			{
				previewThumbnail5.transform.parent.gameObject.SetActive(true);
			}
		}
		else if (obj == feetTab)
		{
			currentActiveBut.SetState(0);
			resetPreviews();
			currentActiveBut = feetTab;
			currentActiveBut.SetState(2);
			changeType = ChangeType.SHOES;
			pgIndex = 0;
			maxPages = feetPreview.Length;
			previewThumbnail[] array5 = previews;
			foreach (previewThumbnail previewThumbnail6 in array5)
			{
				previewThumbnail6.transform.parent.gameObject.SetActive(true);
			}
		}
		else if (obj == accsTab)
		{
			currentActiveBut.SetState(0);
			resetPreviews();
			currentActiveBut = accsTab;
			currentActiveBut.SetState(2);
			changeType = ChangeType.ACCESORIES;
			pgIndex = 0;
			maxPages = accsPreview.Length;
			previewThumbnail[] array6 = previews;
			foreach (previewThumbnail previewThumbnail7 in array6)
			{
				previewThumbnail7.transform.parent.gameObject.SetActive(true);
			}
		}
		else if (obj == backTab)
		{
			currentActiveBut.SetState(0);
			resetPreviews();
			currentActiveBut = backTab;
			currentActiveBut.SetState(2);
			changeType = ChangeType.BACKGROUND;
			pgIndex = 0;
			maxPages = backsPreview.Length;
			previewThumbnail[] array7 = previews;
			foreach (previewThumbnail previewThumbnail8 in array7)
			{
				previewThumbnail8.transform.parent.gameObject.SetActive(true);
			}
		}
		else if (obj == overallTab)
		{
			currentActiveBut.SetState(0);
			resetPreviews();
			currentActiveBut = overallTab;
			currentActiveBut.SetState(2);
			changeType = ChangeType.OVERALL;
			pgIndex = 0;
			maxPages = overallsPreview.Length;
			previewThumbnail[] array8 = previews;
			foreach (previewThumbnail previewThumbnail9 in array8)
			{
				previewThumbnail9.transform.parent.gameObject.SetActive(true);
			}
		}
		else if (obj == expTab)
		{
			currentActiveBut.SetState(0);
			resetPreviews();
			currentActiveBut = expTab;
			currentActiveBut.SetState(2);
			changeType = ChangeType.FACIAL_EXPRESSION;
			pgIndex = 0;
			maxPages = expressionsPreview.Length;
			previewThumbnail[] array9 = previews;
			foreach (previewThumbnail previewThumbnail10 in array9)
			{
				previewThumbnail10.transform.parent.gameObject.SetActive(true);
			}
		}
		else if (obj == prevBut)
		{
			if (pgIndex >= 0)
			{
				pgIndex -= 12;
			}
		}
		else if (obj == nextBut)
		{
			multiplePages = maxPages > 12f;
			if (multiplePages)
			{
				pgIndex += 12;
			}
		}
		else if (obj == nextTabBut)
		{
			if (currentSet < 3)
			{
				currentSet++;
			}
			arrangeSets();
		}
		else if (obj == prevTabBut)
		{
			if (currentSet > 1)
			{
				currentSet--;
			}
			arrangeSets();
		}
		else if (obj == preview1)
		{
			changeTheOutfit(0);
			preview1.SetState(2);
		}
		else if (obj == preview2)
		{
			changeTheOutfit(1);
			preview2.SetState(2);
		}
		else if (obj == preview3)
		{
			changeTheOutfit(2);
			preview3.SetState(2);
		}
		else if (obj == preview4)
		{
			changeTheOutfit(3);
			preview4.SetState(2);
		}
		else if (obj == preview5)
		{
			changeTheOutfit(4);
			preview5.SetState(2);
		}
		else if (obj == preview6)
		{
			changeTheOutfit(5);
			preview6.SetState(2);
		}
		else if (obj == preview7)
		{
			changeTheOutfit(6);
			preview7.SetState(2);
		}
		else if (obj == preview8)
		{
			changeTheOutfit(7);
			preview8.SetState(2);
		}
		else if (obj == preview9)
		{
			changeTheOutfit(8);
			preview9.SetState(2);
		}
		else if (obj == preview10)
		{
			changeTheOutfit(9);
			preview10.SetState(2);
		}
		else if (obj == preview11)
		{
			changeTheOutfit(10);
			preview11.SetState(2);
		}
		else if (obj == preview12)
		{
			changeTheOutfit(11);
			preview12.SetState(2);
		}
		else if (obj == pauseBut)
		{
			pauseBut.transform.position = laVerga;
			playBut.transform.position = playPauseBut.position;
			animControl.UIControl("play");
		}
		else if (obj == playBut)
		{
			playBut.transform.position = laVerga;
			pauseBut.transform.position = playPauseBut.position;
			animControl.UIControl("pause");
			animationSlider.Value = 0f;
		}
		else if (obj == animationSlider)
		{
			animControl.sliderValueChanged(animationSlider.Value);
		}
		else if (obj == fbButton)
		{
			changeShareButState("fbButton", 2);
			SendMessage("TakeScreenShotMobile", TypeSocialMedia.FACEBOOK);
		}
		else if (obj == resetBut)
		{
			changeShareButState("resetBut", 2);
			resetPreviews();
			editorControl.ResetAll();
		}
		else if (obj == undoBut)
		{
			changeShareButState("undoBut", 2);
			resetPreviews();
			editorControl.ResetOutfitPro(changeType);
		}
		else if (obj == emailBut)
		{
			changeShareButState("emailBut", 2);
			mailBox("show");
		}
		else if (obj == sendBut)
		{
			mailBox("send");
		}
		else if (obj == dismissBut)
		{
			mailBox("dismiss");
		}
		else if (obj == downloadBut)
		{
			changeShareButState("dlButton", 2);
			SendMessage("TakeScreenShotMobile", TypeSocialMedia.DOWNLOAD);
		}
	}
}
