using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement; // �� �ε带 ���� ���� �����̽�
using System.Collections;

public class cando : MonoBehaviour
{
    private RaycastHit hit;
    public float raycastDistance = 150f;
    public XRController controller = null;
    public GameObject go;
    private GameObject preGo = null;

    //public AudioSource m_audioBGM = null;

    public GameObject m_objMainMenu = null; // ���� �޴� ������ ���� ������Ʈ
    public GameObject m_objSubMenu = null; // ��� �޴� ������ ���� ����Ʈ
   //public GameObject m_objOptionMenu = null; // ��� �޴� ������ ���� ����Ʈ


    public Image whiteScreen = null;
    private bool screenTimerIsActive = true;
    //[SerializeField] private float fadingDuration = 3f;
    [SerializeField] private float blackScreenDuration = 0;
    [SerializeField] BoxCollider[] m_boxColliders = null;

    bool m_isLoadSceneClick = false;

    private void Start()
    {
        Debug.Log("�� �̸� : " + SceneManager.GetActiveScene().name);
        //���� �� �϶��� BGMController �Լ� �۵�
        if (SceneManager.GetActiveScene().name == "Start_Scene")
        {
            Debug.Log("if���� ����");
            //SoundBGMController();
            Debug.Log("ù ���� sound ��Ʈ�ѷ� �Լ� ���� ��");
        }    
    }


