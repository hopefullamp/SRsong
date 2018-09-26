using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditButton : MonoBehaviour {
	
	bool editClicked;

	void Start() {
		editClicked = false;
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "Edit")
                {
                    Debug.Log("Edit");
					if (editClicked == true){
						editClicked = false;
					}
					else if (editClicked == false){
						editClicked = true;
						SceneManager.LoadScene("lobby");
					}
                }
            }
        }
    }

 }