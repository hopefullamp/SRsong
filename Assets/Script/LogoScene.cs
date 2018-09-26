using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogoScene : MonoBehaviour {
	public Image fadeImage;

	// Use this for initialization
	void Start () {
		StartCoroutine("FadeIn");
		
	}

	IEnumerator FadeIn(){
		Color startColor = fadeImage.color;

		for(int i = 0; i < 100; i++){
			startColor.a = startColor.a - 0.01f;
			fadeImage.color = startColor;
			yield return new WaitForSeconds(0.01f);
		}
		SceneManager.LoadScene("lobby");
	}
}
