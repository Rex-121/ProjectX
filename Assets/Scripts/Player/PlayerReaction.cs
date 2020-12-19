using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReaction : MonoBehaviour
{
    private PlayerAnimation play_animation;


    public LayerMask attackAble;

    
    public Transform attackPoint;

    public float attackRange;

    void Start()
    {
        play_animation = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame


    public void Attack()
    {
        play_animation.Attack();

       Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, attackAble);

        foreach(Collider2D e in hits)
        {
            e.GetComponent<PlayerReaction>().hitByAttack();
        }
    }

    public void hitByAttack()
    {
        BlockAttack();
    }

    public void BlockAttack()
    {
        play_animation.BlockAttack();
    }

    public void RunBySpeed(float speed)
    {
        play_animation.RunBySpeed(speed);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        play_animation.BlockAttack();
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
