using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour {
	public Record LoadRecord;
	//레코드 클래스에 접속 

    //몇초동안 45도(특정방향)까지 회전하기 (원하는 시간초)
    //특정방향으로 회전 시키기 (각도조절) (각도 / 시간)
    //이 오브젝트의 벡터 데이터를 받고 
    //그 벡터 회전 데이터가 특정각도가 될 때 까지 회전시키자. (조건부 루프 이용) 
    //다시 눌러지면 다시 원상태로 복귀하기

    public GameObject sensor;
    //public GameObject grid;

    private Vector3 axis = new Vector3( 0, -1, 0 );
    private float degrees = 45f;
    private float timespan = 1f;
    
    private bool switched = false;
   
    private float _rotated = 0;
    private Vector3 _rotationVector;

    private int touched = 3;
    //true 또는 false 가 아닌 idle 상태가 필요했다. 
   
    public void Start()
    {
        //센서세팅
        //sensor = GameObject.FindGameObjectWithTag("Head");
        
        //각도 세팅
        axis.Normalize();
        _rotationVector = axis * degrees;

        sensor.SetActive(false);
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
                    //Debug.Log("Play");
					//if (LoadRecord.played == true){
					//	LoadRecord.played = false;
                    if (switched == true){
                        switched = false;
                        //grid.SetActive(true);
                        touched = 0;
                        //Debug.Log("Touched : "+touched);
                    }

					else if (switched == false){
                        switched = true;
                        //grid.SetActive(false);
                        touched = 1;
                    //지금 이게 헤드 턴의 시작이다. 
                    //불린 toched 만을 조건부로 할 경우 버튼을 누르지도 않았는데 돌아가버린다

                    //여기에서 각각 딜레이를 레코드에게 헤드가 돌아가는 시간동안 주어야한다.
                    }
                }
            }
        }

        if (touched == 1){
            axis = new Vector3( 0, -1, 0 );
            _rotationVector = axis * degrees;
            //Debug.Log("axis : " +axis);
            if ( degrees >= _rotated ){
            _rotated += degrees * (Time.deltaTime / timespan);
            transform.Rotate( _rotationVector * (Time.deltaTime / timespan) );
            }
            //Debug.Log("_rotated : "+_rotated);

                if (_rotated >= 45) { //헤드가 45도만큼 회전했을 경우 
                //45도가 완벽하게 되지 않는다. 
                if (LoadRecord.played == false){
			    LoadRecord.played = true;
                sensor.SetActive(true);
                
                }
                //여기에서 센터를 돌려주는동안  
                //헤드의 콜라다를 켠다. 
            }
        }

        if (touched == 0){

            sensor.SetActive(false);
        
            //Debug.Log("SetActive Fasle"); 
            //여기에서 센터를 정지하는동안
            //헤드의 콜라다를 끈다. 

            if (LoadRecord.played == true){
            LoadRecord.played = false;
            }

            axis = new Vector3( 0, 1, 0 );
            _rotationVector = axis * degrees;
            //Debug.Log("axis : " +axis);
            if ( _rotated > 0 ){
            _rotated -= degrees * (Time.deltaTime / timespan);
            transform.Rotate( _rotationVector * (Time.deltaTime / timespan) );
            }
            //Debug.Log("_rotated : "+_rotated);
        }
    }
}