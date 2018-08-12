using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float mMaxSpeed = 20.0f;
    [SerializeField]
    private Vector2 mJumpForce;
    [SerializeField]
    private bool mIsGrounded = false;
    [SerializeField]
    private float gravityScale = 1.0f;
    private Rigidbody2D mRigidBody;
    private float mDirection = 0.0f;



    // Use this for initialization
    void Start()
    {
        mRigidBody = gameObject.GetComponent<Rigidbody2D>();
        mRigidBody.gravityScale = gravityScale;
        mDirection = 0.0f;

    }


    // Update is called once per frame
    void Update()
    {

        //WrapPosition ();	
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (mIsGrounded)
            {
                mIsGrounded = false;
                mRigidBody.AddForce(mJumpForce);
            }

        }
        mDirection = Input.GetAxis("Horizontal");
        mRigidBody.velocity = new Vector2(mDirection * mMaxSpeed * Time.deltaTime, mRigidBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("colliding");
        if (other.gameObject.tag == "ground")
        {
            mIsGrounded = true;
            mJumpForce = new Vector2(0.0f, 1400.0f);
        }
        if (other.gameObject.tag == "wall")
        {
            mIsGrounded = true;
            mJumpForce = new Vector2(-mDirection * 1500, 1500);
        }
    }
}
