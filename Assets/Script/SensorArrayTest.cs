using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensor : MonoBehaviour {
	private AudioSource audioSource;
 	public AudioClip[] note;
 	private AudioClip noteClip;
	//public AudioSource note;

	void Start()
	{
		audioSource = gameObject.GetComponent<AudioSource>();
	}

	
	void OnTriggerStay(Collider other){
		if(other.tag == "Star"){
			Debug.Log("sound");
			int index = Random.Range(0, note.Length);
			//변수 자체를 우선 랜덤으로 지정 
			noteClip = note[index];
			//동일한 형식의 오디오 클립 데이터를 위에서 랜덤으로 지정  
			audioSource.clip = noteClip;
			//오디오 소스의 클립을 위의 클립으로 지정 
			audioSource.Play();
		}
	}
}
