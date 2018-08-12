using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy {

    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

	void Update(){

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
	
}
