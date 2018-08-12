using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingEnemy : Enemy
{

	private Vector2 startVelocity;

	public float defaultBounceHeight = 3.0f;

	// Use this for initialization
	void Start ()
    {

		rb = GetComponent<Rigidbody2D> ();
		startVelocity = new Vector2 (rb.velocity.x, defaultBounceHeight); 
	}
	
	// Update is called once per frame
	void Update ()
    {

		//the drawline was used to set the parameters for the area coverage in spotting the player
		Debug.DrawLine(new Vector3(transform.position.x,transform.position.y,0f) + pointA, new Vector3(transform.position.x,transform.position.y,0f)+pointB);


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

	void OnCollisionEnter2D(Collision2D coll)
    {

		if (coll.gameObject.layer == 9)
        {
		
			rb.velocity = startVelocity;	//if it touches the ground, it will bounce up
		}
	
	}

}
