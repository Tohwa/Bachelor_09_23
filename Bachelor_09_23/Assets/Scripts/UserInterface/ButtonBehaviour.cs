using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    //THIS SCRIPT IS TEMPORARY AND WILL BE REMOVED!!!

    [SerializeField]
    private InventoryBehaviour invBehav;
    public void OnWoodClick()
    {
        GameManager.Instance.woodCount++;
        invBehav.woodCounter.SetText(GameManager.Instance.woodCount.ToString());
    }

    public void OnCrystalClick()
    {
        GameManager.Instance.crystalCount++;
        invBehav.crystalCounter.SetText(GameManager.Instance.crystalCount.ToString());
    }
}
