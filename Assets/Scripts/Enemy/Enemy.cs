using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    public float speed = 0.5f;
    public LayerMask playerMask;
    public float startPoint;    //need to work on this
    public float endPoint;
    public int storageSize;
    public enum moveBehaviour
    {
        ChasePlayer,
        RunAway,
        Static,
        Random
    }

    public moveBehaviour behaviour;

    protected float minDistanceBetweenPlayer = 0.5f;
    protected Transform player;
    protected Rigidbody2D rb;
    protected bool startRandomMove = true;

    protected Vector3 pointA = new Vector3(-14.38f, 5.1f, 0f);
    protected Vector3 pointB = new Vector3(14.38f, -5.1f, 0f);

    public bool facingRight = true;
    protected int flipFlag = 1;

    protected void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void FixedUpdate()
    {
        switch (behaviour)
        {
            case moveBehaviour.ChasePlayer:
                {
                    ChasePlayer();
                    break;
                }

            case moveBehaviour.Random:
                {
                    if(startRandomMove)
                        StartCoroutine(MoveRandom());
                    break;
                }

            case moveBehaviour.RunAway:
                {
                    RunAway();
                    break;
                }

            case moveBehaviour.Static:
                {
                    break;
                }
        }
        
    }

    void ChasePlayer()
    {
        if (Physics2D.OverlapArea(transform.position + pointA, transform.position + pointB, playerMask))
        {
            if (Vector2.Distance(player.position, transform.position) > minDistanceBetweenPlayer)
            {
                float dir = 0.0f;
                if (player.position.x > transform.position.x)
                {
                    dir = 1.0f;
                }
                else
                {
                    dir = -1.0f;
                }
                rb.velocity = new Vector2(dir * speed, rb.velocity.y);
            }
        }
    }

    IEnumerator MoveRandom()
    {
        startRandomMove = false;
        rb.velocity = new Vector2( Random.Range(-1.0f,1.0f) * speed, rb.velocity.y);
        yield return new WaitForSeconds(0.5f);
        startRandomMove = true;
        yield return null;
    }

    void RunAway()
    {
        if (Physics2D.OverlapArea(transform.position + pointA, transform.position + pointB, playerMask))
        {
            if (Vector2.Distance(player.position, transform.position) > minDistanceBetweenPlayer)
            {
                float dir = 0.0f;
                if (player.position.x > transform.position.x)
                {
                    dir = -1.0f;
                }
                else
                {
                    dir = 1.0f;
                }
                rb.velocity = new Vector2(dir * speed, rb.velocity.y);
            }
        }
    }
    
    protected void death()
    {
        //die.Play ();
        //anim.SetBool ("death", isDeath);
        Destroy(gameObject, 0.5f);
    }
}
