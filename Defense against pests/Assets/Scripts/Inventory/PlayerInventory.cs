using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory: MonoBehaviour
{
    [SerializeField]
    public int maxWater;
    public int Water;
    public int Sun = 30;
    public int Wood;

    [Header("Text Objects")] 
    [SerializeField] private TMP_Text waterTxt;
    [SerializeField] private TMP_Text sunTxt;
    [SerializeField] private TMP_Text woodTxt;

    private void Start()
    {
        UpdateUI();
    }

    public void SpendMaterial(int waterAmount, int sunAmount, int woodAmount)
    {
        Water -= waterAmount;
        Sun -= sunAmount;
        Wood -= woodAmount;

        UpdateUI();
    }

    public void AddMaterials(int water, int sun, int wood)
    {
        Water += water;
        Sun += sun;
        Wood += wood;
        
        if (Water >= maxWater) Water = maxWater;
        UpdateUI();
    }

    public void UpdateUI()
    {
        waterTxt.text = Water.ToString();
        sunTxt.text = Sun.ToString();
        woodTxt.text = Wood.ToString();
    }
}
