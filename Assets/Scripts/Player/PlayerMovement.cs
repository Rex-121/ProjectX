using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public enum FaceTo { Left, Right };

    private PlayerReaction reaction;



    public float movementSpeed = 3;

    private Rigidbody2D rb;

    private SpriteRenderer render;


    [Tooltip("是否可以移动")]
    public bool moveable = true;

    void Start()
    {
        reaction = GetComponent<PlayerReaction>();
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            reaction.BlockAttack();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            reaction.Attack();
        }

        //var move = InputControl.Horizontal();

        //TurnFaceIfNeeded(move);

        //var towards = move * movementSpeed;


        //MoveTo(move);


        if (Input.GetKeyDown(KeyCode.B))
        {
            //transform.position = Vector2.MoveTowards(transform.position, new Vector2(20, 10), movementSpeed * Time.deltaTime);
            MoveTo(1);
            //StartCoroutine(kk());
        }
    }


    public void TurnTo(FaceTo faceTo)
    {
        switch (faceTo)
        {
            case FaceTo.Left:
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                break;
            case FaceTo.Right:
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                break;

        }
    }

    public void TurnFaceIfNeeded(float moveTo)
    {
        if (moveTo != 0)
        {
            TurnTo(moveTo <= 0 ? FaceTo.Left : FaceTo.Right);
        }
    }

    /// <summary>
    /// 移动至`towards`
    /// </summary>
    /// <param name="towards"></param>
    public void MoveTo(float move)
    {

        StartCoroutine(MoveStepByStep(new Towards(transform.position).bySteps(2).toRight()));
    }

    IEnumerator MoveStepByStep(Towards steps)
    {

        while (transform.position.x < steps.towards.x)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, steps.towards, movementSpeed * Time.deltaTime);

            yield return new WaitForSeconds(0);

        }

        yield return null;
    }
}


public struct Towards
{
    /// <summary>
    ///  初始位置
    /// </summary>
    private Vector3 originPosition;


    public float x;// = 1.5f;
    public float y;


    public Vector3 towards;

    /// <summary>
    /// 移动的步数
    /// </summary>
    public int steps;

    public Towards(Vector3 position)
    {
        originPosition = position;
        steps = 0;
        x = 1.5f;
        y = 1.5f;
        towards = originPosition;
    }


    public Towards bySteps(int step)
    {
        steps = step;
        return this;
    }

    public Towards toRight() {

        towards = new Vector3(x * steps + originPosition.x, originPosition.y);

        return this;
    }


}