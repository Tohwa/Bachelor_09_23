using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Waves[] waves;
}

[System.Serializable]
public class Waves
{
    [SerializeField] private WaveSettings[] waveSettings;
}

[System.Serializable]
public class WaveSettings
{
    #region Fields
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject spawnLocation;
    [SerializeField] private NPCData enemyData;
    //[SerializeField] private float spawnDelay;
    #endregion
}
