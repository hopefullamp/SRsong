using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyScene : MonoBehaviour {
	//public Record LoadRecord;
	bool clicked;
	//레코드 클래스에 접속 
	void Start (){
		clicked = false;
	}
     void Update()
     {
         if (Input.GetMouseButtonDown(0))
         {
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             RaycastHit hitInfo;
             if (Physics.Raycast(ray, out hitInfo))
             {
                 if (hitInfo.collider.gameObject.tag == "Play")
                 {
                    Debug.Log("Play");
					if (clicked == true){
						clicked = false;
					}
					else if (clicked == false){
						clicked = true;
						SceneManager.LoadScene("main");
					}
                 }
             }
         }
     }

 }