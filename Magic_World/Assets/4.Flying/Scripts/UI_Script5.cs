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

        //텍스트 타이핑 효과
        for (a = 0; a < chat.Length; a++)
        {
            writerText += chat[a];
            chatText.text = writerText;
            yield return null;
        }

        //키를 다시 누를때까지 무한정 대기
        while (true)
        {

            controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool AButton);
            if (AButton == true)
            {
                Debug.Log("press A");//A 버튼 누르면
                break;
            }
           
            yield return null;

        }

    }

    IEnumerator Text1()
    {//타이핑 효과를 줄 대사를 이곳에 입력
        yield return StartCoroutine(NormalChat("넌 이제부터 하늘을 날아볼거야."));
        yield return StartCoroutine(NormalChat("어떻게 하늘을 날 수 있는지 알려줄테니 잘 기억해두렴."));
        yield return StartCoroutine(NormalChat("이제, 방금 네가 소환한 드래곤이 나타날거야."));
        yield return StartCoroutine(NormalChat("드래곤이 나타나면 다가가봐."));
        yield return StartCoroutine(NormalChat("가까이 가서 Y 버튼을 누르면 드래곤에 탈 수 있단다."));
        yield return StartCoroutine(NormalChat("아, 가까이 가려면 왼손의 조이스틱으로 움직여야 한단 걸 잊지말렴."));
        yield return StartCoroutine(NormalChat("드래곤에 타고 나서 X버튼을 누르면 하늘을 날게 될거야."));
        yield return StartCoroutine(NormalChat("오른손의 A랑 B버튼을 누르면 더 높게 날 수도, 낮게 날 수도 있지."));
        yield return StartCoroutine(NormalChat("버튼을 누르면서 조이스틱을 움직여보렴."));
        yield return StartCoroutine(NormalChat("혹시나 드래곤에서 내려오고 싶어지면 Y버튼을 길게 다시 누르면 돼."));
        next_Panel = 1; //다 누르면 패널번호 1로 바꾸기
 
        yield return StartCoroutine(NormalChat("자, B버튼을 눌러 보겠니? 드래곤이 나타날 거란다."));
    }
}