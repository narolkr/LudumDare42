using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	static public GameManager gm;

	public GameObject player;

	public enum GameState{
		Playing,
		Menu,
        GameOver
	}

	GameState gameState;

    public GameObject DriveC;
    public GameObject DriveD;

    [SerializeField]
    private int TotalSpacePercentage;

	// Use this for initialization
	void Awake ()
    {
        if (gm == null && GetComponent<GameManager>() != null)
            gm = this.gameObject.GetComponent<GameManager>();
        else
            Debug.Log("Game Manager is missing");
        gm.gameState = GameState.Playing;
        gm.player = player;
    }
	
	// Update is called once per frame
	void Update () {

		switch (gm.gameState) {
		case GameState.Playing:
			{
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        DriveC.SetActive(!DriveC.active);
                        DriveD.SetActive(!DriveD.active);
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
