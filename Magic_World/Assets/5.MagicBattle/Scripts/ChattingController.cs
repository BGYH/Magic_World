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

        //�ؽ�Ʈ Ÿ���� ȿ��
        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return null;
        }

        //Ű�� �ٽ� ���������� ������ ���
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
        yield return StartCoroutine(NormalChat("�̷�, �Ǽ��� ������ ���� ������ ���ұ���."));
        yield return StartCoroutine(NormalChat("�̰��� ������ �����ѵ�..."));
        yield return StartCoroutine(NormalChat(" "));
        Abtn.SetActive(false);

        Debug.Log("---------------- ���� ���� �� ����");

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
        yield return StartCoroutine(NormalChat("�� ���� �����ϰ� �ִ� �������� ���׾�!"));
        yield return StartCoroutine(NormalChat("�� �������� ������ �������ְڴ�?"));
        yield return StartCoroutine(NormalChat("�������� ���̽�ƽ�� ���� �÷� �����̸� ������."));
        yield return StartCoroutine(NormalChat("�޼��� ���̽�ƽ���� ���ϴ� ������ ������ �� �ְ�, �������� Ʈ���Ÿ� ���� ������ �� �־�."));
        yield return StartCoroutine(NormalChat("�ʿ��� ����� �ֱ⸦"));
        yield return StartCoroutine(NormalChat(" "));
        Abtn.SetActive(false);
    }

    public IEnumerator finalDragon()
    {
        Debug.Log("������ ����â");
        yield return new WaitForSeconds(6.0f);
        Abtn.SetActive(true);
        yield return StartCoroutine(NormalChat("�̷�, ������ ���ݿ� �����̰� ���峵��!"));
        yield return StartCoroutine(NormalChat("���� Ư���� ģ������ ������ ��û�غ���."));
        yield return StartCoroutine(NormalChat("�������� B ��ư�� ������ �� ����� �׷���!"));
        yield return StartCoroutine(NormalChat(" "));
        Abtn.SetActive(false);
    }
}
