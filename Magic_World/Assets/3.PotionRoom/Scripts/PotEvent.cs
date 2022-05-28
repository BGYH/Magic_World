using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
//using System.Threading;

public class Particle : MonoBehaviour
{
    //public bool playAura = true; //파티클 제어 bool
    public ParticleSystem particleObject; //파티클시스템
}

public class PotEvent : MonoBehaviour
{
    public GameObject Potion_B;
    public GameObject Potion_R;
    public GameObject Potion_G;
    public GameObject Potion_Y;

    public GameObject Dragon_G;
    public GameObject Dragon_B;
    public GameObject Dragon_R;
    public GameObject Dragon_R_s;
    public GameObject Dragon_Y;
    public GameObject Dragon_G_s;

    public ParticleSystem Pongdang; //파티클시스템
    public ParticleSystem Bubble; //파티클시스템

    public AudioSource audio;
    public AudioSource DragonTada;

    private Collider coll;
    public List<string> tagList = new List<string>();
    public Dictionary<string, string> tagNname = new Dictionary<string, string>()
    {
        {"Red", "힘"},
        {"Blue", "용기"},
        {"Green", "행운"},
        {"Yellow", "지혜"}

    };

    private int cnt = 0;
    public GameObject chatController;

    // Start is called before the first frame update
    void Start()
    {
        Dragon_G.SetActive(false);
        Dragon_B.SetActive(false);
        Dragon_R.SetActive(false);
        Dragon_R_s.SetActive(false);
        Dragon_Y.SetActive(false);
        Dragon_G_s.SetActive(false);
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject == Potion_B)
        {
            audio.Play();
            cnt += 1;
            Potion_B.SetActive(false);
            Pongdang.startColor = new Color(0, 50, 255);
            Pongdang.Play();
            tagList.Add("Blue");
        }

        if (coll.gameObject == Potion_R)
        {
            audio.Play();
            cnt += 1;
            Potion_R.SetActive(false);
            Pongdang.startColor = new Color(255, 0, 0);
            Pongdang.Play();
            tagList.Add("Red");
        }

        if (coll.gameObject == Potion_G)
        {
            audio.Play();
            cnt += 1;
            Potion_G.SetActive(false);
            Pongdang.startColor = new Color(0, 128, 0);
            Pongdang.Play();
            tagList.Add("Green");
        }

        if (coll.gameObject == Potion_Y)
        {
            audio.Play();
            cnt += 1;
            Potion_Y.SetActive(false);
            Pongdang.startColor = new Color(255, 215, 0);
            Pongdang.Play();
            tagList.Add("Yellow");
        }

        if (cnt == 2)
        {
            Potion_B.SetActive(false); Potion_R.SetActive(false);
            Potion_G.SetActive(false); Potion_Y.SetActive(false);
            Invoke("DragonAppear", 1.5f);
        }
    }

    public void DragonAppear()
    {
        Debug.Log("tagList : " + tagList[0] + ", " + tagList[1]);
        Bubble.Play();
        DragonTada.Play();

        string fileName = "TestJson";
        string path = Application.dataPath + "/" + fileName + ".Json";
        FileStream filestream = new FileStream(path, FileMode.Open);
        byte[] data = new byte[filestream.Length];
        filestream.Read(data, 0, data.Length);
        filestream.Close();
        string json = Encoding.UTF8.GetString(data);
        PlayerState myplayerState = JsonUtility.FromJson<PlayerState>(json);

        if (tagList.Contains("Red") && tagList.Contains("Blue"))
        {
            Dragon_R.SetActive(true);
            Debug.Log("Dragon_R appear");

            myplayerState.dragon = "Red";
        }
        if (tagList.Contains("Red") && tagList.Contains("Green"))
        {
            Dragon_B.SetActive(true);
            Debug.Log("Dragon_B appear");

            myplayerState.dragon = "Black";
        }
        if (tagList.Contains("Red") && tagList.Contains("Yellow"))
        {
            Dragon_R_s.SetActive(true);
            Debug.Log("Corgi1 appear");

            myplayerState.dragon = "Red_Small";
        }
        if (tagList.Contains("Blue") && tagList.Contains("Green"))
        {
            Dragon_G.SetActive(true);
            Debug.Log("Dragon_G appear");

            myplayerState.dragon = "Green";
        }
        if (tagList.Contains("Blue") && tagList.Contains("Yellow"))
        {
            Dragon_G_s.SetActive(true);
            Debug.Log("Corgi2 appear");

            myplayerState.dragon = "Green_Small";
        }
        if (tagList.Contains("Yellow") && tagList.Contains("Green"))
        {
            Dragon_Y.SetActive(true);
            Debug.Log("Dragon_Y appear");

            myplayerState.dragon = "Yellow";
        }

        json = JsonUtility.ToJson(myplayerState);
        Debug.Log("############################# " + json);
        File.WriteAllText(Application.dataPath + "/TestJson.json", JsonUtility.ToJson(myplayerState));

        StartCoroutine(chatController.GetComponent<chatController>().whichDragon());
    }
}
