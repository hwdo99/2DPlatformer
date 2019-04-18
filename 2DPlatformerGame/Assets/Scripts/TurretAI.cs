using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public float distance;
    public float wakeRange;
    public float fireRate;
    public float bulletSpeed = 100f;
    public float bulletTimer;
    public bool isAwake;
    public bool lookingRight;

    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPointLeft, shootPointRight;

    void Awake()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }
    void Start()
    {
        isAwake = false;
        lookingRight = true;
    }

    void Update()
    {
        anim.SetBool("Awake", isAwake);
        anim.SetBool("LookingRight", lookingRight);

        RangeCheck();
    }

    void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance < wakeRange)
        {
            isAwake = true;
        }

        if (distance > wakeRange)
        {
            isAwake = false;
        }
    }
}
