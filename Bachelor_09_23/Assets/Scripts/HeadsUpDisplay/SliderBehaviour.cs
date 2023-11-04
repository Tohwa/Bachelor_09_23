using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

public class SliderBehaviour : MonoBehaviour
{
    [SerializeField]
    private Fence fenceData;
    [SerializeField]
    private Player playerData;

    public Gradient playerGrad;
    public Gradient fenceGrad;

    [SerializeField]
    private Slider fenceSlider;
    [SerializeField]
    private Slider playerSlider;

    [SerializeField]
    private Image fenceImage;
    [SerializeField]
    private Image playerImage;

    private void Update()
    {
        fenceSlider.value = fenceData.durability;
        playerSlider.value = playerData.healthPoints;

        playerImage.color = playerGrad.Evaluate(playerSlider.normalizedValue);
        fenceImage.color = fenceGrad.Evaluate(fenceSlider.normalizedValue);

        if(fenceData.durability == 0)
        {
            fenceImage.color = Color.white;
        }

        if(playerData.healthPoints == 0)
        {
            playerImage.color = Color.white;
        }
    }

    public void onFenceValueChange()
    {
        fenceSlider.value = fenceData.durability;
    }

    public void OnPlayerValueChange()
    {
        playerSlider.value = playerData.healthPoints;
    }
}
