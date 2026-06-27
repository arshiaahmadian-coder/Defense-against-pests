using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] int sunGiveAmount;
    [SerializeField] int woodGiveAmount;

    [SerializeField] private float rotateSpeed;
    [SerializeField] private AudioClip collectClip;
    // [SerializeField] private float lifeTime;
    // private float timer = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.instance.Inventory.AddMaterials(0, sunGiveAmount, woodGiveAmount);
            MaterialSpawner.instance.DecreaseMaterialsSpawned();
            SoundManager.instance.PlaySound(collectClip);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}