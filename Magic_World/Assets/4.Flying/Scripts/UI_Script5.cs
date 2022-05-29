using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class UI_Script5 : MonoBehaviour
{
    public Text chatText;
    
   
    public string writerText = "";
    public int next_Panel = 0;
    public XRController controller = null;
   
    void Start()
    {
        // StartCoroutine(Text1());
        Invoke(nameof(doText), 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void doText()
    {
        Debug.Log("Function started");
        StartCoroutine(Text1());
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
        yield return StartCoroutine(NormalChat("�� �������� �ϴ��� ���ƺ��ž�."));
        yield return StartCoroutine(NormalChat("��� �ϴ��� �� �� �ִ��� �˷����״� �� ����صη�."));
        yield return StartCoroutine(NormalChat("����, ��� �װ� ��ȯ�� �巡���� ��Ÿ���ž�."));
        yield return StartCoroutine(NormalChat("�巡���� ��Ÿ���� �ٰ�����."));
        yield return StartCoroutine(NormalChat("������ ���� Y ��ư�� ������ �巡�￡ Ż �� �ִܴ�."));
        yield return StartCoroutine(NormalChat("��, ������ ������ �޼��� ���̽�ƽ���� �������� �Ѵ� �� ��������."));
        yield return StartCoroutine(NormalChat("�巡�￡ Ÿ�� ���� X��ư�� ������ �ϴ��� ���� �ɰž�."));
        yield return StartCoroutine(NormalChat("�������� A�� B��ư�� ������ �� ���� �� ����, ���� �� ���� ����."));
        yield return StartCoroutine(NormalChat("��ư�� �����鼭 ���̽�ƽ�� ����������."));
        yield return StartCoroutine(NormalChat("Ȥ�ó� �巡�￡�� �������� �;����� Y��ư�� ��� �ٽ� ������ ��."));
        next_Panel = 1; //�� ������ �гι�ȣ 1�� �ٲٱ�
 
        yield return StartCoroutine(NormalChat("��, B��ư�� ���� ���ڴ�? �巡���� ��Ÿ�� �Ŷ���."));
    }
}