using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ChattingController : MonoBehaviour
{
    public XRController controller = null;
    public Text ChatText;
    public string writerText = "";
    public GameObject Abtn;

    public GameObject Monster;
    public ParticleSystem appearParticle;

    public GameObject FS;
    public GameObject Dragon;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextPractice());
    }

    IEnumerator NormalChat(string narration)
    {
        int a = 0;
        writerText = "";

        //텍스트 타이핑 효과
        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return null;
        }

        //키를 다시 누를때까지 무한정 대기
        while (true)
        {
            controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool AButton);

            if (AButton)
            {
                Debug.Log("Press A");
                break;
            }
            yield return null;
        }
    }

    IEnumerator TextPractice()
    {
        yield return StartCoroutine(NormalChat("이런, 여긴 유령의 숲인데..여기까지 와버렸구나."));
        yield return StartCoroutine(NormalChat("이곳은 들어오면 위험한데..."));
        yield return StartCoroutine(NormalChat(" "));
        Abtn.SetActive(false);

        Debug.Log("---------------- 몬스터 등장 및 공격");

        /*Play_Animation play_ani = GameObject.Find("wizard_weapon_legacy DEMO (1)").GetComponent<Play_Animation>();
        play_ani.GetComponent<MonsterPosition>().MonsterAppear();
        play_ani.attack();
        play_ani.attack_fin();*/

        //Monster.SetActive(true);
        appearParticle.Play();
        StartCoroutine(Monster.GetComponent<MonsterPosition>().MonsterAppear(Monster));
        StartCoroutine(Monster.GetComponent<Play_Animation>().attack());
        StartCoroutine(Monster.GetComponent<Play_Animation>().attack_fin());
        StartCoroutine(FS.GetComponent<FadeScreen>().FadeOut());
        StartCoroutine(FS.GetComponent<FadeScreen>().FadeIn());
        //StartCoroutine(Dragon.GetComponent<DragonPosition>().DragonAppear(Dragon));
        StartCoroutine(fst_Attack());
    }

    public IEnumerator fst_Attack()
    {
        yield return new WaitForSeconds(3.0f);
        Abtn.SetActive(true);
        yield return StartCoroutine(NormalChat("이 숲의 주인이 화가 난 것 같구나."));
        yield return StartCoroutine(NormalChat("마법을 쓰지 않으면 벗어나기 힘들거야."));
        yield return StartCoroutine(NormalChat("오른손의 조이스틱을 위로 올려 지팡이를 꺼내봐."));
        yield return StartCoroutine(NormalChat("왼손의 조이스틱으로 원하는 마법을 선택할 수 있고,조이스틱을 당기면서 오른손의 트리거를 눌러야 공격할 수 있어."));
        yield return StartCoroutine(NormalChat("네 힘을 믿어봐, 벗어날 수 있을 거란다."));
        yield return StartCoroutine(NormalChat(" "));
        Abtn.SetActive(false);
    }

    public IEnumerator finalDragon()
    {
        Debug.Log("마지막 설명창");
        yield return new WaitForSeconds(6.0f);
        Abtn.SetActive(true);
        yield return StartCoroutine(NormalChat("이런, 유령의 힘때문에 마법이 안 나가는 것 같은데?"));
        yield return StartCoroutine(NormalChat("너의 특별한 친구에게 도움을 요청해보렴."));
        yield return StartCoroutine(NormalChat("오른손의 B 버튼을 누르고 별 모양을 그리면 될거야."));
        yield return StartCoroutine(NormalChat(" "));
        Abtn.SetActive(false);
    }
}
