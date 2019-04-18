using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bulletLifetime;
    float maxLifetime = 0.65f;
    // Update is called once per frame
    void Update()
    {
        bulletLifetime += Time.deltaTime;
        if (bulletLifetime > maxLifetime)
        {
            Destroy(this.gameObject);
        }
    }
}
