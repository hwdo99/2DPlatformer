using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishFlag : MonoBehaviour
{
    public static bool isFinished = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedWith = collision.gameObject;
            if (collidedWith.tag == "Player" && collidedWith != null)
            {
                SFXManage.instance.PlayFinishSFX();
                isFinished = true;
            }
            return;
    }
}
