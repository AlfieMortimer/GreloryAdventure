using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;

    private float secondsCount;
    private int minuteCount;
    private int hourCount;

    private void Start()
    {
        minuteCount = VariableStore.minuteCount;
        secondsCount = VariableStore.secondsCount;
    }
    void Update()
    {    
        UpdateTimerUI();
        VariableStore.secondsCount = secondsCount;
        VariableStore.minuteCount = minuteCount;
        print(secondsCount);
    }

    //call this on update
    public void UpdateTimerUI()
    {
        //set timer UI
        secondsCount += Time.deltaTime;
        timerText.text = "" + minuteCount + ":" + (int)secondsCount;
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {
            hourCount++;
            minuteCount = 0;
        }
    }
    
}
