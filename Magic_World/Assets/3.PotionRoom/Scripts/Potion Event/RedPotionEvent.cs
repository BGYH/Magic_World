using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPotionEvent : MonoBehaviour
{
    public GameObject glow_R;
    public GameObject descripion_R;
    public AudioSource sound;

    public void HoverOver()
    {
        sound.Play();
        glow_R.SetActive(true);
        descripion_R.SetActive(true);
    }

    public void HoverEnd()
    {
        glow_R.SetActive(false);
        descripion_R.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        glow_R.SetActive(false);
        descripion_R.SetActive(false);
    }
}
