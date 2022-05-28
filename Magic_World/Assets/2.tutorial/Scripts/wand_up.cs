using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wand_up : MonoBehaviour
{
    public float time1;
    public int num =0;
    public GameObject find;
    public GameObject player;
    public Vector3 player_pos;
    //Vector3 target_pos = new Vector3(-0.367f, 6.61f, 25.32f);
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            UI_script2 s2 = GameObject.Find("UI_Controller").GetComponent<UI_script2>();
            if (s2.next_event == 2)
            {
                //오브젝트 켜기
                GameObject.Find("UI_Controller2").transform.Find("Script2").gameObject.SetActive(true);
                s2.next_event = 3;
            }
        }
        catch
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        transform_wand();
        
    }
    void transform_wand()
    {
        Vector3 target_pos = new Vector3(-0.367f, 6.61f, 25.32f);
        try
        {
            UI_script2 s2 = GameObject.Find("UI_Controller").GetComponent<UI_script2>();
            
            if (s2.next_event == 1)
            {
                transform.position = Vector3.MoveTowards(this.transform.position, target_pos, 0.1f); //시작지점, 목표지점, 속도
                Destroy(gameObject, 3);
                
            }
            else if (s2.next_event > 1)
            {
                gameObject.GetComponent<floating_wand>().enabled = false;
                Debug.Log("false");
                try
                {
                    //UI_script3 s3 = GameObject.Find("Script2").GetComponent<UI_script3>();
                    UI_script3 s3 = GameObject.Find("UI_Controller2").transform.Find("Script2").GetComponent<UI_script3>();
                    player_pos = new Vector3(0.0f, 2.7f, 16.67f); //플레이어가 지팡이를 받을 포지션
                    Debug.Log("start move");
                    if (s3.move_to_player == 1)
                    {
                        Debug.Log("move_player ok");
                        transform.position = Vector3.MoveTowards(this.transform.position, player_pos, 0.1f);
                        transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                        if (this.transform.position == player_pos)
                        {
                            //s3.move_to_player = 0;
                            Destroy(gameObject);
                            

                        }

                    }
                }
                catch
                {
                    Debug.Log("error");
                }
            }
            
        }
        catch
        {

        }
        
        
        
        
        

    }
    private void OnDestroy()
    {
        try
        {
            UI_script2 s2 = GameObject.Find("UI_Controller").GetComponent<UI_script2>();
            if (s2.next_event == 1)
            {
                s2.next_event = 2;
                GameObject.Find("new_pos").transform.Find("new_wand").gameObject.SetActive(true);
            }
            else if (s2.next_event == 2)
            {

            }
        }
        catch
        {

        }
        try
        {
            UI_script3 s3 = GameObject.Find("UI_Controller2").transform.Find("Script2").GetComponent<UI_script3>();
            if (s3.move_to_player == 1)
            {
                s3.move_to_player = 2;
            }
        }
        catch
        {

        }
        

    }

}
