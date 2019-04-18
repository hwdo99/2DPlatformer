using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManage : MonoBehaviour
{
    public static MusicManage instance;
    public static AudioSource MusicSource;
    public static float musicVolume;

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
        MusicSource = GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("Music"))
        {
            musicVolume = 0.5f;
            PlayerPrefs.SetFloat("Music", musicVolume);
            PlayerPrefs.Save();
        }
        MusicSource.volume = PlayerPrefs.GetFloat("Music");
    }
}
