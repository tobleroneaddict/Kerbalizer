using UnityEngine;

public class EditorControl : MonoBehaviour
{
	public EditorContent content;

	private int hairIndex;

	private int facialExpressionIndex;

	private int facialDetailsIndex;

	private int topIndex;

	private int bottomIndex;

	private int shoesIndex;

	private int accesoriesIndex;

	private int backgroundIndex;

	private int overallsIndex;

	public MeshFilter hairAttachPoint;

	public MeshRenderer hairMaterialAttachPoint;

	public MeshFilter facilDetailsAttachPoint;

	public MeshFilter facilDetailsAttachPoint2;

	public MeshRenderer facialDetailsMaterial;

	public MeshRenderer facialDetailsMaterial2;

	public MeshRenderer facialDetailsTexture;

	public MeshFilter shoeAttachPoint;

	public MeshRenderer shoeMaterialAttachPoint;

	public MeshFilter bottomAttachPoint;

	public MeshRenderer bottomMaterialAttachPoint;

	public MeshFilter topAttachPoint;

	public MeshRenderer topMaterialAttachPoint;

	public MeshFilter accesorieHatAttachPoint;

	public MeshRenderer accesorieHatMaterialAttachPoint;

	public MeshFilter accesorieGlassAttachPoint;

	public MeshRenderer accesorieGlassMaterialAttachPoint;

	public MeshFilter accesorieTieAttachPoint;

	public MeshRenderer accesorieTieMaterialAttachPoint;

	public MeshFilter accesorieToyAttachPoint;

	public MeshRenderer accesorieToyMaterialAttachPoint;

	public SkinnedMeshRenderer bottomMixedAttachPoint;

	public SkinnedMeshRenderer headMaterial;

	public SkinnedMeshRenderer topMixedAttachPointShort;

	public SkinnedMeshRenderer topMixedAttachPointLong;

	public SkinnedMeshRenderer topMixedAttachPointSweter;

	public Vector3 astronautOffset;

	public Vector3 beachBallOffset;

	public Vector3 KSPFlagOffset;

	public Material backgroundMaterial;

	public AnimationControl animationControl;

	private int lastAccesorieIndex;

	private int lastToyIndex;

	private Material currentMaterial;

	private Material secondCurrentMaterial;

	private bool isSecondMaterial;

	public SkinnedMeshRenderer fullTorso;

	public SkinnedMeshRenderer initShort;

	public Transform armsTopLong;

	public SkinnedMeshRenderer fullRLeg;

	public SkinnedMeshRenderer fullLLeg;

	public Transform shortLegs;

	private bool changedToy;

	private void Start()
	{
		fullTorso.enabled = true;
		initShort.enabled = true;
		fullRLeg.enabled = true;
		fullLLeg.enabled = true;
		armsTopLong.gameObject.SetActive(false);
		shortLegs.gameObject.SetActive(false);
		hairIndex = -1;
		facialDetailsIndex = -1;
		facialExpressionIndex = -1;
		topIndex = -1;
		bottomIndex = -1;
		shoesIndex = -1;
		accesoriesIndex = -1;
		backgroundIndex = -1;
		overallsIndex = -1;
		lastAccesorieIndex = 0;
		lastToyIndex = -1;
		backgroundMaterial.mainTexture = content.backgroundsTextureList[0];
		isSecondMaterial = false;
		DisableAll();
		changedToy = false;
	}

