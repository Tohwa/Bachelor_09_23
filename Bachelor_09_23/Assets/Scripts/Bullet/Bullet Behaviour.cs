using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wolf") || other.CompareTag("Boar") || other.CompareTag("Goat"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if(other.CompareTag("Environment") || other.CompareTag("Fence"))
        {
            Debug.Log("Kugel Zerstört");
            Destroy(gameObject);
        }
    }
}
