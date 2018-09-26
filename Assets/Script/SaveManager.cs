using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;	


public class SaveManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LoadGame();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SaveGame() {
        PlayerPrefs.SetInt ("main", SceneManager.GetActiveScene ().buildIndex);
        PlayerPrefs.Save ();
        print ("Game saved!");
    }

	public void LoadGame() {
        SceneManager.LoadScene ( PlayerPrefs.GetInt("main") );
        print ("Game loaded!");
    }

}

