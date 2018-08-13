using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dustbin : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "enemy")
        {
            col.gameObject.GetComponent<Enemy>().death();
            //Debug.Log("gg1");
        }
        Debug.Log("gg");

        if (col.gameObject.tag == "p")
        {
            
            Debug.Log("gg1");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "p")
            GameManager.gm.GameOver(false);
    }

    }