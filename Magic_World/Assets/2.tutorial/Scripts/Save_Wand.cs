using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using Newtonsoft.Json;


public class Save_Wand : MonoBehaviour
{
    public string a, b, c;
    PlayerState player = new PlayerState();

    void Start()
    {


    }
    void Update()
    {

        ray_interactor_wand ray = GameObject.Find("Ray Interactor").GetComponent<ray_interactor_wand>();
        if (ray.save_num == 1)
        {
            a = ray.select_wandname[0];
            b = ray.select_wandname[1];
            c = ray.select_wandname[2];

            player.playerName = "taerim";
            try
            {
                player.wand1 = a;
                player.wand2 = b;
                player.wand3 = c;
            }
            catch
            {
                Debug.Log("error");
            }

            
            player.dragon = "";
            string json = JsonUtility.ToJson(player);
            Debug.Log(json);
            

            File.WriteAllText(Application.persistentDataPath + "/TestJson.json", JsonUtility.ToJson(player));
            ray.save_num = 2; //세이브 넘버 2로 보내서 한번만 저장한다.
        }

    }
    
}
