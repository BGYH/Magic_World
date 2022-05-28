using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class UI_script3 : MonoBehaviour
{
    public Text chatText;
    //public Text wand_info;
    public string wand;
    public string writerText = "";
    public int move_to_player = 0;
    public GameObject lighting;
    public bool can_change = false; // �����̸� �ǳ��� �� ����� �� �ְ�
    public GameObject Aimage;
    
    public XRController controller = null;
    // Start is called before the first frame update
    void Start()
    {
        
        
        Invoke("delay_start", 2.2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void delay_start()
    {
        StartCoroutine(TextPractice());
    }
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
        SceneTransitionManager st = GameObject.Find("SceneTransitionManager").GetComponent<SceneTransitionManager>();
        lighting.SetActive(true);
        Aimage.SetActive(true);
        yield return StartCoroutine(NormalChat("�̰��� �������� �װ� ����� �����̶���."));
        yield return StartCoroutine(NormalChat("�װ� �� 3���� �Ӽ��� �� �������. �޾� ���Ŷ�."));
        move_to_player = 1;
        can_change = true;
        yield return StartCoroutine(NormalChat("������ ��Ʈ�ѷ��� ���̽�ƽ�� �����ϸ� �����̸� ���� �� ����."));
        yield return StartCoroutine(NormalChat("�ݴ�� �Ʒ��� ������ �ٽ� ������� ���� �ִܴ�."));
        yield return StartCoroutine(NormalChat("���� ���� ���� ���踦 ��� �غ� �Ǿ�����"));
        yield return StartCoroutine(NormalChat("�ູ�� ������ �Ǳ⸦!"));
        st.GoToScene(0);//�̰� ��ġ��





    }
}
