using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Waves",menuName ="Waves")]
public class Waves : ScriptableObject {

    [System.Serializable]
    public class WaveData
    {
        public enum DriveToAttack
        {
            DriveC = 0,
            DriveD = 1
        }

        public float startDelay;
        public DriveToAttack attackDriveIn;
        public int storagePercentageToAdd;
    }

    public List<WaveData> waves;    //for infinite, it takes only one wave (the first one)
    public bool setToInfiniteMode = false;

}
