using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {

    public float speed = 0.5f;
    public Transform player;
    public LayerMask playerMask;
    public float startPoint;
    public float endPoint;

    private float minDistanceBetweenPlayer = 0.5f;

    private Rigidbody2D rb;

    private Vector2 startVelocity;

    private Vector3 pointA = new Vector3(-14.38f, 5.1f, 0f);
    private Vector3 pointB = new Vector3(14.38f, -5.1f, 0f);
    public bool facingRight = true;


	protected int flipFlag = 1;

	// Use this for initialization
	protected void Start () {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator> ();
    }

	protected void Update(){

        //the drawline was used to set the parameters for the area coverage in spotting the player
        Debug.DrawLine(new Vector3(transform.position.x, transform.position.y, 0f) + pointA, new Vector3(transform.position.x, transform.position.y, 0f) + pointB);

        if (facingRight)
            flipFlag = 1;
        else
            flipFlag = -1;

        if (Physics2D.OverlapArea(transform.position + pointA, transform.position + pointB, playerMask))
        {
            if (Vector2.Distance(player.position, transform.position) > minDistanceBetweenPlayer)
            {
                if (transform.localPosition.x > startPoint && transform.localPosition.x < endPoint)
                {

                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                }
                if (player.position.x > startPoint && player.position.x < endPoint)
                {

                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                }

            }
        }		
	}

	protected void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	protected void death(){
		//die.Play ();
		//anim.SetBool ("death", isDeath);
		Destroy (gameObject,0.5f);
	}
}
