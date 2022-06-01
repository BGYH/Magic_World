using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class ReadXml : MonoBehaviour
{
    IEnumerator XML_loader()
    {
        string fileName = "Star.xml";
        string filePath;

        switch (Application.platform)
        {
            default:
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.WindowsPlayer:

                filePath = Application.dataPath + "/StreamingAssets" + fileName;

                break;

            case RuntimePlatform.Android:
                filePath = "jar:file://" + Application.dataPath + "!/assets/Star.xml";

                break;

        }

        var file_www = new WWW(filePath);
        yield return file_www;

        XmlDocument XML_sample = new XmlDocument();
        XML_sample.LoadXml(file_www.text);


        XmlNodeList lang_node = XML_sample.SelectNodes("root/f1");
        foreach (XmlNode node in lang_node)
        {
            if (node.SelectSingleNode("id").InnerText == "1")
            {
                for (int i = 1; i <= 3; i++)
                {
                    string data = "data" + System.Convert.ToString(i);
                }
                //string d1
            }
        }
    }
}
