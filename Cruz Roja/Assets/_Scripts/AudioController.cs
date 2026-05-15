using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public AudioSource bgSource;
    public AudioSource effectSource;

    public AudioClip efectoRadio;

    public AudioClip jump;
    public AudioClip recolectar;

    public AudioClip efectoRata;



    public AudioClip death;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else Destroy(instance);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaySound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }


    public void PlayJump()
    {
        PlaySound(jump);
    }

    public void PlayDeath()
    {
        PlaySound(death);
    }

    public void PlayRadio()
    {
        PlaySound(efectoRadio);
    }

    public void PlayRecolectar()
    {
        PlaySound(recolectar);
    }

    public void PlayEfectoRata()
    {
        PlaySound(efectoRata);
    }

}
