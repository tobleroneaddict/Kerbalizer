using UnityEngine;

public class HUDMobile : MonoBehaviour
{
	public float sharingGroupPercentWidth;

	public float sharingGroupPercentHeight;

	public float editorOptionsPercentWidth;

	public float editorOptionsPercentHeight;

	public float editorTypeControlPercentWidth;

	public float editorTypeControlPercentHeight;

	public EditorContent editorContent;

	public EditorControl editorControl;

	public Texture[] hairThumbnails;

	public Texture[] topThumbnails;

	public Texture[] bottomThumbnails;

	public Texture[] shoesThumbnails;

	public Texture[] accesoriesThumbnails;

	public Texture[] facialDetailsThumbnails;

	public Texture[] hairProThumbnails;

	public Texture[] topProThumbnails;

	public Texture[] bottomProThumbnails;

	public Texture[] shoesProThumbnails;

	public Texture[] accesoriesProThumbnails;

	public Texture[] facialDetailsProThumbnails;

	public Texture[] backgroundProThumbnails;

	public Texture[] expressionsProThumbnails;

	public Texture[] overallsThumbnails;

	public Texture procesing;

	public Texture editorArrowLeftActive;

	public Texture editorArrowLeftDesactive;

	public Texture editorArrowRightActive;

	public Texture editorArrowRightDesactive;

	public GUISkin style;

	private Rect editorRect;

	private Rect sharingGroup;

	private Rect editorOptionsGroup;

	private Rect editorTypeControlGroup;

	private Rect buttonChangeType1;

	private Rect buttonTypeControl1;

	private Rect buttonTypeControl2;

	private Rect buttonTypeControl3;

	private Rect buttonTypeControl4;

	private Rect buttonTypeControl5;

	private Rect buttonTypeControl6;

	private Rect buttonTypeControl7;

	private Rect buttonTypeControl8;

	private Rect socialRect;

	private Rect buttonReset;

	private Rect buttonFacebook;

	private Rect buttonTwitter;

	private Rect buttonUndo;

	private Rect buttonMail;

	private Rect buttonDownload;

	private Rect buttonNext;

	private Rect buttonPrev;

	private Rect buttonLine1;

	private Rect buttonLine2;

	private Rect buttonLine3;

	private Rect buttonLine4;

	private Rect buttonLine5;

	private Rect buttonLine6;

	private Rect buttonLine7;

	private Rect procesingRect;

	private Rect textAreaRect;

	private Rect sendButtonRect;

	private Rect editorArrowLeft;

	private Rect editorArrowRight;

	private ChangeType changeType;

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

	private bool showMailBox;

	public static bool isProcesing;

	public bool isPro;

	private float nativeHorizontalResolution;

	private float nativeVerticalResolution;

