using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record : MonoBehaviour {
	public bool played; 
	public float speed = 19.0f;

	// Use this for initialization
	void Start () {
		played = false; 
	}
	
	// Update is called once per frame
	void Update () {
		if (played == true){
			//Debug.Log("play record");
			//transform.Rotate(new Vector3(0,1,0));
			//현 문제 : 속도에따른 회전 
     		transform.Rotate(new Vector3(0,1,0) * Time.deltaTime * speed);
			
			//+ 터치로 회전 가능하게 만들기 
			//스피어 콜라다 문제 해결 (그 위의 파티클들이 회전해야함)
			//ㄴ 이게 해결이 아닌 새로 나오는 오브젝트들을 모두 
			//empty 를 통해 임의의 중심점을 잡고 해결도 가능할 듯 
			//중심점의 자식으로서 파티클을 임의의 공간에 누를때마다 생성 
			//하지만 원 안에서만 가능하게 해야함!  
			//레이 캐스트를 통해 파티클을 누르면 태그를 확인후 지우게도 가능  
		}
		if (played == false){
			//Debug.Log("stop record");
		}
		//else if 통해 정지기능 만들기
		
	}
}
