using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	static public GameManager gm;

	public GameObject player;

	public enum GameState{
		Playing,
		Menu
	}

	GameState gameState;

    public GameObject DriveC;
    public GameObject DriveD;

	// Use this for initialization
	void Start () {

		gameState = GameState.Playing;
        		
	}
	
	// Update is called once per frame
	void Update () {

		switch (gameState) {
		case GameState.Playing:
			{
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        DriveC.SetActive(!DriveC.active);
                        DriveD.SetActive(!DriveD.active);
                        Debug.Log("Q pressed");
                    }
                    break;
			}

		case GameState.Menu:
			{
				break;
			}

		}

		
	}
}
