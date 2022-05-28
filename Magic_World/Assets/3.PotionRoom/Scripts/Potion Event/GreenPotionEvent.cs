using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPotionEvent : MonoBehaviour
{
    public GameObject glow_G;
    public GameObject descripion_G;
    public AudioSource sound;

    public void HoverOver()
    {
        sound.Play();
        glow_G.SetActive(true);
        descripion_G.SetActive(true);
    }

    public void HoverEnd()
    {
        glow_G.SetActive(false);
        descripion_G.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        glow_G.SetActive(false);
        descripion_G.SetActive(false);
    }
}
