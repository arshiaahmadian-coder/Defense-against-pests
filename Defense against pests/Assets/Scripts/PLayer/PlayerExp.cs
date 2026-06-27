using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    public float exp = 0;
    public int level = 0;
    public float maxExpAtThisLevel = 100;

    [Header("UI")]
    [SerializeField] private TMP_Text numberText;

    [SerializeField] private Slider expSlider;

    private void Start()
    {
        numberText.text = level.ToString();
        expSlider.maxValue = maxExpAtThisLevel;
    }
    
    public void GetExp(float expAmount)
    {
        exp += expAmount;
        if (exp >= maxExpAtThisLevel)
        {
            exp = 0;
            maxExpAtThisLevel += maxExpAtThisLevel / 2;
            expSlider.maxValue = maxExpAtThisLevel;
            LevelUp();
        }

        expSlider.value = exp;
        print(exp);
    }

    public void LevelUp()
    {
        level += 1;
        numberText.text = level.ToString();
    }
}
