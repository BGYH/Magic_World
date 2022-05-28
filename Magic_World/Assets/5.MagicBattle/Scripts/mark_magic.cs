using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine.UI;

public class mark_magic : MonoBehaviour
{
    public Text magic1;
    public Text magic2;
    public Text magic3;
    
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        magic1.text = change_korean(find_magic(1));//ù���� �Ӽ� ��ġ
        magic2.text = change_korean(find_magic(2));//�ι��� �Ӽ� ��ġ
        magic3.text = change_korean(find_magic(3));//������ �Ӽ� ��ġ

    }

    
    string change_korean(string magic_eng) //������ �Ӽ� ȭ�鿡 ǥ���ϱ� ���� �ѱ۷� �ٲٱ�
    {

        switch (magic_eng)
        {
            case "earth":
                return "������ ����";
                
            case "fire":
                return "���� ����";
                
            case "water":
                return "������ ����";
                
            case "wind":
                return "�ٶ��� ����";
               
            case "electric":
                return "������ ����";
               
            case "dark":
                return "������ ����";
            
            case "light":
                return "���� ����";
          
            case "illusion":
                return "ȯ���� ����";
        
            default:
                return "";
        
        }

    }
    string find_magic(int num) //���ϴ� ��ȣ�� �Ӽ� ��������
    {
        
        string fileName = "TestJson";
        string path = Application.dataPath + "/" + fileName + ".Json";

        FileStream filestream = new FileStream(path, FileMode.Open);
        byte[] data = new byte[filestream.Length];
        filestream.Read(data, 0, data.Length);
        filestream.Close();
        string json = Encoding.UTF8.GetString(data);

        PlayerState myplayerState = JsonUtility.FromJson<PlayerState>(json);
        if (num == 1)
        {
            return myplayerState.wand1;
        }
        else if (num == 2)
        {
            return myplayerState.wand2;
        }
        else if (num == 3)
        {
            return myplayerState.wand3;
        }
        else
        {
            return "";
        }

        
    }
}

