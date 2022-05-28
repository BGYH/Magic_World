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
            
        //    for(int i = 100; i >= 0; i--)  //���̵� �ƿ�
        //    {
        //        color.a -= Time.deltaTime * 0.01f; // ���İ�(����)�� ������
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
        yield return StartCoroutine(NormalChat("�ȳ�? �װ� �̹��� ���� ���̱���."));
        yield return StartCoroutine(NormalChat("����� ���õ� �ΰ����� ���� �� �ִ� ���̶���."));
        yield return StartCoroutine(NormalChat("���⼭ ��Ȱ�Ϸ��� �����̰� �ʿ��� �ž�."));
        yield return StartCoroutine(NormalChat("�ʸ� �ѷ��ΰ� �ִ� ������ �� 3���� ��󺸷�."));
        yield return StartCoroutine(NormalChat("������ �� �����ϰ� �ؾ� ��."));
        yield return StartCoroutine(NormalChat("�� �� �� ������ ���� �ٲ� �� ���ܴ�."));
        yield return StartCoroutine(NormalChat("���ϴ� �����̸� ����Ű�� B��ư�� ������."));
        Aimage.SetActive(false);
        next_Panel = 1; //�� ������ �гι�ȣ 1�� �ٲٱ�
        yield return StartCoroutine(NormalChat(" "));





    }
}