	private void SetRects()
	{
		sharingGroup = new Rect(nativeHorizontalResolution - nativeHorizontalResolution * sharingGroupPercentWidth * 0.01f, nativeVerticalResolution - nativeVerticalResolution * sharingGroupPercentHeight * 0.01f, nativeHorizontalResolution * sharingGroupPercentWidth * 0.01f, nativeVerticalResolution * sharingGroupPercentHeight * 0.01f);
		editorOptionsGroup = new Rect(nativeHorizontalResolution * 0.04f, nativeVerticalResolution * 0.12f, nativeHorizontalResolution * editorOptionsPercentWidth * 0.01f, nativeVerticalResolution * editorOptionsPercentHeight * 0.01f);
		editorTypeControlGroup = new Rect(nativeHorizontalResolution * 0.01f, nativeVerticalResolution * 0.01f, nativeHorizontalResolution * editorTypeControlPercentWidth * 0.01f, nativeVerticalResolution * editorTypeControlPercentHeight * 0.01f);
		buttonChangeType1 = new Rect(0f, 0f, 0f, 0f);
		editorRect = new Rect(nativeHorizontalResolution * 0.01f, nativeVerticalResolution * 0.01f, nativeHorizontalResolution * editorTypeControlPercentWidth * 0.01f + nativeHorizontalResolution * 0.016f, nativeVerticalResolution * 0.98f);
		buttonTypeControl1 = new Rect(0f, 0f, editorTypeControlGroup.width * 0.18f, editorTypeControlGroup.height);
		buttonTypeControl2 = new Rect(editorTypeControlGroup.width * 0.18f, 0f, editorTypeControlGroup.width * 0.18f, editorTypeControlGroup.height);
		buttonTypeControl3 = new Rect(editorTypeControlGroup.width * 0.36f, 0f, editorTypeControlGroup.width * 0.18f, editorTypeControlGroup.height);
		buttonTypeControl4 = new Rect(editorTypeControlGroup.width * 0.54f, 0f, editorTypeControlGroup.width * 0.18f, editorTypeControlGroup.height);
		buttonTypeControl5 = new Rect(editorTypeControlGroup.width * 0.5f, 0f, editorTypeControlGroup.width * 0.25f, editorTypeControlGroup.height);
		buttonTypeControl6 = new Rect(editorTypeControlGroup.width * 0.625f, 0f, editorTypeControlGroup.width * 0.125f, editorTypeControlGroup.height);
		buttonTypeControl7 = new Rect(editorTypeControlGroup.width * 0.75f, 0f, editorTypeControlGroup.width * 0.125f, editorTypeControlGroup.height);
		buttonTypeControl8 = new Rect(editorTypeControlGroup.width * 0.875f, 0f, editorTypeControlGroup.width * 0.125f, editorTypeControlGroup.height);
		buttonLine1 = new Rect(editorTypeControlGroup.width * 0.18f, editorTypeControlGroup.height * 0.05f, editorTypeControlGroup.width * 0.005f, editorTypeControlGroup.height);
		buttonLine2 = new Rect(editorTypeControlGroup.width * 0.36f, editorTypeControlGroup.height * 0.05f, editorTypeControlGroup.width * 0.005f, editorTypeControlGroup.height);
		buttonLine3 = new Rect(editorTypeControlGroup.width * 0.54f, editorTypeControlGroup.height * 0.05f, editorTypeControlGroup.width * 0.005f, editorTypeControlGroup.height);
		buttonLine4 = new Rect(editorTypeControlGroup.width * 0.865f, editorTypeControlGroup.height * 0.05f, editorTypeControlGroup.width * 0.005f, editorTypeControlGroup.height);
		buttonLine5 = new Rect(editorTypeControlGroup.width * 0.625f, editorTypeControlGroup.height * 0.05f, editorTypeControlGroup.width * 0.005f, editorTypeControlGroup.height);
		buttonLine6 = new Rect(editorTypeControlGroup.width * 0.75f, editorTypeControlGroup.height * 0.05f, editorTypeControlGroup.width * 0.005f, editorTypeControlGroup.height);
		buttonLine7 = new Rect(editorTypeControlGroup.width * 0.875f, editorTypeControlGroup.height * 0.05f, editorTypeControlGroup.width * 0.005f, editorTypeControlGroup.height);
		editorArrowLeft = new Rect(editorTypeControlGroup.width * 0.75f, 0f, editorTypeControlGroup.width * 0.1f, editorTypeControlGroup.height);
		editorArrowRight = new Rect(editorTypeControlGroup.width * 0.89f, 0f, editorTypeControlGroup.width * 0.1f, editorTypeControlGroup.height);
		buttonPrev = new Rect(nativeHorizontalResolution * 0.29f, nativeVerticalResolution * 0.88f, nativeHorizontalResolution * 0.015f, nativeVerticalResolution * 0.045f);
		buttonNext = new Rect(nativeHorizontalResolution * 0.308f, nativeVerticalResolution * 0.88f, nativeHorizontalResolution * 0.015f, nativeVerticalResolution * 0.045f);
		socialRect = new Rect(sharingGroup.width * 0.02f, sharingGroup.height * 0.5f, sharingGroup.width * 0.54f, sharingGroup.height * 0.28f);
		buttonUndo = new Rect(sharingGroup.width * 0.05f, sharingGroup.height * 0.5f, sharingGroup.width * 0.5f, sharingGroup.height * 0.07f);
		buttonReset = new Rect(sharingGroup.width * 0.05f, sharingGroup.height * 0.57f, sharingGroup.width * 0.5f, sharingGroup.height * 0.07f);
		buttonFacebook = new Rect(sharingGroup.width * 0.05f, sharingGroup.height * 0.64f, sharingGroup.width * 0.5f, sharingGroup.height * 0.07f);
		buttonTwitter = new Rect(sharingGroup.width * 0.05f, sharingGroup.height * 0.85f, sharingGroup.width * 0.5f, sharingGroup.height * 0.07f);
		buttonMail = new Rect(sharingGroup.width * 0.05f, sharingGroup.height * 0.71f, sharingGroup.width * 0.5f, sharingGroup.height * 0.07f);
		buttonDownload = new Rect(sharingGroup.width * 0.05f, sharingGroup.height * 0.78f, sharingGroup.width * 0.5f, sharingGroup.height * 0.07f);
		textAreaRect = new Rect(nativeHorizontalResolution * 0.4f, nativeVerticalResolution * 0.5f, nativeHorizontalResolution * 0.3f, nativeVerticalResolution * 0.05f);
		sendButtonRect = new Rect(nativeHorizontalResolution * 0.7f, nativeVerticalResolution * 0.5f, nativeHorizontalResolution * 0.1f, nativeVerticalResolution * 0.05f);
		procesingRect = new Rect(nativeHorizontalResolution * 0.39f, nativeVerticalResolution * 0.5f, procesing.width, procesing.height);
	}

