using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePotionEvent : MonoBehaviour
{
    public GameObject glow_B;
    public GameObject descripion_B;
    public AudioSource sound;

    public void HoverOver()
    {
        sound.Play();
        glow_B.SetActive(true);
        descripion_B.SetActive(true);
    }

    public void HoverEnd()
    {
        glow_B.SetActive(false);
        descripion_B.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        glow_B.SetActive(false);
        descripion_B.SetActive(false);
    }
}
