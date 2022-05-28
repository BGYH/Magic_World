using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class UI_script : MonoBehaviour
{
    public Text chatText;
    //public Text wand_info;
    public string wand;
    public string writerText = "";
    public int next_Panel = 0;
    public XRController controller = null;
    public GameObject Aimage;
    //private InputDevice targetDevice;
    //Image image;
    //public GameObject start_ui;
    //public GameObject wandinfo_ui;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextPractice());
        //image = this.GetComponent<Image>();
        //Invoke("TextPractice", 5);
    }

    // Update is called once per frame
    void Update()
    {
        ////Color color = image.color;
        
        //if (next_Panel == 1)
        //{
            
        //    for(int i = 100; i >= 0; i--)  //페이드 아웃
        //    {
        //        color.a -= Time.deltaTime * 0.01f; // 알파값(투명도)를 조절함
        //        image.color = color;
        //    }
            
        //}
        
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

            if(AButton == true)
            {
                Debug.Log("press A");

                break;
            }
                
            yield return null;


        }
        
    }
    
    IEnumerator TextPractice()
    {
        yield return StartCoroutine(NormalChat("안녕? 네가 이번에 들어온 아이구나."));
        yield return StartCoroutine(NormalChat("여기는 선택된 인간만이 들어올 수 있는 숲이란다."));
        yield return StartCoroutine(NormalChat("여기서 생활하려면 지팡이가 필요할 거야."));
        yield return StartCoroutine(NormalChat("너를 둘러싸고 있는 지팡이 중 3개를 골라보렴."));
        yield return StartCoroutine(NormalChat("선택은 늘 신중하게 해야 해."));
        yield return StartCoroutine(NormalChat("한 번 한 선택은 절대 바꿀 수 없단다."));
        yield return StartCoroutine(NormalChat("원하는 지팡이를 가리키고 B버튼을 누르렴."));
        Aimage.SetActive(false);
        next_Panel = 1; //다 누르면 패널번호 1로 바꾸기
        yield return StartCoroutine(NormalChat(" "));





    }
}
