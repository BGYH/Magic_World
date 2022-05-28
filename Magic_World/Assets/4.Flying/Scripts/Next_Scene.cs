using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;//�� ������ ���� �߰�
using System.Collections;
using UnityEngine.UI;
public class Next_Scene : MonoBehaviour
{
    public float animTime = 2f;         // Fade �ִϸ��̼� ��� �ð� (����:��).  

    private Image fadeImage;            // UGUI�� Image������Ʈ ���� ����.  

    private float start=1f;           // Mathf.Lerp �޼ҵ��� ù��° ��.  
    private float end = 0f;             // Mathf.Lerp �޼ҵ��� �ι�° ��.  
    private float time = 0f;            // Mathf.Lerp �޼ҵ��� �ð� ��. 
    

    public bool stopIn = false; //false�϶� ����Ǵ°ǵ�, �ʱⰪ�� false�� �� ������ ���� �����Ҷ� ���̵������� ������...�װ� ������ true�� �ϸ��.
    public bool stopOut = true;
 

    public XRController controller = null;
    // Start is called before the first frame update
    void Start()
    {// Image ������Ʈ�� �˻��ؼ� ���� ���� �� ����.  
        fadeImage = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool BButton);
        if (BButton == true)
        {
            Debug.Log("press B");//B ��ư ������
            SceneManager.LoadScene(5);//fly map scene: 5���̴�.
                                      // Fade �ִϸ��̼� ���.  
                                      //   PlayFadeOut();
            if (stopOut == false && time <= 2)
            {
               PlayFadeOut();
            }
        }
        // ���������� = FadeIn �ִϸ��̼� ���.  
        if (stopIn == false && time <= 2)
        {
            PlayFadeIn();
        }
        if (stopOut == false && time <= 2)
        {
            PlayFadeOut();
        }
        if (time >= 2 && stopIn == false)
        {
            stopIn = true;
            time = 0;
            Debug.Log("StopIn");
        }
        if (time >= 2 && stopOut == false)
        {
            stopIn = false; //�Ͼ�� ��ȯ�ǰ� ���� �� ��ȯ �� �ٽ� Ǯ�Ŷ� �־���. �׳� ���� �����Ÿ� ���� �ʿ� ����.
            stopOut = true;
            time = 0;
            Debug.Log("StopOut");
        }
     



    }
    // ���->����
    void PlayFadeIn()
    {
        // ��� �ð� ���.  
        // 2��(animTime)���� ����� �� �ֵ��� animTime���� ������.  
        time += Time.deltaTime / animTime;

        // Image ������Ʈ�� ���� �� �о����.  
        Color color = fadeImage.color;
        // ���� �� ���.  
        color.a = Mathf.Lerp(start,end,time);
        // ����� ���� �� �ٽ� ����.  
        fadeImage.color = color;
        // Debug.Log(time);
    }
  

    // Fade �ִϸ��̼� �Լ�.  
    void PlayFadeOut()
    {
        // ��� �ð� ���.  
        // 2��(animTime)���� ����� �� �ֵ��� animTime���� ������.  
        time += Time.deltaTime / animTime;

        // Image ������Ʈ�� ���� �� �о����.  
        Color color = fadeImage.color;
        // ���� �� ���.  
        color.a = Mathf.Lerp(end,start, time);
        // ����� ���� �� �ٽ� ����.  
        fadeImage.color = color;
    }
}
