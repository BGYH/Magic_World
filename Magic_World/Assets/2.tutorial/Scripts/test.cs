using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class test : MonoBehaviour
{

    //public Text chatText;
    //public Text wand_info;
    //public string writerText = "";
    public XRController controller = null;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool AButton);

        if (AButton == true)
        {
            Debug.Log("hello");

           
        }
    }
    
}
