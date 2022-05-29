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
        yield return StartCoroutine(NormalChat("���� �� �������� ������ �巯���� �����߱���."));
        magic_ring.SetActive(true);
        yield return StartCoroutine(NormalChat("���� �� ���� ���� �� �ϳ��� �����̸� ������."));
        st.GoToScene(2);
        //SceneManager.LoadScene("tutorial02");






    }
    string first_tell_attribute(string name)
    {
        return first_attribute_list[name];
    }
    
    public Dictionary<string, string> first_attribute_list = new Dictionary<string, string>()
    {
        {"earth","���ʺ��� �����ߴ� ������ ����"},{"fire","��� �η������� �������� ���� ����"},{"water","�Ѷ� �Ƿ��� ��¡�̾��� ������ ����"},{"wind","������ �帧�� ������ ���� �ٶ��� ����"},{"electric","�η� ����� ǳ�並 �ҷ��� ������ ����"},{"dark","�ӳ� �� ������ ���� �η����� ���� ������ ����"},{"light","��ο� ���� �ӿ� �ϳ��� ���� �Ǿ��� ���� ����"},{"illusion","��¼�� �츮�� ���� ���ϴ� ���� ���������� �𸣴� ȯ���� ����"}
    };

    string final_tell_attribute(string name)
    {
        return final_attribute_list[name];
    }
    public Dictionary<string, string> final_attribute_list = new Dictionary<string, string>()
    {
        {"earth","���ʺ��� �����ߴ� ������ ���� �����߱���"},{"fire","��� �η������� �������� ���� �����߱���"},{"water","�Ѷ� �Ƿ��� ��¡�̾��� ������ ���� �����߱���"},{"wind","������ �帧�� ������ ���� �ٶ��� ���� �����߱���"},{"electric","�η� ��ο��� ǳ�並 �ҷ��� ������ ���� �����߱���"},{"dark","�ӳ� �� ������ ���� �η����� ���� ������ ���� �����߱���"},{"light","��ο� ���� �ӿ� �ϳ��� ���� �Ǿ��� ���� ���� �����߱���"},{"illusion","��¼�� �츮�� ���� ���ϴ� ���� ���������� �𸣴� ȯ���� ���� �����߱���"}
    };

    
    
   

    
}

