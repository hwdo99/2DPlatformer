using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerControl : MonoBehaviour
{
    private float timer;
    private bool startGame;
    public static float currentTime;

    public void Start()
    {
        startGame = false;
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!startGame)
            {
                startGame = true;
            }
        }

        if (startGame)
        { 
            timer += Time.deltaTime;

            if (timer > 2f)
            {
                ScoreScript.currentScore += 1;
                //Reset the timer to 0.
                timer = 0;
            }
        }
    }
}
