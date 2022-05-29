using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using System.IO;
using System.Text;

public class JW_UI_script : MonoBehaviour
{
    public XRController controller = null;
    public Text chatText;
    public string writerText = "";

    public Image screen = null;
    private bool screenTimerIsActive = true;
    //[SerializeField] private float fadingDuration = 3f;
    [SerializeField] private float screenDuration = 0;
    [SerializeField] GameObject[] m_objDragon = null; // objDragon ���� ��ġ �� [SerializeField]�̰� ���������θ� ���� �³���?
    [SerializeField] GameObject m_objImageAButton = null;

    // Start is called before the first frame update
    void Start()
    {
        m_objImageAButton.SetActive(false);
        Setctive();
        StartCoroutine(TextPractice());
    }

    //IEnumerator NormalChat(string chat, string wand)
    IEnumerator NormalChat(string chat)
    {
        int a = 0;
        writerText = "";

        for (a = 0; a < chat.Length; a++) // Ű���� �ϳ��� ġ���� 0.1�ʸ��� �ؽ�Ʈ�� �߰��� ��
        {
            writerText += chat[a];
            chatText.text = writerText;
            // yield return new WaitForSeconds(0.05f);
            yield return null;
        }

        m_objImageAButton.SetActive(true);


        while (true)
        {
            controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool AButton);

            if(AButton == true)
            {
                m_objImageAButton.SetActive(false);
                Debug.Log("press A");

                break;
            }
            yield return null;
        }
    }
    
    IEnumerator TextPractice()
    {
        // ���̵� ��
        screen.gameObject.SetActive(true);
        screenDuration = 1; 
        screenTimerIsActive = true;

        while (screenTimerIsActive == true)
        {
            screenDuration -= Time.deltaTime * 0.5f;

            screen.color = new Color(255, 255, 255, screenDuration); // �÷� ���� ���� 0~1 ���� ����
            if (screenDuration < 0)
            {
                screenTimerIsActive = false;
            }
            yield return null;
        }

        yield return new WaitForSeconds(1f); // 1�� ���
        screen.gameObject.SetActive(false);

        yield return StartCoroutine(NormalChat("������! ������ ��� ���±���."));

        yield return StartCoroutine(NormalChat("���� ���迡�� �����ϴ��� ����߾�."));
        yield return StartCoroutine(NormalChat("���ɰ� ���������� ���� �������..�� �������Ծ�."));
        yield return StartCoroutine(NormalChat("������ ��ȸ�� �ȴٸ�, �� �� ����� �ͺ���. ��ٸ��� ������."));
        yield return StartCoroutine(NormalChat("���� � �̷����� ����� �����ϱ�."));
        yield return StartCoroutine(NormalChat(" "));
        // ���̵� �ƿ�
        screen.gameObject.SetActive(true);
        screenDuration = 0;
        screenTimerIsActive = true;

        while (screenTimerIsActive == true) 
        {
            screenDuration += Time.deltaTime*0.5f;

            screen.color = new Color(0, 0, 0, screenDuration); // �÷� ���� ���� 0~1 ���� ����
            if (screenDuration > 1)
            {
                screenTimerIsActive = false;
            }
            yield return null;
        }

        yield return new WaitForSeconds(1f); // 1�� ���
        // ó�� ������ �̵�
        SceneManager.LoadScene("Start_Scene");

        /*
        // ���α׷� ����
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
        */
    }

    void Setctive()
    {
        string fileName = "TestJson";
        string path = Application.dataPath + "/" + fileName + ".Json"; // ���� ���
        // string path = Application.dataPath + "/" + fileName + ".Json"; // ���� ���
        Debug.Log("path : "+path);

        FileStream filestream = new FileStream(path, FileMode.Open);
        byte[] data = new byte[filestream.Length];
        filestream.Read(data, 0, data.Length);
        filestream.Close();
        string json = Encoding.UTF8.GetString(data);

        PlayerState myplayerState = JsonUtility.FromJson<PlayerState>(json);
        Debug.Log("Json Dragon name : "+myplayerState.dragon);//�巡�� ����
        switch (myplayerState.dragon)
        {
            case "Green":
                // transform.Find("Tiger Drago PolyArt Big").gameObject.SetActive(true);
                m_objDragon[0].SetActive(true);
                //������ ���ϴ� m_ �ʿ�.
                break;
            case "Black":
                // transform.Find("Tiger Drago Simple Big").gameObject.SetActive(true);
                m_objDragon[1].SetActive(true);
                break;
            case "Red":
                // transform.Find("Tiger Drago Toon Big").gameObject.SetActive(true);
                m_objDragon[2].SetActive(true);
                break;
            case "Yellow":
                // transform.Find("Tiger Drago Realistic Big").gameObject.SetActive(true);
                m_objDragon[3].SetActive(true);
                break;
            case "Red_Small":
                // transform.Find("Tiger Drago Toon").gameObject.SetActive(true);
                m_objDragon[4].SetActive(true);
                break;
            case "Green_Small":
                // transform.Find("Tiger Drago Simple").gameObject.SetActive(true);
                m_objDragon[5].SetActive(true);
                break;
        }
    }
}
