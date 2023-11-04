using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerBehav : MonoBehaviour
{
    [SerializeField]
    public float timer { get; private set; }

    [SerializeField]
    private TMP_Text stateText;
    [SerializeField]
    private TMP_Text timerText;

    private void Start()
    {
        stateText.SetText("PrepState");
        timerText.SetText(timer +"sec");
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.SetText(Mathf.Round(timer) + "sec");

        if (timer <= 0 && stateText.text == "PrepState")
        {
            stateText.SetText("WaveState");
        }
        else
        {
            stateText.SetText("PrepState");
        }

    }
}
