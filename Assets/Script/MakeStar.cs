using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeStar : MonoBehaviour {

    //public GameObject goOne;


 
    public GameObject center;
    public GameObject grid;
    public Transform star;
    public Transform StellarCenter;
    Vector3 Center;
    Vector3 Record;
    //Vector3 StellarCenterScale;
    //Vector3 StellarCenterPosition;
    Vector3 xPosition;
    Quaternion rotation;

    //public Sensor sensor;

    bool goReady;
 
    //int nextNameNumber = 0;

	void Start(){
        goReady = true;
        float stellarCount = 15;
       
         
        Center = GameObject.FindGameObjectWithTag("MainCenter").transform.position;
        Record = GameObject.FindGameObjectWithTag("MainRecord").transform.lossyScale;
        //StellarCenterScale = GameObject.FindGameObjectWithTag("StellarCenter").transform.lossyScale;
        //StellarCenterPosition = GameObject.FindGameObjectWithTag("StellarCenter").transform.localPosition;


        Record.y = 0;
        Record.x = 0;
        Center.y = 0;

        float radius = Vector3.Distance(Center, Record / 2);
        //Debug.Log("makeCenter : " + Center);
        //Debug.Log("makeRecord : " + Record);
        //Debug.Log("makeRadius : "+radius);


        int i = 0;

        for (i = 0; i < stellarCount+1; i++)

         //높이를 -0.5 
        {//23 //23.1

            if (i == stellarCount) {
            }
            else{
                xPosition = new Vector3 ((i+1)*radius/(stellarCount+1),0f/*높이*/,0.0f/*z*/);
                //Debug.Log("xPosition: " + xPosition);
                rotation = Quaternion.Euler(0,0,0);
                Transform instance = Instantiate(star, xPosition, rotation);
                instance.transform.parent = StellarCenter.transform;
            }
        }
        
        
        float barCount = 32; //마디의 수 
        for (int r = 0; r < barCount - 1; r++)
        {
            //현재의 문제점 : 첫번째 for 문을 실행하는데에는 문제가 없으나 그 다음부터 스케일 값이 바뀌어 버린다  
            //분명 이 것은 각도를 회전하면서 생기는 문제임이 분명하다 (아마 그렇게 되는데에는 월드 스케일을 받는 이유가 클 것이다) 
            //이렇게 되면 나중에 서브레코드를 활용하는데 있어서 매우 큰 어려움이 생긴다... 

            Quaternion rotation2 = Quaternion.Euler(0, (r + 1) * 360 / barCount, 0);
            Transform instance2 = Instantiate(StellarCenter, new Vector3(0, 0, 0), rotation2);
            //Debug.Log("instance2 : " + instance2.transform);
            
            //setparent 를 추천받았다
            //코드 가독성  
            
            instance2.transform.SetParent(center.transform);
            //instance2.transform.parent = center.transform;
            
        }
        
        
        

        


        
        
        /* 
        for(int x=1;x>15;x++){

            Vector3 xPosition = new Vector3 (x*radius/16,1.0f,0.0f);
            GameObject instance = Instantiate(star,xPosition,Quaternion.identity);
            //Instantiate(star,xPosition,Quaternion.identity);
            instance.transform.parent = center.transform;

            for(int r=0;r<16;r++){

            }
        
        */
    }
 
    void Update () 
    {



        if (Input.GetMouseButton(0))
        {
            
            if (goReady)
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                //RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Record") //&& Input.GetMouseButtonDown(0))
                    {
                        //grid.SetActive(true);
                        
                        
                        
                    }

                }
            }
        }
        else if (Input.GetMouseButtonUp(0)){


            //star.GetComponent<Renderer>().enabled = false;
            //grid.SetActive(false);
            if (goReady)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                
                if (Physics.Raycast(ray, out hit)){
                    if (hit.collider.gameObject.tag == "Record")//&& Input.GetMouseButtonDown(0))
                    {

                        //grid.SetActive(false);
                        //hit.point = new Vector3 (hit.point.x, 0.5f, hit.point.z);
                        //GameObject instance = Instantiate(initiateGO,hit.point,Quaternion.identity);
                        //instance.transform.parent = center.transform;
                    }
                    /*
                    }
                    else if (hit.collider.gameObject.tag == "Star"){

                        if (Physics.Raycast(ray, out hit, 1000.0f) && Input.GetMouseButtonUp(0)) // On left click we send down a ray
                            Destroy(hit.collider.gameObject); // Destroy what we hit
                    }
                    */
                }
            }
        }
    }
}
