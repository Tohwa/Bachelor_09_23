using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newNPCData", menuName = "Data/NPC Data/Base Data")]
public class NPCData : ScriptableObject
{
    public float healthPoints;
    public float attackDamage;
    public float attackDelay;
    public float moveSpeed;
    public float stopDistance;
}
