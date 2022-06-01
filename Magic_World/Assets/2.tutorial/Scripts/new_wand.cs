using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class new_wand : MonoBehaviour
{
    string wand1;
    string wand2;
    string wand3;
    string final_wand;
    public Transform earth_wand;
    public Transform fire_wand;
    public Transform water_wand;
    public Transform wind_wand;
    public Transform electric_wand;
    public Transform dark_wand;
    public Transform light_wand;
    public Transform illusion_wand;
    public int rnd;
    public Transform new_wand_pos;
    public string final;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(match_wand(rnd_wand(rnd)), new_wand_pos.position, new_wand_pos.transform.rotation);
        Debug.Log(rnd);
        Debug.Log(rnd_wand(rnd));
        Debug.Log(match_wand(rnd_wand(rnd)));

    }
    private void OnEnable()
    {
        //Place_three_wand p = GameObject.Find("PlayController").GetComponent<Place_three_wand>();
        string fileName = "TestJson";
        string path = Application.persistentDataPath + "/" + fileName + ".Json";

        FileStream filestream = new FileStream(path, FileMode.Open);
        byte[] data = new byte[filestream.Length];
        filestream.Read(data, 0, data.Length);
        filestream.Close();
        string json = Encoding.UTF8.GetString(data);

        PlayerState myplayerState = JsonUtility.FromJson<PlayerState>(json);

        wand1 = myplayerState.wand1;
        wand2 = myplayerState.wand2;
        wand3 = myplayerState.wand3;
        rnd = Random.Range(0, 3);
        final = rnd_wand(rnd);
        myplayerState.final_wand = final;
        File.WriteAllText(Application.persistentDataPath + "/TestJson.json", JsonUtility.ToJson(myplayerState)); //파일에 적어준다.
        Instantiate(match_wand(rnd_wand(rnd)), new_wand_pos.position, new_wand_pos.rotation);
        


        //Instantiate(match_wand(rnd_wand(rnd)), new_wand_pos.position, new_wand_pos.transform.rotation);
        //Debug.Log(rnd);
        //Debug.Log(rnd_wand(rnd));
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    string rnd_wand(int a)
    {
        switch (a)
        {
            case 0:
                return wand1;
            case 1:
                return wand2;
            case 2:
                return wand3;
            default:
                return "error";
                
        }
         
    }
    Transform match_wand(string a)
    {

        switch (a)
        {
            case "earth":
                return earth_wand;

            case "fire":
                return fire_wand;

            case "water":
                return water_wand;

            case "wind":
                return wind_wand;

            case "electric":
                return electric_wand;

            case "light":
                return light_wand;

            case "dark":
                return dark_wand;

            case "illusion":
                return illusion_wand;

            default:
                return null;

        }

    }
}
