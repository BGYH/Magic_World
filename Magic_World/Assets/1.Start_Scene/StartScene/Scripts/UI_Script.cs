using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class UI_Script : MonoBehaviour
{
    public Text chatText;
    
   
    public string writerText = "";
    public int next_Panel = 0;
    public XRController controller = null;
   
    void Start()
    {
        StartCoroutine(Text1());
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    IEnumerator NormalChat(string chat)
    {
        int a = 0;
 
        writerText = "";

        //�ؽ�Ʈ Ÿ���� ȿ��
        for (a = 0; a < chat.Length; a++)
        {
            writerText += chat[a];
            chatText.text = writerText;
            yield return null;
        }

        //Ű�� �ٽ� ���������� ������ ���
        while (true)
        {

            controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool AButton);
            if (AButton == true)
            {
                Debug.Log("press A");//A ��ư ������
                break;
            }
            yield return null;

        }

    }

    IEnumerator Text1()
    {//Ÿ���� ȿ���� �� ��縦 �̰��� �Է�
        yield return StartCoroutine(NormalChat("�� �������� �ϴ��� ���ƺ��ž�"));
        yield return StartCoroutine(NormalChat("�� �տ� �ִ� ģ���� �װ� �����ٰŰ�,"));
        yield return StartCoroutine(NormalChat("�ϴ� �� � ���� Ž���ϰ� ������ �˷��ٷ�?"));
        next_Panel = 1; //�� ������ �гι�ȣ 1�� �ٲٱ�
        yield return StartCoroutine(NormalChat(" "));





    }
}