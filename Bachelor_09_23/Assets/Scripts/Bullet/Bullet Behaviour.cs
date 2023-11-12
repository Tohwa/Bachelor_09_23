using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public GameObject crystalPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wolf") || other.CompareTag("Boar") || other.CompareTag("Goat"))
        {
            Destroy(other.gameObject);
            Instantiate(crystalPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (other.CompareTag("Environment") || other.CompareTag("Fence"))
        {
            Debug.Log("Kugel Zerstört");
            Destroy(gameObject);
        }
        if (other.CompareTag("Tree"))
        {
            other.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}
