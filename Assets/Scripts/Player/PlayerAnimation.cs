using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{


    Animator animator;

    HitStop hitStop;



    void Start()
    {
        animator = GetComponent<Animator>();
        hitStop = GetComponent<HitStop>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RunBySpeed(float speed) {
        animator.SetFloat("Speed", Mathf.Abs(speed));
    }


    public void BlockAttack()
    {
        animator.SetTrigger("BlockAttack");
    }

    void BlockPoint()
    {
        hitStop.TimeStop();
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void finishBlock() {

        //animator.
    }
    

}
