using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTracker : MonoBehaviour
{
    public static bool Level1 = false;
    public static bool Level2 = false;

    // Update is called once per frame
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
