using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SFXManage : MonoBehaviour
{
    public static SFXManage instance;
    public static AudioSource SFXSource;
    public AudioClip buttonSFX;
    public AudioClip crumbleSFX;
    public AudioClip HitSFX;
    public AudioClip fireSFX;
    public AudioClip wakeUpSFX;
    public AudioClip finishSFX;
    public static float SFXvolume;

    private void Awake()
    {
        // makes sure theres only 1 copy
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }

        DontDestroyOnLoad(this.gameObject);
        SFXSource = GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("SFX"))
        {
            SFXvolume = 0.5f;
            PlayerPrefs.SetFloat("SFX", SFXvolume);
            PlayerPrefs.Save();
        }
        SFXSource.volume = PlayerPrefs.GetFloat("SFX");
    }

    public void PlayButtonSFX()
    {
        SFXSource.PlayOneShot(buttonSFX);
    }
    
    public void PlayCrumbleSFX()
    {
        SFXSource.PlayOneShot(crumbleSFX);
    }

    public void PlayHitSFX()
    {
        SFXSource.PlayOneShot(HitSFX);
    }

    public void PlayFireSFX()
    {
        SFXSource.PlayOneShot(fireSFX);
    }

    public void PlayWakeUpSFX()
    {
        SFXSource.PlayOneShot(wakeUpSFX);
    }

    public void PlayFinishSFX()
    {
        SFXSource.PlayOneShot(finishSFX);
    }
}
