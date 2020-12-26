using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
    public Transform hoursTransform;
    public Transform minutesTransform;
    public Transform secondsTransform;
    public bool continuous;
    private float degreesPerHour = 30f;
    private float degreesPerMinute = 6f;
    private float degreesPerSecond = 6f;
    void Update()
    {
        if(continuous){
            UpdateContinuous();
        }else{
            UpdateDiscrete();
        }
    }

    void UpdateContinuous(){
        TimeSpan curr = DateTime.Now.TimeOfDay;
        hoursTransform.localRotation = 
            Quaternion.Euler(0f, (float) curr.TotalHours * degreesPerHour, 0f);
        minutesTransform.localRotation = 
            Quaternion.Euler(0f, (float) curr.TotalMinutes * degreesPerMinute, 0f);
        secondsTransform.localRotation = 
            Quaternion.Euler(0f, (float) curr.TotalSeconds * degreesPerSecond, 0f);
    }
    void UpdateDiscrete(){
        DateTime curr = DateTime.Now;
        hoursTransform.localRotation     = Quaternion.Euler(0f, curr.Hour * degreesPerHour    , 0f);
        minutesTransform.localRotation   = Quaternion.Euler(0f, curr.Minute * degreesPerMinute, 0f);
        secondsTransform.localRotation   = Quaternion.Euler(0f, curr.Second * degreesPerSecond, 0f);
    }
    //test 3
}
