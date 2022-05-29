using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement; // 씬 로드를 위한 네임 스페이스
using System.Collections;

public class cando : MonoBehaviour
{
    private RaycastHit hit;
    public float raycastDistance = 150f;
    public XRController controller = null;
    public GameObject go;
    private GameObject preGo = null;

    //public AudioSource m_audioBGM = null;

    public GameObject m_objMainMenu = null; // 메인 메뉴 관리를 위한 오브젝트
    public GameObject m_objSubMenu = null; // 허브 메뉴 관리를 위한 옵젝트
   //public GameObject m_objOptionMenu = null; // 허브 메뉴 관리를 위한 옵젝트


    public Image whiteScreen = null;
    private bool screenTimerIsActive = true;
    //[SerializeField] private float fadingDuration = 3f;
    [SerializeField] private float blackScreenDuration = 0;
    [SerializeField] BoxCollider[] m_boxColliders = null;

    bool m_isLoadSceneClick = false;

    private void Start()
    {
        Debug.Log("씬 이름 : " + SceneManager.GetActiveScene().name);
        //메인 씬 일때만 BGMController 함수 작동
        if (SceneManager.GetActiveScene().name == "Start_Scene")
        {
            Debug.Log("if문에 들어옴");
            //SoundBGMController();
            Debug.Log("첫 시작 sound 컨트롤러 함수 동작 끝");
        }    
    }


    // Update is called once per frame
    void Update()
    {
        // Raycast from go.transform, by go.transform.forward direction
        // go의 위치에서 광선을 go의 앞 방향으로 쏨. 레이가 충돌하면, 조건문 안으로 들어감
        
        if (Physics.Raycast(go.transform.position, go.transform.forward, out hit, raycastDistance))
        {
            // Debug.Log("hit: " + hit.collider.gameObject.name);
            // hit한 충돌체가 button이라는 태그를 갖고 있는 gameobject이면 조건문 안으로
            if (hit.collider.gameObject.tag == "Button")
            {
                // 기존에 충돌했던 오브젝트와 현재 충돌한 오브젝트가 같지않으면 조건문 안으로
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

                // 충돌체의 디바이스(오큘러스)에서 primaryButton을 누르면 조건문 안으로
                // 동시에 AButton에 저장함
                // ## AButton을 버튼 다운으로 바꾸면 두번 눌림 해결됨.
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool AButton))
                {
                    
                    if (AButton == true)
                    {
                        StartCoroutine(BoxColliderControllerCor());
                        //Debug.Log("select");
                        hit.collider.gameObject.GetComponent<Image>().color = new Color(154 / 255f, 74 / 255f, 157 / 255f, 1f);

                        // ## 프로젝트에 설정했던버튼 네임에 따른 인벤트를 발생
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

    // 프로젝트 상에 있던 버튼 이름에 따른 함수 이벤트 작동
    void OnButtonClick(string _buttonName)
    {
        if (m_isLoadSceneClick == true)
            return;

        Debug.Log(_buttonName + "이 클릭되었습니다");
        switch (_buttonName)
        {
            case "Story_Button":
                StartCoroutine(NextSceneLoad("tutorial")); //여기가 스토리 모드 버튼 누를시 로드
                Debug.Log("버튼 이벤트를 설정하지 않았습니다.");
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
                Debug.Log("버튼 이벤트를 설정하지 않았습니다.");
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

        while (screenTimerIsActive == true) // 화면 어둡게
        {
            blackScreenDuration += Time.deltaTime * 0.5f;

            whiteScreen.color = new Color(255, 255, 255, blackScreenDuration); // 컬러 알파 값은 0~1 값을 받음
            if (blackScreenDuration > 1)
            {
                screenTimerIsActive = false;
            }
            yield return null;
        }

        yield return new WaitForSeconds(1f); // 1초 대기
        // 처음 씬으로 이동
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
    //    Debug.Log("SoundBGMController 함수 동작");
        // 첫 시작시 BGM 키를 찾고 없다면 BGM키를 만들음.
    //    if (PlayerPrefs.HasKey("BGM") == false)
    //    {
    //        PlayerPrefs.SetInt("BGM", 1);
    //    }

    //    Debug.Log(PlayerPrefs.GetInt("BGM") + "  ,BGM Key Get Number"); // 1  ,BGM Key Get Number

        // BGM 키가 0이라면 BGM을 멈춤
        // BGM 키의 값이 1이라면 BGM을 플레이
  //     if (PlayerPrefs.GetInt("BGM") == 0)
  //     {
  //         m_audioBGM.Stop();
  //         Debug.Log("사운드 멈춤");
  //     }
  //     else
  //     {
  //          m_audioBGM.Play();
  //         Debug.Log("사운드 플레이");
  //      }

  //  }
}
