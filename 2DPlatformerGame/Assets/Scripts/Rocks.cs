using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    Rigidbody2D rockBody;

    // Start is called before the first frame update
    void Start()
    {
        rockBody = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.tag == "Player" && collidedWith != null)
        {
            SFXManage.instance.PlayCrumbleSFX();
            StartCoroutine(Wait());
            rockBody.isKinematic = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
        return;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
    }
}
