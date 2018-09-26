using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSensor : MonoBehaviour {

	//1. 현재 마우스의 좌표를 받아온다. 
	//2. 현재 마우스의 좌표가 해당 오브젝트의 콜라다에 있다면 
	//3. 스텔라를 켠다. (알파 값을 반쯤으로 조정한다.) 
	//단 콜라다는 꺼져있다. 

	//이제 남은건 마우스가 떼지기전엔 반쯤 켜는 것과 거리별 콜라다 반지름(사이즈) 조정,
	//그리고 지우개 기능이다. 


	 public GameObject sphereCollider;
	 public Collider stellarCollider;
	 public GameObject light;
	 public float rayRadius = 1250.0f;
	 public GameObject stellar;
	 public bool testOn;

     //public GameObject goOne;
     //public GameObject center;
     
	 bool turnOn;


     GameObject initiateGO;
     //int nextNameNumber = 0;
	 //float timeCount = 0;


	void Start(){
		turnOn = false; 

	}
 
    void Update () 
    {


		//if (Input.GetMouseButton(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			//timeCount = timeCount + Time.deltaTime * 1;

				if (Physics.Raycast(ray, out hit, rayRadius)){
					if (Input.GetMouseButton(0) && hit.collider.gameObject==sphereCollider && turnOn == false) {	
					//별이 반쯤 켜질때 O - 테스트로 소리가 한번 나야함. 
							//Debug.Log("TestTurnOn");
							stellar.SetActive(true);
							light.SetActive(true);
							//light.enabled=true;
							stellarCollider.enabled=false;
							stellar.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,.3f);
							stellar.GetComponent<SpriteRenderer>().enabled = true;
							testOn = true;
					}

					else if (Input.GetMouseButtonUp(0) && hit.collider.gameObject==sphereCollider && turnOn == false)  {
					//별이진짜 켜질 때 O
					//마우스가 별에가서 터치하고 별을 떼었을 때
						stellar.SetActive(true);
						light.SetActive(true);
						stellar.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
						stellar.GetComponent<SpriteRenderer>().enabled = true;
						stellarCollider.enabled = true;
						//light.enabled=true;
						turnOn=true;
						//Debug.Log("Turn On");
						testOn = false;
						//timeCount = 0;
					
					}
					//별을 지울 때 O
					else if(Input.GetMouseButtonUp(0) && hit.collider.gameObject==sphereCollider && turnOn == true){ 
						stellar.SetActive(false);
						light.SetActive(false);
						stellar.GetComponent<SpriteRenderer>().enabled = false;
						stellarCollider.enabled = false;
						//light.enabled = false;
						turnOn = false; 
						testOn = false;
						//Debug.Log("Delete");
						//timeCount = 0;
					}

					else if (hit.collider.gameObject!=sphereCollider && turnOn == false){
						stellar.SetActive(false);
						light.SetActive(false);
						stellar.GetComponent<SpriteRenderer>().enabled = false;
						stellarCollider.enabled = false;
					}
		
				}
				//별이 완전히 꺼질 때 
				else if(turnOn == false) {
					//진짜 문제는 이 것이다. 
					//현재 이 조건으로 코드가 통과할 때마다 매우 느려지게 된다. 
					
					//Debug.Log("TestTurnOff");
					stellar.SetActive(false);
					light.SetActive(false);
					stellar.GetComponent<SpriteRenderer>().enabled = false;
					stellarCollider.enabled = false;
					//light.enabled=false; 
					//testOn = false;
					//timeCount=0;
				}

						
	}		
}





