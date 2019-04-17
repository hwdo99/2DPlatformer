using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour
{
    private float moveSpeed = 0.75f;
    private float leftEdge = -10f, rightEdge = 10;
    bool startGame;

    private void Start()
    {
        startGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            startGame = true;
        }

        if (startGame)
        {
            this.gameObject.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

            if (transform.position.x < leftEdge)
            {
                transform.position = new Vector3(rightEdge, transform.position.y, 0);
            }
        }
    }
}
