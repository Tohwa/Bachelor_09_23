using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    #region Fields
    [SerializeField] private Transform target;

    private float offSet;
    private int heightOffSet = 9;
    #endregion

    private void Start()
    {
        CalculateDistance();
    }

    private void Update()
    {
        transform.LookAt(target);

        Vector3 targetPos = target.position - (target.forward * offSet);
        targetPos.y = targetPos.y + heightOffSet;

        transform.position = targetPos;
    }

    private void CalculateDistance()
    {
        float deltaX = target.position.x - transform.position.x;
        float deltaY = target.position.y - transform.position.y;
        float deltaZ = target.position.z - transform.position.z;

        offSet = Mathf.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
    }
}
