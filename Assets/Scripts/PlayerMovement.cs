using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField] private float speed;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(horizontalInput * speed, rb2D.velocity.y);

        //Player Flip Left-Right
        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, speed);
        }
    }
}
