using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPlayerPosition : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private void Update()
    {
        transform.position = target.position;
    }

}
