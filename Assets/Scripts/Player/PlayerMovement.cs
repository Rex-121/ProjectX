using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerAnimation play_animation;

    public float movementSpeed = 3;

    private Rigidbody2D rb;

    private SpriteRenderer render;

    void Start()
    {
        play_animation = GetComponent<PlayerAnimation>();
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKeyDown("e"))
        {
            play_animation.BlockAttack();
        }

        var move = InputControl.Horizontal();

        if (move != 0) { render.flipX = move <= 0; }

        var speed = move * movementSpeed;

        play_animation.RunBySpeed(speed);

        rb.velocity = new Vector2(speed, rb.velocity.y);

    }
}
