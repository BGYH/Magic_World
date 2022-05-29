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
        yield return StartCoroutine(NormalChat("지팡이를 골랐으니, 여기 있는 3개의 지팡이를 합성해야 해."));
        yield return StartCoroutine(NormalChat("준비 됐니? 자, 시작해보자."));
        Aimage.SetActive(false);
        next_event = 1; //다 누르면 패널번호 1로 바꾸기
        d = 1; //삭제하는 변수 1로 바꾸기
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