	public void ChangeOutfit(ChangeType type, int index)
	{
		switch (type)
		{
		case ChangeType.HAIR:
			if (content.accesorieTypes[lastAccesorieIndex] == AccesorieType.HAT && accesorieHatAttachPoint.mesh != null)
			{
				accesorieHatAttachPoint.mesh = null;
			}
			hairAttachPoint.mesh = content.hairList[index];
			hairMaterialAttachPoint.material = content.hairMaterialList[index];
			break;
		case ChangeType.FACIAL_DETAILS:
			headMaterial.materials[0].mainTexture = content.facialDetailsTextureList[index];
			if (content.facialDetailsTextureList[index].name == "kerbal_armHands")
			{
				headMaterial.materials[0].color = new Color(1f, 1f, 1f, 0f);
			}
			else
			{
				headMaterial.materials[0].color = new Color(1f, 1f, 1f, 1f);
			}
			facilDetailsAttachPoint.mesh = content.facialDetailsList[index];
			facilDetailsAttachPoint2.mesh = content.facialDetailsList2[index];
			facialDetailsMaterial.material = content.facialDetailsMaterialList[index];
			facialDetailsMaterial2.material = content.facialDetailsMaterialList[index];
			break;
		case ChangeType.ACCESORIES:
			switch (content.accesorieTypes[index])
			{
			case AccesorieType.HAT:
				if (hairAttachPoint.mesh != null)
				{
					hairAttachPoint.mesh = null;
				}
				accesorieHatAttachPoint.mesh = content.accesories[index];
				accesorieHatMaterialAttachPoint.material = content.accesoriesMaterial[index];
				break;
			case AccesorieType.GLASS:
				accesorieGlassAttachPoint.mesh = content.accesories[index];
				accesorieGlassMaterialAttachPoint.material = content.accesoriesMaterial[index];
				break;
			case AccesorieType.TIE:
				accesorieTieAttachPoint.mesh = content.accesories[index];
				accesorieTieMaterialAttachPoint.material = content.accesoriesMaterial[index];
				break;
			case AccesorieType.TOY:
				accesorieToyAttachPoint.mesh = content.accesories[index];
				accesorieToyMaterialAttachPoint.material = content.accesoriesMaterial[index];
				lastToyIndex = index;
				break;
			}
			lastAccesorieIndex = index;
			switch (lastToyIndex)
			{
			case 0:
				accesorieToyAttachPoint.transform.position = astronautOffset;
				break;
			case 2:
				accesorieToyAttachPoint.transform.position = beachBallOffset;
				break;
			case 9:
				accesorieToyAttachPoint.transform.position = KSPFlagOffset;
				break;
			default:
				accesorieToyAttachPoint.transform.position = Vector3.zero;
				break;
			}
			break;
		case ChangeType.SHOES:
			shoeAttachPoint.mesh = content.shoes[index];
			shoeMaterialAttachPoint.material = content.shoesMaterial[index];
			break;
		case ChangeType.TOP:
			if (content.topType[index] == 0)
			{
				topMixedAttachPointLong.material = content.topsMaterial[index];
				topMixedAttachPointLong.sharedMesh = content.tops[index];
				topMixedAttachPointShort.material = null;
				topMixedAttachPointShort.sharedMesh = null;
				topMixedAttachPointSweter.material = null;
				topMixedAttachPointSweter.sharedMesh = null;
			}
			else if (content.topType[index] == 1)
			{
				topMixedAttachPointShort.material = content.topsMaterial[index];
				topMixedAttachPointShort.sharedMesh = content.tops[index];
				topMixedAttachPointLong.material = null;
				topMixedAttachPointLong.sharedMesh = null;
				topMixedAttachPointSweter.material = null;
				topMixedAttachPointSweter.sharedMesh = null;
			}
			else
			{
				topMixedAttachPointShort.material = null;
				topMixedAttachPointShort.sharedMesh = null;
				topMixedAttachPointLong.material = null;
				topMixedAttachPointLong.sharedMesh = null;
				topMixedAttachPointSweter.material = content.topsMaterial[index];
				topMixedAttachPointSweter.sharedMesh = content.tops[index];
			}
			break;
		case ChangeType.BOTTOM:
			bottomAttachPoint.mesh = content.bottoms[index];
			bottomMaterialAttachPoint.material = content.bottomsMaterial[index];
			bottomMixedAttachPoint.material = content.bottomsMaterial[index];
			bottomMixedAttachPoint.sharedMesh = null;
			break;
		}
		ShowHideBodyParts();
	}

	public void ResetOutfit(ChangeType type)
	{
		switch (type)
		{
		case ChangeType.ACCESORIES:
			accesorieHatAttachPoint.mesh = null;
			accesorieGlassAttachPoint.mesh = null;
			accesorieTieAttachPoint.mesh = null;
			accesorieToyAttachPoint.mesh = null;
			break;
		case ChangeType.SHOES:
			shoeAttachPoint.mesh = null;
			break;
		case ChangeType.BOTTOM:
			bottomAttachPoint.mesh = null;
			bottomMixedAttachPoint.material = content.bottomDafaultMaterial;
			bottomMixedAttachPoint.sharedMesh = content.bottomDafultMesh;
			break;
		case ChangeType.TOP:
			topAttachPoint.mesh = null;
			topMixedAttachPointShort.material = null;
			topMixedAttachPointShort.sharedMesh = null;
			topMixedAttachPointLong.material = null;
			topMixedAttachPointLong.sharedMesh = null;
			topMixedAttachPointSweter.material = null;
			topMixedAttachPointSweter.sharedMesh = null;
			break;
		case ChangeType.HAIR:
			hairAttachPoint.mesh = null;
			break;
		case ChangeType.FACIAL_DETAILS:
			headMaterial.materials[0].mainTexture = content.defaultHeadTexture;
			headMaterial.materials[0].color = new Color(1f, 1f, 1f, 0f);
			facilDetailsAttachPoint.mesh = null;
			facilDetailsAttachPoint2.mesh = null;
			break;
		}
		ShowHideBodyParts();
	}

