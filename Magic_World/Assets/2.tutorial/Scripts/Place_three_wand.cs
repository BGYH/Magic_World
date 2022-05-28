using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
public class Place_three_wand : MonoBehaviour
{
    public string wand1;
    public string wand2;
    public string wand3;
    //public int turn = 0;
    public Transform earth_wand;
    public Transform fire_wand;
    public Transform water_wand;
    public Transform wind_wand;
    public Transform electric_wand;
    public Transform dark_wand;
    public Transform light_wand;
    public Transform illusion_wand;
    public Transform wand1_pos;
    public Transform wand2_pos;
    public Transform wand3_pos;
    public Transform wand_ob1;
    public Transform wand_ob2;
    public Transform wand_ob3;

    // Start is called before the first frame update

    void Start()
    {
        

        string fileName = "TestJson";
        string path = Application.dataPath + "/" + fileName + ".Json";

        FileStream filestream = new FileStream(path, FileMode.Open);
        byte[] data = new byte[filestream.Length];
        filestream.Read(data, 0, data.Length);
        filestream.Close();
        string json = Encoding.UTF8.GetString(data);

        PlayerState myplayerState = JsonUtility.FromJson<PlayerState>(json);

        Debug.Log(myplayerState.wand1);
        Debug.Log(myplayerState.wand2);
        Debug.Log(myplayerState.wand3);

        wand1 = myplayerState.wand1;
        wand2 = myplayerState.wand2;
        wand3 = myplayerState.wand3;

        place_wand();
    }

    // Update is called once per frame
    void Update()
    {
        //place_wand(turn);
    }
    void place_wand()
    {
        
        wand_ob1 = match_wand(wand1);
        Instantiate(wand_ob1, wand1_pos.position, wand_ob1.transform.rotation);
        Debug.Log(match_wand(wand1));
        wand_ob2 = match_wand(wand2);
        Instantiate(wand_ob2, wand2_pos.position, wand_ob2.transform.rotation);
        Debug.Log(match_wand(wand2));
        wand_ob3 = match_wand(wand3);
        Instantiate(wand_ob3, wand3_pos.position, wand_ob3.transform.rotation);
        Debug.Log(match_wand(wand3));


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
