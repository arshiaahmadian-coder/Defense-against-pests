using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellTile : BaseTile
{
    [Header("Sounds")]
    [SerializeField] private AudioClip waterClip;
    [SerializeField] private AudioSource audioSource;
    public override void Initialization()
    {
        base.Initialization();
    }

    public override void Interact()
    {
        Player.instance.Inventory.AddMaterials(1, 0, 0);
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(waterClip);
    }
}
