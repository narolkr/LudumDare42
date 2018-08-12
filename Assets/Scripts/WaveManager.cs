using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    private bool waveStart;
    private Waves.WaveData mFirstWave;
    private GameObject currentAttackDrive;

    public Waves wavesDescription;
    public List<GameObject> enemyTypes; 
    public float maxDelayTime;
    public float minDelayTime;
    public int maxStorageAdded;
    public int minStorageAdded;
    public bool setDelayNonForIncomingWave;
    public bool gameOverBool;

    void Start()
    {
        waveStart = true;
        if (wavesDescription.setToInfiniteMode)
        {
            mFirstWave = wavesDescription.waves[0];
        }
    }

    void Update()
    {
        if((GameManager.gm.TotalSpacePercentage < 100) && (!gameOverBool))
        {
            if (waveStart == true)
            {
                waveStart = false;
                if (wavesDescription.setToInfiniteMode)
                {
                    mFirstWave.attackDriveIn = (Waves.WaveData.DriveToAttack)(Random.value > 0.5f ? 1 : 0);
                    Debug.Log("mFirstWave.attackDriveIn: " + mFirstWave.attackDriveIn);
                    mFirstWave.storagePercentageToAdd = Random.Range(minStorageAdded, maxStorageAdded);
                    if (mFirstWave.attackDriveIn == Waves.WaveData.DriveToAttack.DriveC)
                    {
                        currentAttackDrive = GameManager.gm.DriveC;
                    }
                    else
                    {
                        currentAttackDrive = GameManager.gm.DriveD;
                    }
                    SpawnEnemies();
                    if (setDelayNonForIncomingWave)
                    {
                        setDelayNonForIncomingWave = false;
                        mFirstWave.startDelay = 0.0f;
                    }
                    else
                    {
                        mFirstWave.startDelay = Random.Range(minDelayTime, maxDelayTime);
                    }

                    StartCoroutine(Delay());
                }
            }
        }
        else
        {
            gameOverBool = true;
            GameManager.gm.GameOver();
        }
        
        
    }

    void SpawnEnemies()
    {
        int totalStorage = 0;
        Transform locationSpawn = currentAttackDrive.transform.Find("SpawnLocations").transform;
        while (totalStorage < mFirstWave.storagePercentageToAdd)
        {
            GameObject enemy = Instantiate(enemyTypes[Random.Range(0, enemyTypes.Count)], 
                locationSpawn.GetChild(Random.Range(0,locationSpawn.childCount)).position, Quaternion.identity,
                currentAttackDrive.transform.Find("Enemies").transform);
            totalStorage += enemy.GetComponent<Enemy>().storageSize;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(mFirstWave.startDelay);
        waveStart = true;
        yield return null;
    }
}
