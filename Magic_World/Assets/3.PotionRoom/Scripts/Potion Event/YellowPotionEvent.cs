using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPotionEvent : MonoBehaviour
{
    public GameObject Glow_Y;
    public GameObject descripion_Y;
    public AudioSource sound;

    public void HoverOver()
    {
        sound.Play();
        Glow_Y.SetActive(true);
        descripion_Y.SetActive(true);
    }

    public void HoverEnd()
    {
        Glow_Y.SetActive(false);
        descripion_Y.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        Glow_Y.SetActive(false);
        descripion_Y.SetActive(false);
    }
}
