using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCrystak : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.crystalCount++;
            Destroy(gameObject);
        }        
    }
}
