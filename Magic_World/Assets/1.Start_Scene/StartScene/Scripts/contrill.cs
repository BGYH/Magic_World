using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class contrill : MonoBehaviour
{ 
    public XRController controller = null;
    

    private void Awake()
    { 

    }

    private void Update()
    {
        CommonInput();
    }

    private void CommonInput()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool AButton))
        {
            if (AButton == true)
            {
                Debug.Log("press A");
            }
        }
    }
}