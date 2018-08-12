using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingEnemy : Enemy
{

	private Vector2 startVelocity;

	public float defaultBounceHeight = 3.0f;
    public LayerMask bounceableLayers;

	// Use this for initialization
	void Start ()
    {
		rb = GetComponent<Rigidbody2D> ();
		startVelocity = new Vector2 (rb.velocity.x, defaultBounceHeight);
        player = GameManager.gm.player.transform;
    }
	
	// Update is called once per frame
	void Update ()
    {

		
    }

	void OnCollisionEnter2D(Collision2D coll)
    {

		if (bounceableLayers == (bounceableLayers | (1 << coll.gameObject.layer)))
        {		
			rb.velocity = startVelocity;	//if it touches the ground, it will bounce up
		}
	
	}

}
