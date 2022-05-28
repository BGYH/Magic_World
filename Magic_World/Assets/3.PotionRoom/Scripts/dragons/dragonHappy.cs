using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonHappy : MonoBehaviour
{
    public Animator D_animator;
    public AudioSource wings;
    public AudioSource happySound;
    private bool D_Happy = false;

    // Start is called before the first frame update
    void Start()
    {
        D_animator = GetComponent<Animator>();
        D_animator.SetBool("Happy", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void happyStart()
    {
        wings.Stop();
        Debug.Log("-----------------  dragon Happy Start  -----------------------");
        D_animator.SetBool("Happy", true);
        happySound.Play();
    }
}
