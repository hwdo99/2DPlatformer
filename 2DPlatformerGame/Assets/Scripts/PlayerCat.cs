using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCat : MonoBehaviour
{
    Rigidbody2D catBody;
    Animator anim;
    public AnimationClip jump;
    public AnimationClip attack;
    bool startGame;
    Text GameInfoText;


    // Start is called before the first frame update
    void Start()
    {
        startGame = false;
        catBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameInfoText = GameObject.FindWithTag("StartAndEndText").GetComponent<Text>();
        catBody.freezeRotation = true;
        GameInfoText.text = "Press P to Play!";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            startGame = true;
            GameInfoText.text = "";
        }

        if (startGame)
        {

            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && catBody.velocity.y == 0) 
            {
                catBody.AddForce(Vector2.up * 700f);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("isAttack", true);
            }

            SetAnimationState();
        }
        
    }

    void SetAnimationState()
    {
        if (startGame)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (catBody.velocity.y != 0)
        {
            anim.SetBool("isJumping", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.tag == "Enemy" && collidedWith != null)
        {
            anim.SetTrigger("isDead");
            StartCoroutine(WaitForEndScreen());
        }
        return;
    }


    private IEnumerator WaitForEndScreen()
    {
        GameInfoText.text = "GAME OVER!\n" +
                            $"Your Score: {ScoreScript.currentScore}\n";
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(2);
    }
}
