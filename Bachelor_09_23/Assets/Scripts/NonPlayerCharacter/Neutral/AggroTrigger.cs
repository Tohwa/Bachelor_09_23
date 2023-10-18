using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroTrigger : MonoBehaviour
{
    public bool enemyClose = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wolf") || other.CompareTag("Boar"))
        {
            enemyClose = true;
        }
    }
}
