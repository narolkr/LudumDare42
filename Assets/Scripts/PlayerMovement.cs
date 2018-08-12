using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float mMaxSpeed = 30.0f;
    [SerializeField]
    private float mAcceleration = 10.0f;
    private float mDirection = 0.0f;
    [SerializeField]
    private float mJumpForce = 10.0f;

    private Rigidbody2D mRigidBody;
    [SerializeField]
    private bool mIsGrounded;

    // Use this for initialization
    void Start()
    {
        mRigidBody = gameObject.GetComponent<Rigidbody2D>();
        mDirection = 0.0f;
    }


    // Update is called once per frame
    void Update()
    {


        //Debug.Log("mDirection:" + mDirection + "\n" + "maxSpeed" + mMaxSpeed);
        if (mIsGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            mIsGrounded = false;
            mRigidBody.AddForce(new Vector2(0.0f, mJumpForce));
        }
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        mRigidBody.velocity = new Vector2(move * mMaxSpeed, mRigidBody.velocity.y);
       
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 9)
        {
            mIsGrounded = true;
        }
    }
    
}