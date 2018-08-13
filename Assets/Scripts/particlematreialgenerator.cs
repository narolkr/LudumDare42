using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlematreialgenerator : MonoBehaviour {
    public Player p;
    public float duration;
    public float destroyDuration;
    public GameObject[] part;
    public float force;
    public float minGravity = -0.3f;
    public float maxGravity = -3.0f;
    // Use this for initialization
    void Start ()
    {
        Invoke("customTick", duration);

    }
	
	// Update is called once per frame
	void Update ()
    {
        
        
    }
    GameObject go;
    void customTick()
    {
        int rrange = Random.Range(0, part.Length);
        
        Rigidbody2D rb;
        
        if (p.velocity != Vector3.zero)
        {
           
            go = Instantiate(part[rrange], this.transform.position, Quaternion.identity) as GameObject;

            rb = go.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(force * Time.deltaTime * p.velocity.normalized, ForceMode2D.Impulse);
                rb.gravityScale = Random.Range(minGravity, maxGravity);
            }
           
        }
        if(go != null)
            Destroy(go, destroyDuration);
        Invoke("customTick", duration);
    }
}

