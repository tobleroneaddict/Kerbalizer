using UnityEngine;
using System.Collections;

public class goofyworkaround : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		BoxCollider bc = GetComponent<BoxCollider>();
		if (bc != null)
		{
			bc.enabled = false;
		}
	}
}
