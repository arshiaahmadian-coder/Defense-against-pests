using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum ButtonType
{
    Planting,
    Building,
    Plowing,
}
public class BaseButton : MonoBehaviour
{
    [SerializeField] private ButtonType btnType;
    [SerializeField] private Vector3 materialsNeed;
    
    [Header("Plant")]
    [SerializeField] private GameObject plantPrefab;
    [Header("Building")]
    [SerializeField] private GameObject buildingPrefab;

    [Header("Text Objects")] 
    [SerializeField] private TMP_Text textWater;
    [SerializeField] private TMP_Text textSun;
    [SerializeField] private TMP_Text textWood;

    private void Awake()
    {
        textWater.text = materialsNeed.x.ToString();
        textSun.text = materialsNeed.y.ToString();
        textWood.text = materialsNeed.z.ToString();
        
        if (textWater.text == "0") Destroy(textWater.gameObject);
        if (textSun.text == "0") Destroy(textSun.gameObject);
        if (textWood.text == "0") Destroy(textWood.gameObject);
    }

    public void OnClick()
    {
        if (
            Player.instance.Inventory.Water >= materialsNeed.x &&
            Player.instance.Inventory.Sun >= materialsNeed.y &&
            Player.instance.Inventory.Wood >= materialsNeed.z 
        ) {
            Player.instance.Inventory.SpendMaterial(
                (int) materialsNeed.x,
                (int) materialsNeed.y,
                (int) materialsNeed.z
            );
            if (btnType == ButtonType.Planting) Player.instance.selectedTile.Plant(plantPrefab);
            else if (btnType == ButtonType.Building) Player.instance.selectedTile.Build(buildingPrefab);
            else if (btnType == ButtonType.Plowing) Player.instance.selectedTile.Plow();
        }
        
    }
}
