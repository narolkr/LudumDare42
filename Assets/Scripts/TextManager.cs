using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour {

    private bool mIsColliderEnable = true;
    private float mColliderHeight = 0.0f;
    private float mColliderWidth = 0.0f;
    private BoxCollider2D mCollider;
    private GameObject[] childLetter;
    private Rigidbody2D mRigidbody;
    private int mChildCount;

    public bool slammingDown;
    public Transform slammedPosition;
    public float slamSpeed;
    
    public bool shaking;
    public float shakeIntensity = 20.0f;

    public bool fallingApart;
    public bool fallingFromLeft;
    public bool fallingFromRight;
    public float betweenFallingTime;

    public bool appear;

    public bool scaling;

    public void Awake()
    {
        
    }

    public void Start()
    {
        mRigidbody = GetComponent<Rigidbody2D>();
        mRigidbody.bodyType = RigidbodyType2D.Static;
        mChildCount = transform.childCount;
        childLetter = new GameObject[mChildCount];
        for (int i = 0; i < mChildCount; ++i)
        {
            childLetter[i] = transform.GetChild(i).gameObject;
            mColliderWidth += childLetter[i].GetComponent<BoxCollider2D>().size.x;
            mColliderHeight = Mathf.Max(childLetter[i].GetComponent<BoxCollider2D>().size.y, mColliderHeight);
        }
        mCollider = GetComponent<BoxCollider2D>();
        mCollider.size.Set(mColliderWidth, mColliderHeight);
    }

    public void Update()
    {
        if (slammingDown)
        {
            SlamDown();            
        }
        if (fallingApart)
        {
            StartCoroutine(FallingApart());
            
        }
        if (shaking)
        {
            foreach (GameObject letter in childLetter)
            {
                letter.GetComponent<LetterBehaviour>().shake = true;
                letter.GetComponent<LetterBehaviour>().shakeIntensity = shakeIntensity;
            }
        }
        else
        {
            foreach (GameObject letter in childLetter)
            {
                letter.GetComponent<LetterBehaviour>().shake = false;
            }
        }
    }

    void SlamDown()
    {
        mRigidbody.bodyType = RigidbodyType2D.Dynamic;
        if (slammedPosition == null || Vector2.Distance(transform.position, slammedPosition.position) > 0.5f)
        {
            mRigidbody.gravityScale = slamSpeed;
            mRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            slammingDown = false;
            //play slamming audio
            //do some effects
            mRigidbody.gravityScale = 1;
            mRigidbody.constraints = RigidbodyConstraints2D.None;
            mRigidbody.bodyType = RigidbodyType2D.Static;
        }          
        
    }

    IEnumerator FallingApart()
    {
        fallingApart = false;
        if (fallingFromLeft)
        {
            for (int i = 0; i < mChildCount; i++)
            {
                childLetter[i].transform.parent = null;
                yield return new WaitForSeconds(betweenFallingTime);
            }
        }
        if (fallingFromRight)
        {
            for (int i = mChildCount-1; i >= 0; i--)
            {
                childLetter[i].transform.parent = null;
                yield return new WaitForSeconds(betweenFallingTime);
            }
        }
        else
        {
            transform.DetachChildren();
        }

        yield return null;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            //play slamming audio
            //do some effects
            slammingDown = false;
            mRigidbody.gravityScale = 1;
            mRigidbody.constraints = RigidbodyConstraints2D.None;
            mRigidbody.bodyType = RigidbodyType2D.Static;
        }          

    }

}
