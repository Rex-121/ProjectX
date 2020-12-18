using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReaction : MonoBehaviour
{
    private PlayerAnimation play_animation;

    void Start()
    {
        play_animation = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D collision)
    {
        play_animation.BlockAttack();
    }

}
