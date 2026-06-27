using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    public int cycleTime;
    public bool isDay = true;

    private float sec = 0;
    private int min = 0;
    private int intSec;
    public string timeStr;
    private string secStr;
    private string minStr;

    [Header("Lighting")]
    [SerializeField] private Light sun;
    [SerializeField] private Light sun2;
    [SerializeField] private Light playeerPointLight;
    
    [Header("Sounds")]
    [SerializeField] private AudioClip dayAmb;
    [SerializeField] private AudioClip nightAmb;
    [SerializeField] private AudioSource audioSource;

    public static DayNightCycle instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        sec = 0;
        min = cycleTime;
    }

    private void FixedUpdate()
    {
        sec -= Time.deltaTime;

        if (sec <= 0)
        {
            if (min <= 0)
            {
                // time is over
                CycleDay();
            }
            else
            {
                sec = 60;
                min -= 1;
                Minute();
            }
        }

        intSec = (int) sec;
        secStr = (intSec + "").Length == 1 ? "0" + intSec : intSec + "";
        minStr = (min + "").Length == 1 ? "0" + min : min + "";
        timeStr =  minStr + ":" + secStr;
        timerText.text = timeStr;
    }

    public void CycleDay()
    {
        min = cycleTime;
        if (sec <= 0)
        {
            min -= 1;
            sec = 60;
            Minute();
        }

        isDay = !isDay;

        if (isDay)
        {
            sun.intensity = 1f;
            sun2.enabled = true;
            playeerPointLight.enabled = false;
            audioSource.clip = dayAmb;
            audioSource.Play();
        }
        else
        {
            sun.intensity = 0.4f;
            sun2.enabled = false;
            audioSource.clip = nightAmb;
            audioSource.Play();
        }
    }

    private void Minute()
    {
        
    }
}