    // Update is called once per frame
    void Update()
    {
        // Raycast from go.transform, by go.transform.forward direction
        // go�� ��ġ���� ������ go�� �� �������� ��. ���̰� �浹�ϸ�, ���ǹ� ������ ��
        
        if (Physics.Raycast(go.transform.position, go.transform.forward, out hit, raycastDistance))
        {
            // Debug.Log("hit: " + hit.collider.gameObject.name);
            // hit�� �浹ü�� button�̶�� �±׸� ���� �ִ� gameobject�̸� ���ǹ� ������
            if (hit.collider.gameObject.tag == "Button")
            {
                // ������ �浹�ߴ� ������Ʈ�� ���� �浹�� ������Ʈ�� ���������� ���ǹ� ������
                if (preGo != hit.collider.gameObject)
                {
                    if (preGo)
                    {
                        // Debug.Log("hit diffrent go from: " + preGo.name);
                        preGo.GetComponent<Image>().color = new Color(253/255f, 105/255f, 210/255f, 103/255f);
                    }
                    //Debug.Log("Color: " + hit.collider.gameObject.name);
                    hit.collider.gameObject.GetComponent<Image>().color = new Color(248/255f, 200/255f, 241/255f, 1f);
                    preGo = hit.collider.gameObject;
                }

                // �浹ü�� ����̽�(��ŧ����)���� primaryButton�� ������ ���ǹ� ������
                // ���ÿ� AButton�� ������
                // ## AButton�� ��ư �ٿ����� �ٲٸ� �ι� ���� �ذ��.
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool AButton))
                {
                    
                    if (AButton == true)
                    {
                        StartCoroutine(BoxColliderControllerCor());
                        //Debug.Log("select");
                        hit.collider.gameObject.GetComponent<Image>().color = new Color(154 / 255f, 74 / 255f, 157 / 255f, 1f);

                        // ## ������Ʈ�� �����ߴ���ư ���ӿ� ���� �κ�Ʈ�� �߻�
                        OnButtonClick(hit.collider.gameObject.name);
                        
                    }
                }
            }
        }
        else
        {
            if (preGo)
            {
                //Debug.Log("did not hit, pre: " + preGo.name);
                preGo.GetComponent<Image>().color = new Color(253/255f, 105/255f, 210/255f, 103/255f);
                preGo = null;
            }
        }

    }

    // ������Ʈ �� �ִ� ��ư �̸��� ���� �Լ� �̺�Ʈ �۵�
    void OnButtonClick(string _buttonName)
    {
        if (m_isLoadSceneClick == true)
            return;

        Debug.Log(_buttonName + "�� Ŭ���Ǿ����ϴ�");
        switch (_buttonName)
        {
            case "Story_Button":
                StartCoroutine(NextSceneLoad("tutorial")); //���Ⱑ ���丮 ��� ��ư ������ �ε�
                Debug.Log("��ư �̺�Ʈ�� �������� �ʾҽ��ϴ�.");
                break;
            case "Auto_Button":
                m_objMainMenu.SetActive(false);
                m_objSubMenu.SetActive(true);
                break;
            //case "Option_Button":
            //    m_objMainMenu.SetActive(false);
            //    m_objOptionMenu.SetActive(true);
            //   break;
            case "Exit_Button":
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
                break;
            case "Magic_Fly_Button":
                // SceneManager.LoadScene("MagicFly");
                StartCoroutine(NextSceneLoad("Flying_Map1"));
                break;
            case "Magic_Potion_Button":
                // SceneManager.LoadScene("MagicPotion");
                StartCoroutine(NextSceneLoad("PotionRoom007"));
                break;
            case "Magic_Stick_Button":
                // SceneManager.LoadScene("MagicStick");
                StartCoroutine(NextSceneLoad("tutorial"));
                break;
            case "Magic_Battle_Button":
                // SceneManager.LoadScene("MagicBattle");
                StartCoroutine(NextSceneLoad("MagicBattle"));
                break;
            case "Back_Button":
                m_objMainMenu.SetActive(true);
                //m_objOptionMenu.SetActive(false);
                m_objSubMenu.SetActive(false);
                break;
            case "ToMainScene":
                SceneManager.LoadScene("Start_Scene");
                break;
           // case "Sound_On_Button":
           //     ScoundBGMSave(true);
           //     SoundBGMController();
           //     break;
           // case "Sound_Off_Button":
           //     ScoundBGMSave(false);
           //     SoundBGMController();
           //     break;
            default:
                Debug.Log("��ư �̺�Ʈ�� �������� �ʾҽ��ϴ�.");
                break;
        }
    }

    IEnumerator BoxColliderControllerCor()
    {
        for (int i = 0; i < m_boxColliders.Length; i++)
            m_boxColliders[i].enabled = false;

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < m_boxColliders.Length; i++)
            m_boxColliders[i].enabled = true;
    }


    IEnumerator NextSceneLoad(string _nextSceneName)
    {
        m_isLoadSceneClick = true;

        whiteScreen.gameObject.SetActive(true);

        while (screenTimerIsActive == true) // ȭ�� ��Ӱ�
        {
            blackScreenDuration += Time.deltaTime * 0.5f;

            whiteScreen.color = new Color(255, 255, 255, blackScreenDuration); // �÷� ���� ���� 0~1 ���� ����
            if (blackScreenDuration > 1)
            {
                screenTimerIsActive = false;
            }
            yield return null;
        }

        yield return new WaitForSeconds(1f); // 1�� ���
        // ó�� ������ �̵�
        SceneManager.LoadScene(_nextSceneName);
    }

   // void ScoundBGMSave(bool _setOnOff)
   // {
   //    if(_setOnOff == true)
   //         PlayerPrefs.SetInt("BGM", 1);
   //     else
   //         PlayerPrefs.SetInt("BGM", 0);
   // }

    //void SoundBGMController()
    //{
    //    Debug.Log("SoundBGMController �Լ� ����");
        // ù ���۽� BGM Ű�� ã�� ���ٸ� BGMŰ�� ������.
    //    if (PlayerPrefs.HasKey("BGM") == false)
    //    {
    //        PlayerPrefs.SetInt("BGM", 1);
    //    }

    //    Debug.Log(PlayerPrefs.GetInt("BGM") + "  ,BGM Key Get Number"); // 1  ,BGM Key Get Number

        // BGM Ű�� 0�̶�� BGM�� ����
        // BGM Ű�� ���� 1�̶�� BGM�� �÷���
  //     if (PlayerPrefs.GetInt("BGM") == 0)
  //     {
  //         m_audioBGM.Stop();
  //         Debug.Log("���� ����");
  //     }
  //     else
  //     {
  //          m_audioBGM.Play();
  //         Debug.Log("���� �÷���");
  //      }

  //  }
}
