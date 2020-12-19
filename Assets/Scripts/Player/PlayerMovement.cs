using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerReaction reaction;

    public float movementSpeed = 3;

    private Rigidbody2D rb;

    private SpriteRenderer render;

    void Start()
    {
        reaction = GetComponent<PlayerReaction>();
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            reaction.BlockAttack();
        }

        var move = InputControl.Horizontal();

        if (move != 0) { transform.localScale = new Vector3(move <= 0 ? -1 : 1, transform.localScale.y, transform.localScale.z); }

        var speed = move * movementSpeed;

        reaction.RunBySpeed(speed);

        rb.velocity = new Vector2(speed, rb.velocity.y);


        if (Input.GetKeyDown("q"))
        {
            reaction.Attack();
        }

    }
}
