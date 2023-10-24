using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    public float fenceDurability;

    public void Update()
    {
        if( fenceDurability <= 0)
        {
            fenceDurability = 0;
            GameManager.Instance.fenceTargets.Clear();
            gameObject.SetActive(false);
        }
    }
}
