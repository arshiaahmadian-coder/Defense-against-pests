using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAbility : MonoBehaviour
{
    [SerializeField] private float attackInterval;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObject projectilePrefab;
    public int woodNeedToFire;
    private float timer;
    private bool isHolding;

    [SerializeField] private AudioClip attackClip;

    private void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire2"))
        {
            isHolding = true;
            if (timer >= attackInterval)
            {
                Attack();
            }
        }

        if (isHolding && timer >= attackInterval)
        {
            Attack();
        }

        if (Input.GetButtonUp("Fire2"))
        {
            isHolding = false;
        }
        
        // player facing direction
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 15f, groundMask))
        {
            Vector3 lookPoint = hit.point;

            Vector3 direction = lookPoint - transform.position;
            direction.y = 0f;

            if (direction.sqrMagnitude > 0.001f)
            {
                Quaternion rotation = Quaternion.LookRotation(direction);
                rotation *= Quaternion.Euler(0, -90f, 0);
                transform.rotation = rotation;
            }
        }
    }

    private void Attack()
    {
        timer = 0;
        if (Player.instance.Inventory.Wood >= woodNeedToFire)
        {
            Player.instance.Inventory.SpendMaterial(0, 0, woodNeedToFire);
            Instantiate(projectilePrefab, attackPoint.position, transform.rotation);
            
            SoundManager.instance.PlaySound(attackClip);
        }
    }
}
