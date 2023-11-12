using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehav : MonoBehaviour
{
    public GameObject woodPrefab;

    private void OnDisable()
    {
        Instantiate(woodPrefab, transform.position, Quaternion.identity);
    }
}
