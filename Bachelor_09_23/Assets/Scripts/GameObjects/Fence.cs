using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    [SerializeField]
    private ObjectData fenceData;

    public float durability;

    private void Start()
    {
        durability = fenceData.healthPoints;
    }

    public void Update()
    {
        if(durability <= 0)
        {
            durability = 0;
            gameObject.SetActive(false);
        }
    }
}
