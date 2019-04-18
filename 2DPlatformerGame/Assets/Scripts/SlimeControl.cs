using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeControl : MonoBehaviour
{
    float moveSpeed = 1f;
    float distance = 0.5f;
    private bool movingRight = true;
    public Transform groundDetection;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        RaycastHit2D leftInfo = Physics2D.Raycast(groundDetection.position, Vector2.left, distance);
        RaycastHit2D rightInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, distance);

        Debug.Log($"{groundInfo.collider} {leftInfo.collider} {rightInfo.collider}");
        if (groundInfo.collider == false && (leftInfo.collider == false || rightInfo == false))
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
