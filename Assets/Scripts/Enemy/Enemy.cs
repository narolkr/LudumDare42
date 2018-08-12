using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    public float speed = 0.5f;
    public Transform player;
    public LayerMask playerMask;
    public float startPoint;    //need to work on this
    public float endPoint;
    public int storageSize;

    protected float minDistanceBetweenPlayer = 0.5f;

    protected Rigidbody2D rb;

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

    protected void death()
    {
        //die.Play ();
        //anim.SetBool ("death", isDeath);
        Destroy(gameObject, 0.5f);
    }
}
