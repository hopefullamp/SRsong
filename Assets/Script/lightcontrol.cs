using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightcontrol : MonoBehaviour {
    public Light thisLight;
     public float minIntensity = 0.25f;
     public float maxIntensity = 0.5f;
     //public Record LoadRecord;//script
     //public GameObject Center;//object
     
     public TouchSensor touchSensor;

    // public NameoftheScript other;
    // public GameObject SpawnZone;
 
     float random;
 
    void Awake ()
     {
        //프리팹에서 클래스 접속이 안된다면 오브젝트를 직접 찾아서 달아주자 
        // Setting up the reference.
        // GameObject SpawnZone = GameObject.Find("NameoftheGameObject");     
        // other = SpawnZone.GetComponent<NameoftheScript >(); 
        //GameObject Center = GameObject.Find("Center");                  
        //LoadRecord = Center.GetComponent<Record>();
     }

     void Start()
     {
        //light.enabled=false;
        random = Random.Range(0.0f, 65535.0f);
     }
 
     void Update()
     {
        if(touchSensor.testOn == false){
            maxIntensity = 0.5f;

        } else {
            maxIntensity = 1.5f;
        }

        //light.enabled=true;
        float noise = Mathf.PerlinNoise(random, Time.time);
        thisLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);

         /* 
         if (LoadRecord.played == false){
            light.enabled=false;
         }
         else {
            light.enabled=true;
            float noise = Mathf.PerlinNoise(random, Time.time);
            light.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
         }
         */
     }
 }