	private void Awake()
	{
		nativeHorizontalResolution = 854f;
		nativeVerticalResolution = 480f;
	}

	private void Start()
	{
		SetRects();
		changeType = ChangeType.FACIAL_DETAILS;
		hairIndex = 0;
		shoesIndex = 0;
		topIndex = 0;
		bottomIndex = 0;
		accesoriesIndex = 0;
		facialDetailsIndex = 0;
		hairSectionIndex = 0;
		shoesSectionIndex = 0;
		topSectionIndex = 0;
		bottomSectionIndex = 0;
		accesoriesSectionIndex = 0;
		facialDetailsSectionIndex = 0;
		backgroundIndex = 0;
		backgroundSectionIndex = 0;
		facialExpressionsIndex = 0;
		facialExpressionsSectionIndex = 0;
		email = string.Empty;
		enable = true;
		showMailBox = false;
		isProcesing = false;
		indexSectionTypeControl = 0;
	}

	private void OnGUI()
	{
		GUI.matrix = Matrix4x4.TRS(new Vector3(0f, 0f, 0f), Quaternion.identity, new Vector3((float)Screen.width / nativeHorizontalResolution, (float)Screen.height / nativeVerticalResolution, 1f));
		if (!enable)
		{
			return;
		}
		if (isProcesing)
		{
			GUI.DrawTexture(procesingRect, procesing);
		}
		GUI.BeginGroup(sharingGroup);
		GUI.Label(socialRect, string.Empty, style.customStyles[19]);
		if (GUI.Button(buttonFacebook, string.Empty, style.customStyles[6]))
		{
			SendMessage("TakeScreenShotMobile", TypeSocialMedia.FACEBOOK);
		}
		if (GUI.Button(buttonReset, string.Empty, style.customStyles[12]))
		{
			editorControl.ResetAll();
		}
		if (GUI.Button(buttonUndo, string.Empty, style.customStyles[15]))
		{
			if (!isPro)
			{
				editorControl.ResetOutfit(changeType);
			}
			else
			{
				editorControl.ResetOutfitPro(changeType);
			}
		}
		if (GUI.Button(buttonMail, string.Empty, style.customStyles[2]))
		{
			showMailBox = true;
		}
		GUI.EndGroup();
		GUI.Label(editorRect, string.Empty, style.customStyles[18]);
		GUI.BeginGroup(editorTypeControlGroup);
		if (indexSectionTypeControl == 0)
		{
			GUI.DrawTexture(editorArrowLeft, editorArrowLeftDesactive);
			GUI.DrawTexture(editorArrowRight, editorArrowRightActive);
			if (GUI.Button(editorArrowRight, string.Empty, style.customStyles[0]))
			{
				indexSectionTypeControl = 1;
			}
		}
		else if (indexSectionTypeControl == 1)
		{
			GUI.DrawTexture(editorArrowLeft, editorArrowLeftActive);
			GUI.DrawTexture(editorArrowRight, editorArrowRightActive);
			if (GUI.Button(editorArrowRight, string.Empty, style.customStyles[0]))
			{
				indexSectionTypeControl = 2;
			}
			if (GUI.Button(editorArrowLeft, string.Empty, style.customStyles[0]))
			{
				indexSectionTypeControl = 0;
			}
		}
		else
		{
			GUI.DrawTexture(editorArrowLeft, editorArrowLeftActive);
			GUI.DrawTexture(editorArrowRight, editorArrowRightDesactive);
			if (GUI.Button(editorArrowLeft, string.Empty, style.customStyles[0]))
			{
				indexSectionTypeControl = 1;
			}
		}
		if (indexSectionTypeControl == 0)
		{
			GUI.DrawTexture(editorArrowLeft, editorArrowLeftDesactive);
			GUI.DrawTexture(editorArrowRight, editorArrowRightActive);
			if (GUI.Button(editorArrowRight, string.Empty, style.customStyles[0]))
			{
				indexSectionTypeControl = 1;
			}
			if (GUI.Button(buttonTypeControl1, string.Empty, style.customStyles[13]))
			{
				changeType = ChangeType.FACIAL_EXPRESSION;
			}
			if (GUI.Button(buttonTypeControl2, string.Empty, style.customStyles[3]))
			{
				changeType = ChangeType.HAIR;
			}
			if (GUI.Button(buttonTypeControl3, string.Empty, style.customStyles[5]))
			{
				changeType = ChangeType.FACIAL_DETAILS;
			}
			if (GUI.Button(buttonTypeControl4, string.Empty, style.customStyles[16]))
			{
				changeType = ChangeType.SHOES;
			}
			GUI.Label(buttonLine1, string.Empty, style.customStyles[8]);
			GUI.Label(buttonLine2, string.Empty, style.customStyles[8]);
			GUI.Label(buttonLine3, string.Empty, style.customStyles[8]);
			GUI.Label(buttonLine4, string.Empty, style.customStyles[8]);
		}
		else if (indexSectionTypeControl == 1)
		{
			if (GUI.Button(buttonTypeControl1, string.Empty, style.customStyles[1]))
			{
				changeType = ChangeType.ACCESORIES;
			}
			if (GUI.Button(buttonTypeControl2, string.Empty, style.customStyles[4]))
			{
				changeType = ChangeType.TOP;
			}
			if (GUI.Button(buttonTypeControl3, string.Empty, style.customStyles[10]))
			{
				changeType = ChangeType.BOTTOM;
			}
			if (GUI.Button(buttonTypeControl4, string.Empty, style.customStyles[7]))
			{
				changeType = ChangeType.BACKGROUND;
			}
			GUI.Label(buttonLine1, string.Empty, style.customStyles[8]);
			GUI.Label(buttonLine2, string.Empty, style.customStyles[8]);
			GUI.Label(buttonLine3, string.Empty, style.customStyles[8]);
			GUI.Label(buttonLine4, string.Empty, style.customStyles[8]);
		}
		else if (GUI.Button(buttonTypeControl1, string.Empty, style.customStyles[23]))
		{
			changeType = ChangeType.OVERALL;
		}
		GUI.EndGroup();
		GUI.BeginGroup(editorOptionsGroup);
		if (!isPro)
		{
			switch (changeType)
			{
			case ChangeType.HAIR:
			{
				for (int num = 0; num < 6; num++)
				{
					for (int num2 = 0; num2 < 3; num2++)
					{
						hairIndex = hairSectionIndex * 18 + num * 3 + num2;
						if (editorContent.hairList.Length <= hairIndex)
						{
							break;
						}
						buttonChangeType1 = new Rect(editorOptionsGroup.width * 0.33f * (float)num2, editorOptionsGroup.height * 0.12f * (float)num, (float)hairThumbnails[hairIndex].width * 0.3f, (float)hairThumbnails[hairIndex].height * 0.3f);
						if (GUI.Button(buttonChangeType1, string.Empty, style.customStyles[0]))
						{
							editorControl.ChangeOutfit(ChangeType.HAIR, hairIndex);
						}
						GUI.DrawTexture(buttonChangeType1, hairThumbnails[hairIndex]);
					}
				}
				break;
			}
			case ChangeType.FACIAL_DETAILS:
			{
				for (int num5 = 0; num5 < 6; num5++)
				{
					for (int num6 = 0; num6 < 3; num6++)
					{
						facialDetailsIndex = facialDetailsSectionIndex * 18 + num5 * 3 + num6;
						if (editorContent.facialDetailsTextureList.Length <= facialDetailsIndex)
						{
							break;
						}
						buttonChangeType1 = new Rect(editorOptionsGroup.width * 0.33f * (float)num6, editorOptionsGroup.height * 0.12f * (float)num5, (float)facialDetailsThumbnails[facialDetailsIndex].width * 0.26f, (float)facialDetailsThumbnails[facialDetailsIndex].height * 0.26f);
						if (GUI.Button(buttonChangeType1, string.Empty, style.customStyles[0]))
						{
							editorControl.ChangeOutfit(ChangeType.FACIAL_DETAILS, facialDetailsIndex);
						}
						GUI.DrawTexture(buttonChangeType1, facialDetailsThumbnails[facialDetailsIndex]);
					}
				}
				break;
			}
			case ChangeType.SHOES:
			{
				for (int k = 0; k < 6; k++)
				{
					for (int l = 0; l < 3; l++)
					{
						shoesIndex = shoesSectionIndex * 18 + k * 3 + l;
						if (editorContent.shoes.Length <= shoesIndex)
						{
							break;
						}
						buttonChangeType1 = new Rect(editorOptionsGroup.width * 0.33f * (float)l, editorOptionsGroup.height * 0.12f * (float)k, (float)shoesThumbnails[0].width * 0.3f, (float)shoesThumbnails[0].height * 0.3f);
						if (GUI.Button(buttonChangeType1, string.Empty, style.customStyles[0]))
						{
							editorControl.ChangeOutfit(ChangeType.SHOES, shoesIndex);
						}
						GUI.DrawTexture(buttonChangeType1, shoesThumbnails[shoesIndex]);
					}
				}
				break;
			}
			case ChangeType.ACCESORIES:
			{
				for (int num3 = 0; num3 < 6; num3++)
				{
					for (int num4 = 0; num4 < 3; num4++)
					{
						accesoriesIndex = accesoriesSectionIndex * 18 + num3 * 3 + num4;
						if (editorContent.accesories.Length <= accesoriesIndex)
						{
							break;
						}
						buttonChangeType1 = new Rect(editorOptionsGroup.width * 0.33f * (float)num4, editorOptionsGroup.height * 0.12f * (float)num3, (float)accesoriesThumbnails[accesoriesIndex].width * 0.5f, (float)accesoriesThumbnails[accesoriesIndex].height * 0.5f);
						if (GUI.Button(buttonChangeType1, string.Empty, style.customStyles[0]))
						{
							editorControl.ChangeOutfit(ChangeType.ACCESORIES, accesoriesIndex);
						}
						GUI.DrawTexture(buttonChangeType1, accesoriesThumbnails[accesoriesIndex]);
					}
				}
				break;
			}
			case ChangeType.TOP:
			{
				for (int m = 0; m < 6; m++)
				{
					for (int n = 0; n < 3; n++)
					{
						topIndex = topSectionIndex * 18 + m * 3 + n;
						if (editorContent.tops.Length <= topIndex)
						{
							break;
						}
						buttonChangeType1 = new Rect(editorOptionsGroup.width * 0.33f * (float)n, editorOptionsGroup.height * 0.12f * (float)m, (float)topThumbnails[topIndex].width * 0.3f, (float)topThumbnails[topIndex].height * 0.3f);
						if (GUI.Button(buttonChangeType1, string.Empty, style.customStyles[0]))
						{
							editorControl.ChangeOutfit(ChangeType.TOP, topIndex);
						}
						GUI.DrawTexture(buttonChangeType1, topThumbnails[topIndex]);
					}
				}
				break;
			}
			case ChangeType.BOTTOM:
			{
				for (int i = 0; i < 6; i++)
				{
					for (int j = 0; j < 3; j++)
					{
						bottomIndex = bottomSectionIndex * 18 + i * 3 + j;
						if (editorContent.bottoms.Length <= bottomIndex)
						{
							break;
						}
						buttonChangeType1 = new Rect(editorOptionsGroup.width * 0.33f * (float)j, editorOptionsGroup.height * 0.12f * (float)i, (float)bottomThumbnails[bottomIndex].width * 0.3f, (float)bottomThumbnails[bottomIndex].height * 0.3f);
						if (GUI.Button(buttonChangeType1, string.Empty, style.customStyles[0]))
						{
							editorControl.ChangeOutfit(ChangeType.BOTTOM, bottomIndex);
						}
						GUI.DrawTexture(buttonChangeType1, bottomThumbnails[bottomIndex]);
					}
				}
				break;
			}
			}
		}
		else
		{
			switch (changeType)
			{
			case ChangeType.HAIR:
			{
				for (int num9 = 0; num9 < 6; num9++)
				{
					for (int num10 = 0; num10 < 3; num10++)
					{
						hairIndex = hairSectionIndex * 18 + num9 * 3 + num10;
						if (editorContent.hairSkinnedList.Length <= hairIndex)
						{
							break;
						}
						buttonChangeType1 = new Rect(editorOptionsGroup.width * 0.33f * (float)num10, editorOptionsGroup.height * 0.15f * (float)num9, (float)hairProThumbnails[0].width * 0.5f, (float)hairProThumbnails[0].height * 0.5f);
						if (GUI.Button(buttonChangeType1, string.Empty, style.customStyles[0]))
						{
							editorControl.ChangeOutfitPro(ChangeType.HAIR, hairIndex);
						}
						GUI.DrawTexture(buttonChangeType1, hairProThumbnails[hairIndex]);
					}
				}
				break;
			}
			case ChangeType.FACIAL_DETAILS:
			{
				for (int num17 = 0; num17 < 6; num17++)
				{
					for (int num18 = 0; num18 < 3; num18++)
					{
						facialDetailsIndex = facialDetailsSectionIndex * 18 + num17 * 3 + num18;
						if (editorContent.facialDetailsTextureSkinnedList.Length <= facialDetailsIndex)
						{
							break;
						}
						buttonChangeType1 = new Rect(editorOptionsGroup.width * 0.33f * (float)num18, editorOptionsGroup.height * 0.15f * (float)num17, (float)facialDetailsProThumbnails[facialDetailsIndex].width * 0.5f, (float)facialDetailsProThumbnails[facialDetailsIndex].height * 0.5f);
						if (GUI.Button(buttonChangeType1, string.Empty, style.customStyles[0]))
						{
							editorControl.ChangeOutfitPro(ChangeType.FACIAL_DETAILS, facialDetailsIndex);
						}
						GUI.DrawTexture(buttonChangeType1, facialDetailsProThumbnails[facialDetailsIndex]);
					}
				}
				break;
			}
			case ChangeType.SHOES:
			{
				for (int num21 = 0; num21 < 6; num21++)
				{
					for (int num22 = 0; num22 < 3; num22++)
					{
						shoesIndex = shoesSectionIndex * 18 + num21 * 3 + num22;
						if (editorContent.shoesSkinnedList.Length <= shoesIndex)
						{
							break;
						}
						buttonChangeType1 = new Rect(editorOptionsGroup.width * 0.33f * (float)num22, editorOptionsGroup.height * 0.15f * (float)num21, (float)shoesProThumbnails[0].width * 0.5f, (float)shoesProThumbnails[0].height * 0.5f);
						if (GUI.Button(buttonChangeType1, string.Empty, style.customStyles[0]))
						{
							editorControl.ChangeOutfitPro(ChangeType.SHOES, shoesIndex);
						}
						GUI.DrawTexture(buttonChangeType1, shoesProThumbnails[shoesIndex]);
					}
				}
				break;
			}
			case ChangeType.ACCESORIES:
			{
				for (int num13 = 0; num13 < 6; num13++)
				{
					for (int num14 = 0; num14 < 3; num14++)
					{
						accesoriesIndex = accesoriesSectionIndex * 18 + num13 * 3 + num14;
						if (editorContent.accesorieSkinnedList.Length <= accesoriesIndex)
						{
							break;
						}
						buttonChangeType1 = new Rect(editorOptionsGroup.width * 0.33f * (float)num14, editorOptionsGroup.height * 0.14f * (float)num13, (float)accesoriesProThumbnails[accesoriesIndex].width * 0.5f, (float)accesoriesProThumbnails[accesoriesIndex].height * 0.5f);
						if (GUI.Button(buttonChangeType1, string.Empty, style.customStyles[0]))
						{
							editorControl.ChangeOutfitPro(ChangeType.ACCESORIES, accesoriesIndex);
						}
						GUI.DrawTexture(buttonChangeType1, accesoriesProThumbnails[accesoriesIndex]);
					}
				}
				break;
			}
			case ChangeType.TOP:
			{
				for (int num23 = 0; num23 < 6; num23++)
				{
					for (int num24 = 0; num24 < 3; num24++)
					{
						topIndex = topSectionIndex * 18 + num23 * 3 + num24;
						if (editorContent.topsSkinnedList.Length <= topIndex)
						{
							break;
						}
						buttonChangeType1 = new Rect(editorOptionsGroup.width * 0.33f * (float)num24, editorOptionsGroup.height * 0.14f * (float)num23, (float)topProThumbnails[topIndex].width * 0.5f, (float)topProThumbnails[topIndex].height * 0.5f);
						if (GUI.Button(buttonChangeType1, string.Empty, style.customStyles[0]))
						{
							editorControl.ChangeOutfitPro(ChangeType.TOP, topIndex);
						}
						GUI.DrawTexture(buttonChangeType1, topProThumbnails[topIndex]);
					}
				}
				break;
			}
			case ChangeType.BOTTOM:
			{
				for (int num19 = 0; num19 < 6; num19++)
				{
					for (int num20 = 0; num20 < 3; num20++)
					{
						bottomIndex = bottomSectionIndex * 18 + num19 * 3 + num20;
						if (editorContent.bottomsSkinnedList.Length <= bottomIndex)
						{
							break;
						}
						buttonChangeType1 = new Rect(editorOptionsGroup.width * 0.33f * (float)num20, editorOptionsGroup.height * 0.15f * (float)num19, (float)bottomProThumbnails[bottomIndex].width * 0.5f, (float)bottomProThumbnails[bottomIndex].height * 0.5f);
						if (GUI.Button(buttonChangeType1, string.Empty, style.customStyles[0]))
						{
							editorControl.ChangeOutfitPro(ChangeType.BOTTOM, bottomIndex);
						}
						GUI.DrawTexture(buttonChangeType1, bottomProThumbnails[bottomIndex]);
					}
				}
				break;
			}
			case ChangeType.BACKGROUND:
			{
				for (int num15 = 0; num15 < 6; num15++)
				{
					for (int num16 = 0; num16 < 3; num16++)
					{
						backgroundIndex = backgroundSectionIndex * 18 + num15 * 3 + num16;
						if (editorContent.backgroundsTextureList.Length <= backgroundIndex)
						{
							break;
						}
						buttonChangeType1 = new Rect(editorOptionsGroup.width * 0.33f * (float)num16, editorOptionsGroup.height * 0.15f * (float)num15, (float)backgroundProThumbnails[backgroundIndex].width * 0.3f, (float)backgroundProThumbnails[backgroundIndex].height * 0.3f);
						if (GUI.Button(buttonChangeType1, string.Empty, style.customStyles[0]))
						{
							editorControl.ChangeOutfitPro(ChangeType.BACKGROUND, backgroundIndex);
						}
						GUI.DrawTexture(buttonChangeType1, backgroundProThumbnails[backgroundIndex]);
					}
				}
				break;
			}
			case ChangeType.FACIAL_EXPRESSION:
			{
				for (int num11 = 0; num11 < 6; num11++)
				{
					for (int num12 = 0; num12 < 3; num12++)
					{
						facialExpressionsIndex = facialExpressionsSectionIndex * 18 + num11 * 3 + num12;
						if (expressionsProThumbnails.Length <= facialExpressionsIndex)
						{
							break;
						}
						buttonChangeType1 = new Rect(editorOptionsGroup.width * 0.33f * (float)num12, editorOptionsGroup.height * 0.15f * (float)num11, (float)expressionsProThumbnails[facialExpressionsIndex].width * 0.5f, (float)expressionsProThumbnails[facialExpressionsIndex].height * 0.5f);
						if (GUI.Button(buttonChangeType1, string.Empty, style.customStyles[0]))
						{
							editorControl.ChangeOutfitPro(ChangeType.FACIAL_EXPRESSION, facialExpressionsIndex);
						}
						GUI.DrawTexture(buttonChangeType1, expressionsProThumbnails[facialExpressionsIndex]);
					}
				}
				break;
			}
			case ChangeType.OVERALL:
			{
				for (int num7 = 0; num7 < 6; num7++)
				{
					for (int num8 = 0; num8 < 3; num8++)
					{
						overallsIndex = overallsSectionIndex * 18 + num7 * 3 + num8;
						if (overallsThumbnails.Length <= overallsIndex)
						{
							break;
						}
						buttonChangeType1 = new Rect(editorOptionsGroup.width * 0.33f * (float)num8, editorOptionsGroup.height * 0.15f * (float)num7, (float)overallsThumbnails[overallsIndex].width * 0.5f, (float)overallsThumbnails[overallsIndex].height * 0.5f);
						if (GUI.Button(buttonChangeType1, string.Empty, style.customStyles[0]))
						{
							editorControl.ChangeOutfitPro(ChangeType.OVERALL, overallsIndex);
						}
						GUI.DrawTexture(buttonChangeType1, overallsThumbnails[overallsIndex]);
					}
				}
				break;
			}
			}
		}
		GUI.EndGroup();
		if (!isPro)
		{
			switch (changeType)
			{
			case ChangeType.HAIR:
				if (hairSectionIndex > 0 && GUI.Button(buttonPrev, string.Empty, style.customStyles[11]))
				{
					hairSectionIndex--;
				}
				if (editorContent.hairList.Length > hairIndex + 1 && GUI.Button(buttonNext, string.Empty, style.customStyles[9]))
				{
					hairSectionIndex++;
				}
				break;
			case ChangeType.ACCESORIES:
				if (accesoriesSectionIndex > 0 && GUI.Button(buttonPrev, string.Empty, style.customStyles[11]))
				{
					accesoriesSectionIndex--;
				}
				if (editorContent.accesories.Length > accesoriesIndex + 1 && GUI.Button(buttonNext, string.Empty, style.customStyles[9]))
				{
					accesoriesSectionIndex++;
				}
				break;
			case ChangeType.BOTTOM:
				if (bottomSectionIndex > 0 && GUI.Button(buttonPrev, string.Empty, style.customStyles[11]))
				{
					bottomSectionIndex--;
				}
				if (editorContent.bottoms.Length > bottomIndex + 1 && GUI.Button(buttonNext, string.Empty, style.customStyles[9]))
				{
					bottomSectionIndex++;
				}
				break;
			case ChangeType.FACIAL_DETAILS:
				if (facialDetailsSectionIndex > 0 && GUI.Button(buttonPrev, string.Empty, style.customStyles[11]))
				{
					facialDetailsSectionIndex--;
				}
				if (editorContent.facialDetailsTextureList.Length > facialDetailsIndex + 1 && GUI.Button(buttonNext, string.Empty, style.customStyles[9]))
				{
					facialDetailsSectionIndex++;
				}
				break;
			case ChangeType.SHOES:
				if (shoesSectionIndex > 0 && GUI.Button(buttonPrev, string.Empty, style.customStyles[11]))
				{
					shoesSectionIndex--;
				}
				if (editorContent.shoes.Length > shoesIndex + 1 && GUI.Button(buttonNext, string.Empty, style.customStyles[9]))
				{
					shoesSectionIndex++;
				}
				break;
			case ChangeType.TOP:
				if (topSectionIndex > 0 && GUI.Button(buttonPrev, string.Empty, style.customStyles[11]))
				{
					topSectionIndex--;
				}
				if (editorContent.tops.Length > topIndex + 1 && GUI.Button(buttonNext, string.Empty, style.customStyles[9]))
				{
					topSectionIndex++;
				}
				break;
			}
		}
		else
		{
			switch (changeType)
			{
			case ChangeType.HAIR:
				if (hairSectionIndex > 0 && GUI.Button(buttonPrev, string.Empty, style.customStyles[11]))
				{
					hairSectionIndex--;
				}
				if (editorContent.hairSkinnedList.Length > hairIndex + 1 && GUI.Button(buttonNext, string.Empty, style.customStyles[9]))
				{
					hairSectionIndex++;
				}
				break;
			case ChangeType.ACCESORIES:
				if (accesoriesSectionIndex > 0 && GUI.Button(buttonPrev, string.Empty, style.customStyles[11]))
				{
					accesoriesSectionIndex--;
				}
				if (editorContent.accesorieSkinnedList.Length > accesoriesIndex + 1 && GUI.Button(buttonNext, string.Empty, style.customStyles[9]))
				{
					accesoriesSectionIndex++;
				}
				break;
			case ChangeType.BOTTOM:
				if (bottomSectionIndex > 0 && GUI.Button(buttonPrev, string.Empty, style.customStyles[11]))
				{
					bottomSectionIndex--;
				}
				if (editorContent.bottomsSkinnedList.Length > bottomIndex + 1 && GUI.Button(buttonNext, string.Empty, style.customStyles[9]))
				{
					bottomSectionIndex++;
				}
				break;
			case ChangeType.FACIAL_DETAILS:
				if (facialDetailsSectionIndex > 0 && GUI.Button(buttonPrev, string.Empty, style.customStyles[11]))
				{
					facialDetailsSectionIndex--;
				}
				if (editorContent.facialDetailsTextureSkinnedList.Length > facialDetailsIndex + 1 && GUI.Button(buttonNext, string.Empty, style.customStyles[9]))
				{
					facialDetailsSectionIndex++;
				}
				break;
			case ChangeType.SHOES:
				if (shoesSectionIndex > 0 && GUI.Button(buttonPrev, string.Empty, style.customStyles[11]))
				{
					shoesSectionIndex--;
				}
				if (editorContent.shoesSkinnedList.Length > shoesIndex + 1 && GUI.Button(buttonNext, string.Empty, style.customStyles[9]))
				{
					shoesSectionIndex++;
				}
				break;
			case ChangeType.TOP:
				if (topSectionIndex > 0 && GUI.Button(buttonPrev, string.Empty, style.customStyles[11]))
				{
					topSectionIndex--;
				}
				if (editorContent.topsSkinnedList.Length > topIndex + 1 && GUI.Button(buttonNext, string.Empty, style.customStyles[9]))
				{
					topSectionIndex++;
				}
				break;
			case ChangeType.BACKGROUND:
				if (backgroundSectionIndex > 0 && GUI.Button(buttonPrev, string.Empty, style.customStyles[11]))
				{
					backgroundSectionIndex--;
				}
				if (editorContent.backgroundsTextureList.Length > backgroundIndex + 1 && GUI.Button(buttonNext, string.Empty, style.customStyles[9]))
				{
					backgroundSectionIndex++;
				}
				break;
			case ChangeType.FACIAL_EXPRESSION:
				if (facialExpressionsSectionIndex > 0 && GUI.Button(buttonPrev, string.Empty, style.customStyles[11]))
				{
					facialExpressionsSectionIndex--;
				}
				if (expressionsProThumbnails.Length > facialExpressionsIndex + 1 && GUI.Button(buttonNext, string.Empty, style.customStyles[9]))
				{
					facialExpressionsSectionIndex++;
				}
				break;
			case ChangeType.OVERALL:
				if (overallsSectionIndex > 0 && GUI.Button(buttonPrev, string.Empty, style.customStyles[11]))
				{
					overallsSectionIndex--;
				}
				if (overallsThumbnails.Length > overallsIndex + 1 && GUI.Button(buttonNext, string.Empty, style.customStyles[9]))
				{
					overallsSectionIndex++;
				}
				break;
			}
		}
		if (showMailBox)
		{
			email = GUI.TextField(textAreaRect, email, style.customStyles[20]);
			if (GUI.Button(sendButtonRect, "SEND", style.customStyles[20]))
			{
				Screenshot.mail = email;
				SendMessage("TakeScreenShotMobile", TypeSocialMedia.MAIL);
				showMailBox = false;
			}
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
