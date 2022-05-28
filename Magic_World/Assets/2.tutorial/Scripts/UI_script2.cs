using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class UI_script2 : MonoBehaviour
{
    public GameObject pop;
    public Text chatText;
    public string wand;
    public string writerText = "";
    public int next_event = 0;
    public GameObject new_wand;
    public int d = 0;
    private AudioSource audio;
    public AudioClip poping_sound;
    public GameObject Aimage;

    public XRController controller = null;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextPractice());
    }

    // Update is called once per frame
    void Update()
    {
        
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
        yield return StartCoroutine(NormalChat("���� ���� �ִ� 3���� �����̸� �ռ��� ���ʶ���."));
        yield return StartCoroutine(NormalChat("�غ� �ƴ�? �׷� �����غ���!"));
        Aimage.SetActive(false);
        next_event = 1; //�� ������ �гι�ȣ 1�� �ٲٱ�
        d = 1; //�����ϴ� ���� 1�� �ٲٱ�
        pop.SetActive(true);
        play_sound();
        //new_wand.SetActive(true);
        yield return StartCoroutine(NormalChat(" "));
        




    }
    void play_sound()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.poping_sound;
        this.audio.loop = false;
        this.audio.Play();
    }
}
