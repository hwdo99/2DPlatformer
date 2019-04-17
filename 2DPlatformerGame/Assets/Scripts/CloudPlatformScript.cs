using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudPlatformScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collider2D collision)
    {
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.tag == "Player" && collidedWith != null)
        {
            StartCoroutine(Wait());
            this.gameObject.transform.Translate(Vector3.down * 10 *Time.deltaTime);
        }
        return;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
    }
}
