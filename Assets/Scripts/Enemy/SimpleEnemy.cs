using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy {

    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        player = GameManager.gm.player.transform;
    }

	void Update(){

        //the drawline was used to set the parameters for the area coverage in spotting the player
        Debug.DrawLine(new Vector3(transform.position.x, transform.position.y, 0f) + pointA, new Vector3(transform.position.x, transform.position.y, 0f) + pointB);

        if (facingRight)
            flipFlag = 1;
        else
            flipFlag = -1;        		
	}    
	
}
