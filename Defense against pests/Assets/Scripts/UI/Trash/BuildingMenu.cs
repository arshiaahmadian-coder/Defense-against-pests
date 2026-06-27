using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMenu : MonoBehaviour
{
    public static BuildingMenu instance;
    private BaseTile selectedTile;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }
    
    private void OnEnable()
    {
        selectedTile = Player.instance.selectedTile;
    }

    private void Update()
    {
        if (selectedTile != Player.instance.selectedTile) gameObject.SetActive(false);
    }
}
