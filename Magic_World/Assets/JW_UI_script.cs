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
    [SerializeField] GameObject[] m_objDragon = null; // objDragon 선언 위치 그 [SerializeField]이게 개인적으로만 접근 맞나요?
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

        for (a = 0; a < chat.Length; a++) // 키보드 하나씩 치듯이 0.1초마다 텍스트가 추가로 들어감
        {
            writerText += chat[a];
            chatText.text = writerText;
            yield return new WaitForSeconds(0.1f);
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
        // 페이드 인
        screen.gameObject.SetActive(true);
        screenDuration = 1; 
        screenTimerIsActive = true;

        while (screenTimerIsActive == true)
        {
            screenDuration -= Time.deltaTime * 0.5f;

            screen.color = new Color(255, 255, 255, screenDuration); // 컬러 알파 값은 0~1 값을 받음
            if (screenDuration < 0)
            {
                screenTimerIsActive = false;
            }
            yield return null;
        }

        yield return new WaitForSeconds(1f); // 1초 대기
        screen.gameObject.SetActive(false);

        yield return StartCoroutine(NormalChat("축하해! 네가 해냈어!"));

        yield return StartCoroutine(NormalChat("하루가 정말 빨리 지나간 것 같아."));
        yield return StartCoroutine(NormalChat("앞으로의 모험도 잘 헤쳐나가 보자."));
        yield return StartCoroutine(NormalChat("너의 미래에도 행운이 가득하길."));
        
        yield return StartCoroutine(NormalChat(" "));
        // 페이드 아웃
        screen.gameObject.SetActive(true);
        screenDuration = 0;
        screenTimerIsActive = true;

        while (screenTimerIsActive == true) 
        {
            screenDuration += Time.deltaTime*0.5f;

            screen.color = new Color(0, 0, 0, screenDuration); // 컬러 알파 값은 0~1 값을 받음
            if (screenDuration > 1)
            {
                screenTimerIsActive = false;
            }
            yield return null;
        }

        yield return new WaitForSeconds(1f); // 1초 대기
        // 처음 씬으로 이동
        SceneManager.LoadScene("Start_Scene");

        /*
        // 프로그램 종료
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
        string path = Application.dataPath + "/" + fileName + ".Json"; // 파일 경로
        // string path = Application.dataPath + "/" + fileName + ".Json"; // 파일 경로
        Debug.Log("path : "+path);

        FileStream filestream = new FileStream(path, FileMode.Open);
        byte[] data = new byte[filestream.Length];
        filestream.Read(data, 0, data.Length);
        filestream.Close();
        string json = Encoding.UTF8.GetString(data);

        PlayerState myplayerState = JsonUtility.FromJson<PlayerState>(json);
        Debug.Log("Json Dragon name : "+myplayerState.dragon);//드래곤 종류
        switch (myplayerState.dragon)
        {
            case "Green":
                // transform.Find("Tiger Drago PolyArt Big").gameObject.SetActive(true);
                m_objDragon[0].SetActive(true);
                //변수를 뜻하는 m_ 필요.
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
