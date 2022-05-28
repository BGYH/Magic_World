using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using System.Linq;
public class ray_interactor_wand : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    private RaycastHit Collided_object;
    public float raycastDistance = 100f;
    public Text earth;
    public Text fire;
    public Text water;
    public Text wind;
    public Text electric;
    public Text dark;
    public Text light;
    public Text illusion;
    public XRController controller = null;
    public GameObject earth_fire;
    public GameObject fire_fire;
    public GameObject water_fire;
    public GameObject wind_fire;
    public GameObject electric_fire;
    public GameObject dark_fire;
    public GameObject light_fire;
    public GameObject illusion_fire;
    public int select = 0;
    public List<string> select_wandname = new List<string>();
    public bool one_time = false;
    public int save_num = 0;
    private AudioSource audio;
    public AudioClip select_fire;
    public int[] select_bgm = new int[8] {0,0,0,0,0,0,0,0};

    Canvas canvas2;
    public Dictionary<string, int> wand_dic = new Dictionary<string, int>()
    {
        {"earth",0 },{"fire",0},{"water",0},{"wind",0},{"electric",0},{"dark",0},{"light",0},{"illusion",0}
    };
    // Start is called before the first frame update
    void Start()
    {
        
        GetComponent<Text>();

        wand_dic["earth"] = 0;
        wand_dic["fire"] = 0;
        wand_dic["water"] = 0;
        wand_dic["wind"] = 0;
        wand_dic["electric"] = 0;
        wand_dic["dark"] = 0;
        wand_dic["light"] = 0;
        wand_dic["illusion"] = 0;
        //select_wandname[0] = null;
        //select_wandname[1] = null;
        //select_wandname[2] = null;


    }

    // Update is called once per frame
    void Update()
    {
        check3();
        UI_script UI_script = GameObject.Find("next_start").GetComponent<UI_script>();
        if (UI_script.next_Panel != 0)
        {
            //if (UI_script.next_Panel == 2)
            //{
            //    Debug.Log(select_wandname[0]);
            //    Debug.Log(select_wandname[1]);
            //    Debug.Log(select_wandname[2]);
            //}

            if (Physics.Raycast(transform.position, transform.forward, out Collided_object, raycastDistance))
            {
                //UI_script UI_script = GameObject.Find("Start_UI").GetComponent<UI_script>();
                //Wand1_text wand1_Text = GameObject.Find("Wand_1").GetComponent<Wand1_text>();

                if (Collided_object.collider.gameObject.CompareTag("earth"))
                {
                    //UI_script.wand_info.text = "숲의 지팡이";
                    //wand1_Text.wand1_info.text = "숲의 지팡이";
                    earth.text = "대지의 지팡이";
                    if (controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool BButton))// || Input.GetMouseButtonDown(0) a버튼누르면 으로 해야함
                    {

                        if (BButton == true)
                        {
                            //Debug.Log("select earthwand");
                            Debug.Log("start"+select_bgm[0]);
                            fire_sound(select_bgm[0]);
                            Debug.Log("m"+select_bgm[0]);
                            select_bgm[0] = 1;
                            Debug.Log("end"+select_bgm[0]);
                            select_wand(0);
                            //wand_dic["earth"] = 1;
                        }

                        
                    }
                }
                else
                {
                    earth.text = " ";
                    
                }

                if (Collided_object.collider.gameObject.CompareTag("fire"))
                {
                    fire.text = "불의 지팡이";
                    if (controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool BButton))// || Input.GetMouseButtonDown(0) a버튼누르면 으로 해야함
                    {

                        if (BButton == true)
                        {
                            //Debug.Log("select");
                            fire_sound(select_bgm[1]);
                            select_bgm[1] = 1;
                            select_wand(1);
                            //wand_dic["fire"] = 1;
                        }


                    }
                    
                }
                else
                {
                    //wand1_Text.wand1_info.text = "";
                    fire.text = " ";
                    
                }
                if (Collided_object.collider.gameObject.CompareTag("water"))
                {
                    water.text = "얼음의 지팡이";
                    if (controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool BButton))// || Input.GetMouseButtonDown(0) a버튼누르면 으로 해야함
                    {

                        if (BButton == true)
                        {
                            //Debug.Log("select");
                            fire_sound(select_bgm[2]);
                            select_bgm[2] = 1; //한번 선택하면 소리가 나지 않게
                            select_wand(2);
                            //wand_dic["water"] = 1;
                        }


                    }

                }
                else
                {
                    //wand1_Text.wand1_info.text = "";
                    water.text = " ";
                    
                }
                if (Collided_object.collider.gameObject.CompareTag("wind"))
                {
                    wind.text = "바람의 지팡이";
                    if (controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool BButton))// || Input.GetMouseButtonDown(0) a버튼누르면 으로 해야함
                    {

                        if (BButton == true)
                        {
                            //Debug.Log("select");
                            fire_sound(select_bgm[3]);
                            select_bgm[3] = 1;
                            select_wand(3);
                            //wand_dic["wind"] = 1;
                        }


                    }

                }
                else
                {
                    //wand1_Text.wand1_info.text = "";
                    wind.text = " ";
                    
                }
                if (Collided_object.collider.gameObject.CompareTag("electric"))
                {
                    electric.text = "전기의 지팡이";
                    if (controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool BButton))// || Input.GetMouseButtonDown(0) a버튼누르면 으로 해야함
                    {

                        if (BButton == true)
                        {
                            //Debug.Log("select");
                            fire_sound(select_bgm[4]);
                            select_bgm[4] = 1;
                            select_wand(4);
                            //wand_dic["elctric"] = 1;
                        }


                    }

                }
                else
                {
                    //wand1_Text.wand1_info.text = "";
                    electric.text = " ";
                    
                }
                if (Collided_object.collider.gameObject.CompareTag("dark"))
                {
                    dark.text = "암흑의 지팡이";
                    if (controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool BButton))// || Input.GetMouseButtonDown(0) a버튼누르면 으로 해야함
                    {

                        if (BButton == true)
                        {
                            //Debug.Log("select");
                            fire_sound(select_bgm[5]);
                            select_bgm[5] = 1;
                            select_wand(5);
                            //wand_dic["dark"] = 1;
                        }


                    }

                }
                else
                {
                    //wand1_Text.wand1_info.text = "";
                    dark.text = " ";
                    
                }
                if (Collided_object.collider.gameObject.CompareTag("light"))
                {
                    light.text = "빛의 지팡이";
                    if (controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool BButton))// || Input.GetMouseButtonDown(0) a버튼누르면 으로 해야함
                    {

                        if (BButton == true)
                        {
                            //Debug.Log("select");
                            fire_sound(select_bgm[6]);
                            select_bgm[6] = 1;
                            select_wand(6);
                            //wand_dic["light"] = 1;
                        }


                    }

                }
                else
                {
                    //wand1_Text.wand1_info.text = "";
                    light.text = " ";
                    
                }
                if (Collided_object.collider.gameObject.CompareTag("illusion"))
                {
                    illusion.text = "환각의 지팡이";
                    if (controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool BButton))// || Input.GetMouseButtonDown(0) a버튼누르면 으로 해야함
                    {

                        if (BButton == true)
                        {
                            //Debug.Log("select");
                            fire_sound(select_bgm[7]);
                            select_bgm[7] = 1;
                            select_wand(7);
                            //wand_dic["illusion"] = 1;
                        }


                    }

                }
                else
                {
                    //wand1_Text.wand1_info.text = "";
                    illusion.text = " ";
                    
                }
            }
            else
            {
                
            }
        }
        

    }

    
    void save_wand()
    {
        //if (one_time)
        //{
        
        Save_Wand save_wand = GameObject.Find("next_start").GetComponent<Save_Wand>();
        for (int i=0;i<wand_dic.Count; i++)
        {
            if (wand_dic.Values.ElementAt(i) == 1)
            {
                
                select_wandname.Add(wand_dic.Keys.ElementAt(i)); //리스트에 선택한 지팡이 이름 넣어주기
                
            }
            
        }
        

    }
    void select_wand(int a)
    {
        UI_script UI_script = GameObject.Find("next_start").GetComponent<UI_script>();
        if (select == 3)
        {
            return;
        }
        switch (a)
        {
            case 0:
                earth_fire.SetActive(true);
                wand_dic["earth"] = 1;
                break;
            case 1:
                fire_fire.SetActive(true);
                wand_dic["fire"] = 1;
                break;
            case 2:
                water_fire.SetActive(true);
                wand_dic["water"] = 1;
                break;
            case 3:
                wind_fire.SetActive(true);
                wand_dic["wind"] = 1;
                break;
            case 4:
                electric_fire.SetActive(true);
                wand_dic["electric"] = 1;
                break;
            case 5:
                dark_fire.SetActive(true);
                wand_dic["dark"] = 1;
                break;
            case 6:
                light_fire.SetActive(true);
                wand_dic["light"] = 1;
                break;
            case 7:
                illusion_fire.SetActive(true);
                wand_dic["illusion"] = 1;
                break;
            

        }
    }
    void check3()
    {
        UI_script UI_script = GameObject.Find("next_start").GetComponent<UI_script>();
        if(select == 3)
        {
            return;
        }
        select = 0;
        
        for (int i = 0; i < wand_dic.Count; i++)
        {
            select += wand_dic.Values.ElementAt(i);
            if (select == 3)
            {
                //one_time = true;
                save_wand();
                save_num = 1;
                UI_script.next_Panel = 2;
                
                break;
            }
            
        }


    }
    void fire_sound(int a)
    {
        UI_script UI_script = GameObject.Find("next_start").GetComponent<UI_script>();
        if (UI_script.next_Panel == 1)
        {
            if(a == 0)
            {
                this.audio = this.gameObject.AddComponent<AudioSource>();
                this.audio.clip = this.select_fire;
                this.audio.loop = false;
                this.audio.volume = 0.5f;
                this.audio.Play();
            }
            
        }
        
    }
    
}
