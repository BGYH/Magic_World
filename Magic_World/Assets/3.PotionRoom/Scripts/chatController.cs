using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class chatController : MonoBehaviour
{
    public XRController controller = null;
    public GameObject potEvent;
    public GameObject Dragon_G;
    public GameObject Dragon_B;
    public GameObject Dragon_R;
    public GameObject Corgi_1;
    public GameObject Dragon_Y;
    public GameObject Corgi_2;

    public Text ChatText;
    public GameObject Abtn;
    public string writerText = "";

    public GameObject FadeScreen;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextPractice());
    }

    public IEnumerator whichDragon()
    {
        List<string> DragonTags = potEvent.GetComponent<PotEvent>().tagList;
        Debug.Log("***********    DragonTags : " + DragonTags[0] + ", " + DragonTags[1] + "    *******************");
        
        Dictionary<string, string> dic = potEvent.GetComponent<PotEvent>().tagNname;
        dic.TryGetValue("Red", out string R_name);
        dic.TryGetValue("Blue", out string B_name);
        dic.TryGetValue("Green", out string G_name);
        dic.TryGetValue("Yellow", out string Y_name);

        if (DragonTags.Contains("Red") && DragonTags.Contains("Blue"))
        {
            Abtn.SetActive(true);
            yield return new WaitForSeconds(7.0f * Time.deltaTime);
            yield return StartCoroutine(NormalChat(R_name + "�� " + B_name + "�� �巡���� ��ȯ�߱���."));
            yield return StartCoroutine(NormalChat("��, ���� �巡��� �Բ� ������ ��������?"));
            //yield return StartCoroutine(NormalChat("   "));
            Dragon_R.GetComponent<dragonHappy>().happyStart();
            Abtn.SetActive(false);
        }
        else if (DragonTags.Contains("Red") && DragonTags.Contains("Green"))
        {
            Abtn.SetActive(true);
            yield return new WaitForSeconds(7.0f * Time.deltaTime);
            yield return StartCoroutine(NormalChat(R_name + "�� " + G_name + "�� �巡���� ��ȯ�߱���."));
            yield return StartCoroutine(NormalChat("��, ���� �巡��� �Բ� ������ ��������?"));
            //yield return StartCoroutine(NormalChat("   "));
            Dragon_B.GetComponent<dragonHappy>().happyStart();
            Abtn.SetActive(false);
        }
        else if (DragonTags.Contains("Red") && DragonTags.Contains("Yellow"))
        {
            Abtn.SetActive(true);
            yield return new WaitForSeconds(7.0f * Time.deltaTime);
            yield return StartCoroutine(NormalChat(R_name + "�� " + Y_name + "�� �巡���� ��ȯ�߱���."));
            yield return StartCoroutine(NormalChat("��, ���� �巡��� �Բ� ������ ��������?"));
            //yield return StartCoroutine(NormalChat("   "));
            Corgi_1.GetComponent<dragonHappy>().happyStart();
            Abtn.SetActive(false);
        }
        else if (DragonTags.Contains("Blue") && DragonTags.Contains("Green"))
        {
            Abtn.SetActive(true);
            yield return new WaitForSeconds(7.0f * Time.deltaTime);
            yield return StartCoroutine(NormalChat(B_name + "�� " + G_name + "�� �巡���� ��ȯ�߱���."));
            yield return StartCoroutine(NormalChat("��, ���� �巡��� �Բ� ������ ��������?"));
            //yield return StartCoroutine(NormalChat("   "));
            Dragon_G.GetComponent<dragonHappy>().happyStart();
            Abtn.SetActive(false);
        }
        else if (DragonTags.Contains("Blue") && DragonTags.Contains("Yellow"))
        {
            Abtn.SetActive(true);
            yield return new WaitForSeconds(7.0f * Time.deltaTime);
            yield return StartCoroutine(NormalChat(B_name + "�� " + Y_name + "�� �巡���� ��ȯ�߱���."));
            yield return StartCoroutine(NormalChat("��, ���� �巡��� �Բ� ������ ��������?"));
            //yield return StartCoroutine(NormalChat("   "));
            Corgi_2.GetComponent<dragonHappy>().happyStart();
            Abtn.SetActive(false);
        }
        else if (DragonTags.Contains("Yellow") && DragonTags.Contains("Green"))
        {
            Abtn.SetActive(true);
            yield return new WaitForSeconds(7.0f * Time.deltaTime);
            yield return StartCoroutine(NormalChat(Y_name + "�� " + G_name + "�� �巡���� ��ȯ�߱���."));
            yield return StartCoroutine(NormalChat("��, ���� �巡��� �Բ� ������ ��������?"));
            //yield return StartCoroutine(NormalChat("   "));
            Dragon_Y.GetComponent<dragonHappy>().happyStart();
            Abtn.SetActive(false);
        }

        StartCoroutine(FadeScreen.GetComponent<FadedScreen>().FadeOut());
        Invoke("SceneChange", 4.5f);
        
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
        yield return StartCoroutine(NormalChat("���� 4���� �������� ������?"));
        yield return StartCoroutine(NormalChat("���ϴ� ������ 2���� ������ ������ �׾Ƹ��� �ϳ��� �־��."));
        yield return StartCoroutine(NormalChat("�׸��� �̿��� �������� ���� �� �־�. ���� ������ �ٽ� ������ �� ����."));
        yield return StartCoroutine(NormalChat("Ư���� ģ���� ������ �ɰž�."));
        yield return StartCoroutine(NormalChat("   "));
        Abtn.SetActive(false);
    }

    void SceneChange()
    {
        SceneManager.LoadScene("Flying_Start_Scene");
    }
}
