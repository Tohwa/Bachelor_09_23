using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class InventoryBehaviour : MonoBehaviour
{
    [SerializeField]
    public TMP_Text woodCounter;
    [SerializeField]
    public TMP_Text crystalCounter;

    private void Start()
    {
        woodCounter.SetText(GameManager.Instance.woodCount.ToString());
        crystalCounter.SetText(GameManager.Instance.crystalCount.ToString());
    }
}
