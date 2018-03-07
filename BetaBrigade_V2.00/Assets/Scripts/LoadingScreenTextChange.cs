using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenTextChange : MonoBehaviour {

	public Text m_MyText;
	public string[] loadingScreenText;

	// Use this for initialization
	void Start ()
	{
		int textNumber = Random.Range(0, loadingScreenText.Length);
		m_MyText.text = loadingScreenText[textNumber];
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
