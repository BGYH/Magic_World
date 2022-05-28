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
    public bool can_change = false; // 지팡이를 건내준 후 사용할 수 있게
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
        yield return StartCoroutine(NormalChat("이것이 이제부터 네가 사용할 지팡이란다."));
        yield return StartCoroutine(NormalChat("네가 고른 3개의 속성이 다 담겨있지. 받아 가거라."));
        move_to_player = 1;
        can_change = true;
        yield return StartCoroutine(NormalChat("오른쪽 컨트롤러의 조이스틱을 위로하면 지팡이를 꺼낼 수 있지."));
        yield return StartCoroutine(NormalChat("반대로 아래로 내리면 다시 집어넣을 수도 있단다."));
        yield return StartCoroutine(NormalChat("이제 정말 마법 세계를 즐길 준비가 되었구나"));
        yield return StartCoroutine(NormalChat("행복한 여행이 되기를!"));
        st.GoToScene(3);//이거 고치기





    }
}
