using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Stats")]
    public float healthPoints;
    
    [Header("Move State")]
    public float moveSpeed = 10f;
}
