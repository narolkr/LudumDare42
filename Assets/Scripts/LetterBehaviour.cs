using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterBehaviour : MonoBehaviour {

    public bool shake = false;
    public float shakeIntensity;

	// Use this for initialization
	void Start () {
        if (gameObject.GetComponent<Rigidbody2D>())
        {
            Destroy(gameObject.GetComponent<Rigidbody2D>());
        }
    }
	
	// Update is called once per frame
	void Update () {
        
        if (shake)
        {
            transform.position = new Vector3(transform.position.x + Mathf.Sin(Time.time * shakeIntensity) * 0.01f,transform.position.y,transform.position.z);
        }
        if (transform.parent == null)
        {
            if (gameObject.GetComponent<Rigidbody2D>())
            {
                gameObject.AddComponent<Rigidbody2D>();
            }
            
        }
        else
        {
            
        }
	}
}