	public void ResetOutfitPro(ChangeType type)
	{
		switch (type)
		{
		case ChangeType.ACCESORIES:
		{
			SkinnedMeshRenderer[] accesorieSkinnedList = content.accesorieSkinnedList;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer6 in accesorieSkinnedList)
			{
				skinnedMeshRenderer6.enabled = false;
				accesoriesIndex = -1;
			}
			accesorieToyAttachPoint.mesh = null;
			lastToyIndex = -1;
			break;
		}
		case ChangeType.SHOES:
		{
			SkinnedMeshRenderer[] shoesSkinnedList = content.shoesSkinnedList;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer8 in shoesSkinnedList)
			{
				skinnedMeshRenderer8.enabled = false;
				shoesIndex = -1;
			}
			SkinnedMeshRenderer[] shoesSkinnedList2 = content.shoesSkinnedList2;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer9 in shoesSkinnedList2)
			{
				if (skinnedMeshRenderer9 != null)
				{
					skinnedMeshRenderer9.enabled = false;
				}
			}
			break;
		}
		case ChangeType.OVERALL:
		{
			SkinnedMeshRenderer[] overallsSkinnedList = content.overallsSkinnedList;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer4 in overallsSkinnedList)
			{
				skinnedMeshRenderer4.enabled = false;
				overallsIndex = -1;
			}
			break;
		}
		case ChangeType.BOTTOM:
		{
			SkinnedMeshRenderer[] bottomsSkinnedList = content.bottomsSkinnedList;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer5 in bottomsSkinnedList)
			{
				skinnedMeshRenderer5.enabled = false;
				bottomIndex = -1;
			}
			bottomMixedAttachPoint.sharedMesh = content.bottomDafultMesh;
			break;
		}
		case ChangeType.TOP:
		{
			SkinnedMeshRenderer[] topsSkinnedList = content.topsSkinnedList;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer3 in topsSkinnedList)
			{
				skinnedMeshRenderer3.enabled = false;
				topIndex = -1;
			}
			break;
		}
		case ChangeType.HAIR:
		{
			SkinnedMeshRenderer[] hairSkinnedList = content.hairSkinnedList;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer7 in hairSkinnedList)
			{
				if (skinnedMeshRenderer7 != null)
				{
					skinnedMeshRenderer7.enabled = false;
					hairIndex = -1;
				}
			}
			break;
		}
		case ChangeType.FACIAL_DETAILS:
		{
			SkinnedMeshRenderer[] facialDetailsSkinnedList = content.facialDetailsSkinnedList;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in facialDetailsSkinnedList)
			{
				if (skinnedMeshRenderer != null)
				{
					skinnedMeshRenderer.enabled = false;
				}
				facialDetailsIndex = -1;
			}
			SkinnedMeshRenderer[] facialDetailsSkinnedList2 = content.facialDetailsSkinnedList2;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer2 in facialDetailsSkinnedList2)
			{
				if (skinnedMeshRenderer2 != null)
				{
					skinnedMeshRenderer2.enabled = false;
				}
			}
			headMaterial.materials[1].mainTexture = content.defaultHairTexture;
			headMaterial.materials[0].color = new Color(1f, 1f, 1f, 0f);
			break;
		}
		case ChangeType.BACKGROUND:
			backgroundMaterial.mainTexture = content.backgroundsTextureList[0];
			backgroundIndex = -1;
			break;
		case ChangeType.FACIAL_EXPRESSION:
			animationControl.ApplyExpression(6);
			break;
		}
		ShowHideBodyParts();
		HUDEZ.changeShareButState("undoBut", 0);
	}

	public void ChangeOutfitPro(ChangeType type, int index)
	{
		switch (type)
		{
		case ChangeType.HAIR:
		{
			int num2 = 0;
			SkinnedMeshRenderer[] accesorieSkinnedList = content.accesorieSkinnedList;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer2 in accesorieSkinnedList)
			{
				if (content.accesorieTypesPro[num2] == AccesorieType.HAT)
				{
					content.accesorieSkinnedList[num2].enabled = false;
				}
				num2++;
			}
			isSecondMaterial = false;
			if (content.hairTextureList[index].name != "kerbal_armHands")
			{
				headMaterial.materials[1].mainTexture = content.hairTextureList[index];
			}
			if (content.hairTextureList[index].name.Contains("kerbalHair"))
			{
				headMaterial.materials[1].mainTexture = content.hairTextureList[index];
			}
			if (hairIndex >= 0 && hairIndex != index)
			{
				content.hairSkinnedList[hairIndex].enabled = false;
			}
			if (content.hairSkinnedList[index] != null)
			{
				hairIndex = index;
				content.hairSkinnedList[index].enabled = true;
				currentMaterial = content.hairSkinnedList[index].material;
				headMaterial.materials[1].mainTexture = content.defaultHeadTexture;
			}
			else
			{
				currentMaterial = null;
			}
			break;
		}
		case ChangeType.FACIAL_DETAILS:
			if (content.facialDetailsTextureSkinnedList[index].name == "kerbal_armHands")
			{
				headMaterial.materials[0].color = new Color(1f, 1f, 1f, 0f);
			}
			else
			{
				headMaterial.materials[0].color = new Color(1f, 1f, 1f, 1f);
				headMaterial.materials[0].mainTexture = content.facialDetailsTextureSkinnedList[index];
			}
			if (facialDetailsIndex >= 0 && facialDetailsIndex != index)
			{
				content.facialDetailsSkinnedList[facialDetailsIndex].enabled = false;
				if (content.facialDetailsSkinnedList2[facialDetailsIndex] != null)
				{
					content.facialDetailsSkinnedList2[facialDetailsIndex].enabled = false;
				}
			}
			if (content.facialDetailsSkinnedList[index] != null)
			{
				facialDetailsIndex = index;
				content.facialDetailsSkinnedList[index].enabled = true;
				currentMaterial = content.facialDetailsSkinnedList[index].material;
				headMaterial.materials[0].mainTexture = null;
				headMaterial.materials[0].color = new Color(1f, 1f, 1f, 0f);
			}
			else
			{
				currentMaterial = null;
			}
			if (content.facialDetailsSkinnedList2[index] != null)
			{
				content.facialDetailsSkinnedList2[index].enabled = true;
				secondCurrentMaterial = content.facialDetailsSkinnedList2[index].material;
				isSecondMaterial = true;
			}
			break;
		case ChangeType.ACCESORIES:
			switch (content.accesorieTypesPro[index])
			{
			case AccesorieType.HAT:
			{
				if (hairIndex >= 0 && content.hairSkinnedList[hairIndex].enabled)
				{
					content.hairSkinnedList[hairIndex].enabled = false;
				}
				int num14 = 0;
				SkinnedMeshRenderer[] accesorieSkinnedList4 = content.accesorieSkinnedList;
				foreach (SkinnedMeshRenderer skinnedMeshRenderer10 in accesorieSkinnedList4)
				{
					if (content.accesorieTypesPro[num14] == AccesorieType.HAT)
					{
						skinnedMeshRenderer10.enabled = false;
					}
					num14++;
				}
				if (index == 10)
				{
					content.accesorieSkinnedList[index].material = content.mechanicSecondMaterial;
				}
				if (index == 9)
				{
					content.accesorieSkinnedList[index].material = content.mechanicFirstMaterial;
				}
				content.accesorieSkinnedList[index].enabled = true;
				break;
			}
			case AccesorieType.GLASS:
			{
				int num12 = 0;
				SkinnedMeshRenderer[] accesorieSkinnedList3 = content.accesorieSkinnedList;
				foreach (SkinnedMeshRenderer skinnedMeshRenderer9 in accesorieSkinnedList3)
				{
					if (content.accesorieTypesPro[num12] == AccesorieType.GLASS)
					{
						skinnedMeshRenderer9.enabled = false;
					}
					num12++;
				}
				content.accesorieSkinnedList[index].enabled = true;
				break;
			}
			case AccesorieType.TIE:
			{
				int num16 = 0;
				SkinnedMeshRenderer[] accesorieSkinnedList5 = content.accesorieSkinnedList;
				foreach (SkinnedMeshRenderer skinnedMeshRenderer11 in accesorieSkinnedList5)
				{
					if (content.accesorieTypesPro[num16] == AccesorieType.TIE)
					{
						skinnedMeshRenderer11.enabled = false;
					}
					num16++;
				}
				content.accesorieSkinnedList[index].enabled = true;
				break;
			}
			case AccesorieType.TOY:
			{
				changedToy = true;
				int num7 = 0;
				int num8 = 0;
				bool flag = false;
				SkinnedMeshRenderer[] overallsSkinnedList2 = content.overallsSkinnedList;
				foreach (SkinnedMeshRenderer skinnedMeshRenderer7 in overallsSkinnedList2)
				{
					if (skinnedMeshRenderer7.enabled)
					{
						num8 = num7;
						flag = true;
					}
					num7++;
				}
				int num10 = 0;
				SkinnedMeshRenderer[] accesorieSkinnedList2 = content.accesorieSkinnedList;
				foreach (SkinnedMeshRenderer skinnedMeshRenderer8 in accesorieSkinnedList2)
				{
					if (content.accesorieTypesPro[num10] == AccesorieType.TOY)
					{
						skinnedMeshRenderer8.enabled = false;
					}
					num10++;
				}
				lastToyIndex = index;
				if (flag)
				{
					content.overallsSkinnedList[num8].enabled = true;
				}
				break;
			}
			}
			currentMaterial = content.accesorieSkinnedList[index].material;
			isSecondMaterial = false;
			lastAccesorieIndex = index;
			if (changedToy)
			{
				changedToy = false;
				switch (lastToyIndex)
				{
				case 0:
					accesorieToyAttachPoint.mesh = content.toys[0];
					accesorieToyMaterialAttachPoint.material = content.toysMaterial[0];
					accesorieToyAttachPoint.transform.position = astronautOffset;
					break;
				case 3:
					accesorieToyAttachPoint.mesh = content.toys[1];
					accesorieToyMaterialAttachPoint.material = content.toysMaterial[1];
					accesorieToyAttachPoint.transform.position = beachBallOffset;
					break;
				case 17:
					accesorieToyAttachPoint.mesh = content.toys[2];
					accesorieToyMaterialAttachPoint.material = content.toysMaterial[2];
					accesorieToyAttachPoint.transform.position = KSPFlagOffset;
					break;
				case 15:
					accesorieToyAttachPoint.mesh = content.toys[3];
					accesorieToyMaterialAttachPoint.material = content.toysMaterial[3];
					accesorieToyAttachPoint.transform.position = Vector3.zero;
					break;
				case 28:
					accesorieToyAttachPoint.mesh = content.toys[4];
					accesorieToyMaterialAttachPoint.material = content.toysMaterial[4];
					accesorieToyAttachPoint.transform.position = Vector3.zero;
					break;
				default:
					accesorieToyAttachPoint.transform.position = Vector3.zero;
					break;
				}
			}
			break;
		case ChangeType.SHOES:
		{
			int num18 = 0;
			SkinnedMeshRenderer[] overallsSkinnedList3 = content.overallsSkinnedList;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer12 in overallsSkinnedList3)
			{
				if (skinnedMeshRenderer12.name.Contains("suit") || skinnedMeshRenderer12.name.Contains("male") || skinnedMeshRenderer12.name.Contains("complete"))
				{
					skinnedMeshRenderer12.enabled = false;
				}
				num18++;
			}
			if (shoesIndex >= 0 && shoesIndex != index)
			{
				content.shoesSkinnedList[shoesIndex].enabled = false;
				if (content.shoesSkinnedList2[shoesIndex] != null)
				{
					content.shoesSkinnedList2[shoesIndex].enabled = false;
				}
			}
			shoesIndex = index;
			content.shoesSkinnedList[index].enabled = true;
			content.shoesSkinnedList[index].material = content.shoesSkinnedMaterialList[index];
			if (content.shoesSkinnedList2[index] != null)
			{
				content.shoesSkinnedList2[index].enabled = true;
				content.shoesSkinnedList2[index].material = content.shoesSkinnedMaterialList[index];
				secondCurrentMaterial = content.shoesSkinnedList2[index].material;
				isSecondMaterial = true;
			}
			else
			{
				isSecondMaterial = false;
			}
			currentMaterial = content.shoesSkinnedList[index].material;
			break;
		}
		case ChangeType.OVERALL:
		{
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			SkinnedMeshRenderer[] topsSkinnedList = content.topsSkinnedList;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer3 in topsSkinnedList)
			{
				content.topsSkinnedList[num5].enabled = false;
				if (content.topsSkinnedList2[num5] != null)
				{
					content.topsSkinnedList2[num5].enabled = false;
				}
				num5++;
			}
			if (content.overallsSkinnedList[index].name.Contains("male") || content.overallsSkinnedList[index].name.Contains("complete") || content.overallsSkinnedList[index].name.Contains("suit"))
			{
				SkinnedMeshRenderer[] bottomsSkinnedList = content.bottomsSkinnedList;
				foreach (SkinnedMeshRenderer skinnedMeshRenderer4 in bottomsSkinnedList)
				{
					content.bottomsSkinnedList[num3].enabled = false;
					num3++;
				}
				SkinnedMeshRenderer[] shoesSkinnedList = content.shoesSkinnedList;
				foreach (SkinnedMeshRenderer skinnedMeshRenderer5 in shoesSkinnedList)
				{
					content.shoesSkinnedList[num6].enabled = false;
					if (content.shoesSkinnedList2[num6] != null)
					{
						content.shoesSkinnedList2[num6].enabled = false;
					}
					num6++;
				}
			}
			if (content.overallsSkinnedList[index].name.Contains("plain"))
			{
				SkinnedMeshRenderer[] bottomsSkinnedList2 = content.bottomsSkinnedList;
				foreach (SkinnedMeshRenderer skinnedMeshRenderer6 in bottomsSkinnedList2)
				{
					content.bottomsSkinnedList[num4].enabled = false;
					num4++;
				}
			}
			if (overallsIndex >= 0 && overallsIndex != index)
			{
				content.overallsSkinnedList[overallsIndex].enabled = false;
			}
			overallsIndex = index;
			content.overallsSkinnedList[index].enabled = true;
			content.overallsSkinnedList[index].material = content.overallsSkinnedMaterialList[index];
			isSecondMaterial = false;
			currentMaterial = content.overallsSkinnedList[index].material;
			break;
		}
		case ChangeType.TOP:
		{
			int num20 = 0;
			SkinnedMeshRenderer[] overallsSkinnedList4 = content.overallsSkinnedList;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer13 in overallsSkinnedList4)
			{
				content.overallsSkinnedList[num20].enabled = false;
				num20++;
			}
			if (topIndex >= 0 && topIndex != index)
			{
				content.topsSkinnedList[topIndex].enabled = false;
				if (content.topsSkinnedList2[topIndex] != null)
				{
					content.topsSkinnedList2[topIndex].enabled = false;
				}
			}
			topIndex = index;
			content.topsSkinnedList[index].enabled = true;
			content.topsSkinnedList[index].material = content.topsSkinnedMaterialList[index];
			if (content.topsSkinnedList2[index] != null)
			{
				content.topsSkinnedList2[index].enabled = true;
				content.topsSkinnedList2[index].material = content.topsSkinnedMaterialList[index];
				secondCurrentMaterial = content.topsSkinnedList2[index].material;
				isSecondMaterial = true;
			}
			else
			{
				isSecondMaterial = false;
			}
			currentMaterial = content.topsSkinnedList[index].material;
			break;
		}
		case ChangeType.BOTTOM:
		{
			int num = 0;
			SkinnedMeshRenderer[] overallsSkinnedList = content.overallsSkinnedList;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in overallsSkinnedList)
			{
				if (skinnedMeshRenderer.name.Contains("suit") || skinnedMeshRenderer.name.Contains("male") || skinnedMeshRenderer.name.Contains("complete"))
				{
					skinnedMeshRenderer.enabled = false;
				}
				num++;
			}
			if (bottomIndex >= 0 && bottomIndex != index)
			{
				content.bottomsSkinnedList[bottomIndex].enabled = false;
			}
			bottomIndex = index;
			content.bottomsSkinnedList[index].enabled = true;
			content.bottomsSkinnedList[index].material = content.bottomsSkinnedMaterialList[index];
			currentMaterial = content.bottomsSkinnedList[index].material;
			bottomMixedAttachPoint.sharedMesh = null;
			isSecondMaterial = false;
			break;
		}
		case ChangeType.BACKGROUND:
			backgroundMaterial.mainTexture = content.backgroundsTextureList[index];
			backgroundIndex = index;
			currentMaterial = null;
			break;
		case ChangeType.FACIAL_EXPRESSION:
			animationControl.ApplyExpression(index);
			currentMaterial = null;
			break;
		}
		ShowHideBodyParts();
	}

	private void ShowHideBodyParts()
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		bool flag6 = false;
		bool flag7 = false;
		SkinnedMeshRenderer[] shoesSkinnedList = content.shoesSkinnedList;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in shoesSkinnedList)
		{
			if (skinnedMeshRenderer.enabled && !skinnedMeshRenderer.name.Contains("flat") && !skinnedMeshRenderer.name.Contains("Flip"))
			{
				flag = true;
			}
		}
		SkinnedMeshRenderer[] topsSkinnedList = content.topsSkinnedList;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer2 in topsSkinnedList)
		{
			if (skinnedMeshRenderer2.enabled)
			{
				if (skinnedMeshRenderer2.name.Contains("tank"))
				{
					flag2 = true;
				}
				else
				{
					flag3 = true;
				}
			}
		}
		SkinnedMeshRenderer[] bottomsSkinnedList = content.bottomsSkinnedList;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer3 in bottomsSkinnedList)
		{
			if (skinnedMeshRenderer3.enabled)
			{
				flag4 = true;
			}
		}
		SkinnedMeshRenderer[] overallsSkinnedList = content.overallsSkinnedList;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer4 in overallsSkinnedList)
		{
			if (skinnedMeshRenderer4.enabled)
			{
				if (skinnedMeshRenderer4.name.Contains("suit"))
				{
					flag5 = true;
				}
				else if (skinnedMeshRenderer4.name.Contains("dress"))
				{
					flag7 = true;
				}
				else if (skinnedMeshRenderer4.name.Contains("complete") || skinnedMeshRenderer4.name.Contains("male"))
				{
					flag6 = true;
				}
			}
		}
		fullTorso.enabled = false;
		initShort.enabled = false;
		fullRLeg.enabled = false;
		fullLLeg.enabled = false;
		armsTopLong.gameObject.SetActive(false);
		shortLegs.gameObject.SetActive(false);
		if (flag && !flag2 && !flag3 && !flag4 && !flag5 && !flag6 && !flag7)
		{
			fullTorso.enabled = true;
			initShort.enabled = true;
			shortLegs.gameObject.SetActive(true);
		}
		if (!flag && flag2 && !flag3 && !flag4 && !flag5 && !flag6 && !flag7)
		{
			fullTorso.enabled = true;
			initShort.enabled = true;
			fullRLeg.enabled = true;
			fullLLeg.enabled = true;
		}
		if (!flag && !flag2 && flag3 && !flag4 && !flag5 && !flag6 && !flag7)
		{
			armsTopLong.gameObject.SetActive(true);
			initShort.enabled = true;
			fullRLeg.enabled = true;
			fullLLeg.enabled = true;
		}
		if (!flag && !flag2 && !flag3 && flag4 && !flag5 && !flag6 && !flag7)
		{
			fullTorso.enabled = true;
			fullRLeg.enabled = true;
			fullLLeg.enabled = true;
		}
		if (!flag && !flag2 && !flag3 && !flag4 && flag5 && !flag6 && !flag7)
		{
			fullTorso.enabled = false;
			initShort.enabled = false;
			fullRLeg.enabled = false;
			fullLLeg.enabled = false;
			armsTopLong.gameObject.SetActive(false);
			shortLegs.gameObject.SetActive(false);
		}
		if (!flag && !flag2 && !flag3 && !flag4 && !flag5 && flag6 && !flag7)
		{
			armsTopLong.gameObject.SetActive(true);
		}
		if (!flag && !flag2 && !flag3 && !flag4 && !flag5 && !flag6 && flag7)
		{
			fullTorso.enabled = true;
			fullRLeg.enabled = true;
			fullLLeg.enabled = true;
		}
		if (flag && flag2 && !flag3 && !flag4 && !flag5 && !flag6 && !flag7)
		{
			fullTorso.enabled = true;
			initShort.enabled = true;
			shortLegs.gameObject.SetActive(true);
		}
		if (flag && !flag2 && flag3 && !flag4 && !flag5 && !flag6 && !flag7)
		{
			armsTopLong.gameObject.SetActive(true);
			initShort.enabled = true;
			shortLegs.gameObject.SetActive(true);
		}
		if (flag && !flag2 && !flag3 && flag4 && !flag5 && !flag6 && !flag7)
		{
			fullTorso.enabled = true;
			shortLegs.gameObject.SetActive(true);
		}
		if (flag && !flag2 && !flag3 && !flag4 && !flag5 && !flag6 && flag7)
		{
			fullTorso.enabled = true;
			initShort.enabled = true;
			shortLegs.gameObject.SetActive(true);
		}
		if (!flag && flag2 && !flag3 && flag4 && !flag5 && !flag6 && !flag7)
		{
			fullTorso.enabled = true;
			fullRLeg.enabled = true;
			fullLLeg.enabled = true;
		}
		if (!flag && !flag2 && flag3 && flag4 && !flag5 && !flag6 && !flag7)
		{
			armsTopLong.gameObject.SetActive(true);
			fullRLeg.enabled = true;
			fullLLeg.enabled = true;
		}
		if (!flag && !flag2 && !flag3 && flag4 && !flag5 && !flag6 && flag7)
		{
			fullTorso.enabled = true;
			fullRLeg.enabled = true;
			fullLLeg.enabled = true;
		}
		if (flag2 && !flag7 && !flag5 && !flag6 && flag4 && flag && !flag3)
		{
			fullTorso.enabled = true;
			shortLegs.gameObject.SetActive(true);
		}
		if (!flag2 && !flag7 && !flag5 && !flag6 && flag4 && flag && flag3)
		{
			armsTopLong.gameObject.SetActive(true);
			shortLegs.gameObject.SetActive(true);
		}
		if (!flag2 && flag7 && !flag5 && !flag6 && flag4 && flag && !flag3)
		{
			fullTorso.enabled = true;
			shortLegs.gameObject.SetActive(true);
		}
		if (!flag2 && !flag7 && !flag5 && !flag6 && !flag4 && !flag && !flag3)
		{
			fullTorso.enabled = true;
			initShort.enabled = true;
			fullRLeg.enabled = true;
			fullLLeg.enabled = true;
		}
	}

	private void Update()
	{
		if (currentMaterial == null)
		{
			ColorWheel.showColors = 0;
			ColorWheel.showPickers();
			return;
		}
		switch (currentMaterial.shader.name)
		{
		case "Diffuse":
			ColorWheel.showColors = 1;
			ColorWheel.showPickers();
			currentMaterial.color = ColorWheel.finalC1;
			if (isSecondMaterial)
			{
				secondCurrentMaterial.color = ColorWheel.finalC1;
			}
			break;
		case "Garment/StripedShirtPicker":
			ColorWheel.showColors = 2;
			ColorWheel.showPickers();
			currentMaterial.SetColor("_ColorB", ColorWheel.finalC1);
			currentMaterial.SetColor("_ColorC", ColorWheel.finalC2);
			break;
		case "Garment/Squares":
			ColorWheel.showColors = 2;
			ColorWheel.showPickers();
			currentMaterial.SetColor("_ColorB", ColorWheel.finalC1);
			currentMaterial.SetColor("_ColorC", ColorWheel.finalC2);
			break;
		case "Garment/Converse":
			ColorWheel.showColors = 1;
			ColorWheel.showPickers();
			currentMaterial.SetColor("_ColorB", ColorWheel.finalC1);
			break;
		default:
			ColorWheel.showColors = 0;
			ColorWheel.showPickers();
			break;
		}
	}

	private void DisableAll()
	{
		SkinnedMeshRenderer[] shoesSkinnedList = content.shoesSkinnedList;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in shoesSkinnedList)
		{
			skinnedMeshRenderer.enabled = false;
		}
		SkinnedMeshRenderer[] topsSkinnedList = content.topsSkinnedList;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer2 in topsSkinnedList)
		{
			skinnedMeshRenderer2.enabled = false;
		}
		SkinnedMeshRenderer[] bottomsSkinnedList = content.bottomsSkinnedList;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer3 in bottomsSkinnedList)
		{
			skinnedMeshRenderer3.enabled = false;
		}
		SkinnedMeshRenderer[] overallsSkinnedList = content.overallsSkinnedList;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer4 in overallsSkinnedList)
		{
			skinnedMeshRenderer4.enabled = false;
		}
	}

	private void ShowAllBodyParts()
	{
		fullTorso.enabled = true;
		initShort.enabled = true;
		fullRLeg.enabled = true;
		fullLLeg.enabled = true;
	}

	public void ResetAll()
	{
		SkinnedMeshRenderer[] accesorieSkinnedList = content.accesorieSkinnedList;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in accesorieSkinnedList)
		{
			skinnedMeshRenderer.enabled = false;
			accesoriesIndex = -1;
		}
		accesorieToyAttachPoint.mesh = null;
		lastToyIndex = -1;
		SkinnedMeshRenderer[] shoesSkinnedList = content.shoesSkinnedList;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer2 in shoesSkinnedList)
		{
			skinnedMeshRenderer2.enabled = false;
			shoesIndex = -1;
		}
		SkinnedMeshRenderer[] shoesSkinnedList2 = content.shoesSkinnedList2;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer3 in shoesSkinnedList2)
		{
			if (skinnedMeshRenderer3 != null)
			{
				skinnedMeshRenderer3.enabled = false;
			}
		}
		SkinnedMeshRenderer[] bottomsSkinnedList = content.bottomsSkinnedList;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer4 in bottomsSkinnedList)
		{
			skinnedMeshRenderer4.enabled = false;
			bottomIndex = -1;
		}
		bottomMixedAttachPoint.sharedMesh = content.bottomDafultMesh;
		SkinnedMeshRenderer[] topsSkinnedList = content.topsSkinnedList;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer5 in topsSkinnedList)
		{
			skinnedMeshRenderer5.enabled = false;
			topIndex = -1;
		}
		SkinnedMeshRenderer[] topsSkinnedList2 = content.topsSkinnedList2;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer6 in topsSkinnedList2)
		{
			if (skinnedMeshRenderer6 != null)
			{
				skinnedMeshRenderer6.enabled = false;
			}
		}
		SkinnedMeshRenderer[] hairSkinnedList = content.hairSkinnedList;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer7 in hairSkinnedList)
		{
			if (skinnedMeshRenderer7 != null)
			{
				skinnedMeshRenderer7.enabled = false;
				hairIndex = -1;
			}
		}
		SkinnedMeshRenderer[] facialDetailsSkinnedList = content.facialDetailsSkinnedList;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer8 in facialDetailsSkinnedList)
		{
			if (skinnedMeshRenderer8 != null)
			{
				skinnedMeshRenderer8.enabled = false;
				facialDetailsIndex = -1;
			}
		}
		SkinnedMeshRenderer[] facialDetailsSkinnedList2 = content.facialDetailsSkinnedList2;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer9 in facialDetailsSkinnedList2)
		{
			if (skinnedMeshRenderer9 != null)
			{
				skinnedMeshRenderer9.enabled = false;
			}
		}
		headMaterial.materials[1].mainTexture = content.defaultHairTexture;
		headMaterial.materials[0].color = new Color(1f, 1f, 1f, 0f);
		backgroundMaterial.mainTexture = content.backgroundsTextureList[0];
		backgroundIndex = -1;
		animationControl.ApplyExpression(6);
		ShowHideBodyParts();
		SkinnedMeshRenderer[] overallsSkinnedList = content.overallsSkinnedList;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer10 in overallsSkinnedList)
		{
			if (skinnedMeshRenderer10 != null)
			{
				skinnedMeshRenderer10.enabled = false;
				overallsIndex = -1;
			}
		}
		ShowHideBodyParts();
		HUDEZ.changeShareButState("resetBut", 0);
	}
}
