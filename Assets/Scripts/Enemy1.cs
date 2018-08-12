using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {

	public float speed = 0.5f;
	public Transform player;
	public LayerMask playerMask;
	public float startPoint;
	public float endPoint;

	private float minDistanceBetweenPlayer = 0.5f;

	private Rigidbody2D rb;

	private Vector2 startVelocity;

	private Vector3 pointA = new Vector3 (-14.38f,5.1f,0f);
	private Vector3 pointB = new Vector3 (14.38f,-5.1f,0f);

	public float defaultBounceHeight = 3.0f;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		startVelocity = new Vector2 (rb.velocity.x, defaultBounceHeight); 
	}
	
	// Update is called once per frame
	void Update () {

		//the drawline was used to set the parameters for the area coverage in spotting the player
		Debug.DrawLine(new Vector3(transform.position.x,transform.position.y,0f) + pointA, new Vector3(transform.position.x,transform.position.y,0f)+pointB);


		if(Physics2D.OverlapArea(transform.position+pointA,transform.position+pointB,playerMask))
			{
				if (Vector2.Distance (player.position, transform.position) > minDistanceBetweenPlayer) {
					if (transform.localPosition.x > startPoint && transform.localPosition.x < endPoint) {
						
						transform.position = Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
					}
					if (player.position.x > startPoint && player.position.x < endPoint) {
					
					transform.position = Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
					}
					
				}
			}
		

		
	}

	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.layer == 8) {
		
			rb.velocity = startVelocity;	//if it touches the ground, it will bounce up
		}
	
	}

}
