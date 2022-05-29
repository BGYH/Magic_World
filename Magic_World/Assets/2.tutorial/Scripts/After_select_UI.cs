using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;

public class After_select_UI : MonoBehaviour
{
    public Text chatText;
    //public Text wand_info;
    public string wand;
    public string writerText = "";
    public int next_Panel = 0;
    public XRController controller = null;
    public string first, second, third;
    int num = 0;
    public GameObject magic_ring;
    public GameObject Aimage;

    void Start()
    {
        
        UI_script UI_script = GameObject.Find("next_start").GetComponent<UI_script>();
        ray_interactor_wand ray_interactor_wand = GameObject.Find("Ray Interactor").GetComponent<ray_interactor_wand>();
         
        //StartCoroutine(TextPractice());
        
        
        //image = this.GetComponent<Image>();
        //Invoke("TextPractice", 5);
    }

    // Update is called once per frame
    void Update()
    {
        UI_script UI_script = GameObject.Find("next_start").GetComponent<UI_script>();
        if (UI_script.next_Panel == 2)
        {
            if (num == 0)
            {
                StartCoroutine(TextPractice());
                num = 1;

            }
            
        }
        
    }


    //IEnumerator NormalChat(string chat, string wand)
    IEnumerator NormalChat(string chat)
    {
        int a = 0;
        //wand_info.text = wand;
        writerText = "";


        for (a = 0; a < chat.Length; a++)
        {
            writerText += chat[a];
            chatText.text = writerText;
            yield return null;
        }


        while (true)
        {

            controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool AButton);

            if (AButton == true)
            {
                Debug.Log("press A");

                break;
            }

            yield return null;


        }

    }

    IEnumerator TextPractice()
    {
        ray_interactor_wand ray_interactor_wand = GameObject.Find("Ray Interactor").GetComponent<ray_interactor_wand>();
        SceneTransitionManager st = GameObject.Find("SceneTransitionManager").GetComponent<SceneTransitionManager>();
        Aimage.SetActive(true);
        yield return StartCoroutine(NormalChat(first_tell_attribute(ray_interactor_wand.select_wandname[0])));
        yield return StartCoroutine(NormalChat(first_tell_attribute(ray_interactor_wand.select_wandname[1])));
        yield return StartCoroutine(NormalChat(final_tell_attribute(ray_interactor_wand.select_wandname[2])));
        yield return StartCoroutine(NormalChat("드디어 네 지팡이의 윤곽이 드러나기 시작했구나."));
        magic_ring.SetActive(true);
        yield return StartCoroutine(NormalChat("이제 이 힘을 담은 단 하나의 지팡이를 만들어보자."));
        st.GoToScene(2);
        //SceneManager.LoadScene("tutorial02");






    }
    string first_tell_attribute(string name)
    {
        return first_attribute_list[name];
    }
    
    public Dictionary<string, string> first_attribute_list = new Dictionary<string, string>()
    {
        {"earth","태초부터 존재했던 대지의 힘과"},{"fire","모든 인류문명의 시작점인 불의 힘과"},{"water","한때 권력의 상징이었던 얼음의 힘과"},{"wind","세상의 흐름을 느끼게 해준 바람의 힘과"},{"electric","인류 모두의 풍요를 불러온 전기의 힘과"},{"dark","머나 먼 우주의 깊은 두려움을 담은 암흑의 힘과"},{"light","어두운 세상 속에 하나의 길이 되어준 빛의 힘과"},{"illusion","어쩌면 우리가 가장 원하는 것을 가져다줄지 모르는 환각의 힘과"}
    };

    string final_tell_attribute(string name)
    {
        return final_attribute_list[name];
    }
    public Dictionary<string, string> final_attribute_list = new Dictionary<string, string>()
    {
        {"earth","태초부터 존재했던 대지의 힘을 선택했구나"},{"fire","모든 인류문명의 시작점인 불을 선택했구나"},{"water","한때 권력의 상징이었던 얼음의 힘을 선택했구나"},{"wind","세상의 흐름을 느끼게 해준 바람의 힘을 선택했구나"},{"electric","인류 모두에게 풍요를 불러온 전기의 힘을 선택했구나"},{"dark","머나 먼 우주의 깊은 두려움을 담은 암흑의 힘을 선택했구나"},{"light","어두운 세상 속에 하나의 길이 되어준 빛의 힘을 선택했구나"},{"illusion","어쩌면 우리가 가장 원하는 것을 가져다줄지 모르는 환각의 힘을 선택했구나"}
    };

    
    
   

    
}

