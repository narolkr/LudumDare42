using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	static public GameManager gm;

	public GameObject player;
    public Slider storageSpace;
    
	public enum GameState{
		Playing,
		Menu,
        GameOver
	}

	GameState gameState;

    public GameObject DriveC;
    public GameObject DriveD;
    public float sliderGrowSpeed = 0.5f;

    public Sprite CDriveActive;
    public Sprite DDriveActive;
    public Sprite CDriveNotActive;
    public Sprite DDriveNotActive;

    public Image cdrive;
    public Image ddrive;

    public GameObject[] releasedMB;
    public GameObject gameOverUninstalled;
    public GameObject gameOverStorage;
    public GameObject fifty;
    public GameObject eighty;
    float randomY; //-3.8 to -4.5
    [SerializeField]
    public int TotalSpacePercentage;
    bool once;
    bool once50;
    bool once80;
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
    float t = 0.0f;
    private void Start()
    {
    }
    // Update is called once per frame
    void Update () {

		switch (gm.gameState)
        {
		case GameState.Playing:
			{
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        DriveC.SetActive(!DriveC.active);
                        DriveD.SetActive(!DriveD.active);

                        if(DriveC.active)
                        {
                            cdrive.sprite = CDriveActive;
                            ddrive.sprite = DDriveNotActive;
                        }

                        if (DriveD.active)
                        {
                            cdrive.sprite = CDriveNotActive;
                            ddrive.sprite = DDriveActive;
                        }
                    }
                    break;
			}

		case GameState.Menu:
			{
				break;
			}

		}

        
        if(storageSpace.value < TotalSpacePercentage)
        {
            t += sliderGrowSpeed * Time.deltaTime;
            storageSpace.value = Mathf.Lerp(storageSpace.value, TotalSpacePercentage, t);

            if (storageSpace.value > (TotalSpacePercentage - 1))
            {
                t = 0;
                storageSpace.value = TotalSpacePercentage;
            }
        }
       /* else
        if (storageSpace.value > TotalSpacePercentage)
        {
            Debug.Log("decreasing");
            t -= sliderGrowSpeed * Time.deltaTime;
            storageSpace.value = Mathf.Lerp(storageSpace.value, TotalSpacePercentage, t);

            if (storageSpace.value < (TotalSpacePercentage + 1))
            {
                t = 0;
                storageSpace.value = TotalSpacePercentage;
            }
        }*/


        if (storageSpace.value >= 100)
        {
            if(!once)
            {
                GameOver(true);
                once = true;
            }
            
        }

        if(storageSpace.value >= 50)
        {
            if (!once50)
            {
                GameObject o = Instantiate(fifty, new Vector3(14.13f, 5.32f, 0), Quaternion.identity)as GameObject;
                Destroy(o, 2);
                once50 = true;
            }
        }

        if (storageSpace.value >= 80)
        {
            if (!once80)
            {
                GameObject o = Instantiate(eighty, new Vector3(14.13f, 5.32f, 0), Quaternion.identity)as GameObject;
                Destroy(o, 2);
                once80 = true;
            }
        }

    }

    public void AddTotalSpacePercentage(int incrementor)
    {
        
        TotalSpacePercentage = TotalSpacePercentage + incrementor;

        if(incrementor < 0)
        {
            storageSpace.value = TotalSpacePercentage;
        }
    }

    public void GameOver(bool sizeFull)
    {
        CameraShake.Shake(0.2f, 0.2f);
        if (sizeFull == true)
        {
           gameOverStorage.SetActive(true);
            player.gameObject.GetComponent<Player>().InputFreeze = true;
        }
        else
        {
            gameOverUninstalled.SetActive(true);
            player.gameObject.GetComponent<Player>().InputFreeze = true;
        }
        
    }

    public void Release()
    {
        int g = Random.Range(0, releasedMB.Length);
        GameObject o = Instantiate(releasedMB[g], new Vector3(0, Random.Range(-5f, -3.5f), 0), Quaternion.identity)as GameObject;
        CameraShake.Shake(0.2f, 0.2f);
        Destroy(o, 2);

    }

    public void restart()
    {
        Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.buildIndex);
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene(0);
    }
}
