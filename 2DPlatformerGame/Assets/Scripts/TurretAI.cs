using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    float distance;
    float wakeRange = 5;
    float fireRate = 0.5f;
    float bulletSpeed = 6f;
    float bulletTimer;
    bool isAwake;
    bool SFXisPlayed;
    bool lookingRight;

    Animator anim;
    public GameObject bullet;
    public Transform target;
    public Transform shootPointLeft, shootPointRight;

    void Awake()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }
    void Start()
    {
        isAwake = false;
        lookingRight = true;
        SFXisPlayed = false;
    }

    void Update()
    {
        anim.SetBool("Awake", isAwake);
        anim.SetBool("LookingRight", lookingRight);

        RangeCheck();

        if (target.transform.position.x < transform.position.x) {
            lookingRight = false;
        }

        if (target.transform.position.x > transform.position.x)
        {
            lookingRight = true;
        }

    }

    void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance < wakeRange)
        {
            isAwake = true;
            if (!SFXisPlayed)
            {
                SFXManage.instance.PlayWakeUpSFX();
                SFXisPlayed = true;
            }

        }

        if (distance > wakeRange)
        {
            isAwake = false;
            SFXisPlayed = false;
        }
    }

    public void Attack(bool attackingRight)
    {
        bulletTimer += Time.deltaTime;

        if (bulletTimer >= fireRate)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            if (attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                bulletTimer = 0;
            }

            if (!attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                bulletTimer = 0;
            }

            SFXManage.instance.PlayFireSFX();
        }
    }
}
