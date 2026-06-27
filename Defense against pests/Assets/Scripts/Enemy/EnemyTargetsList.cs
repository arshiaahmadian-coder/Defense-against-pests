using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetsList : MonoBehaviour
{
    [SerializeField] private GameObject[] beforeStartTargets;
    public List<IDamageable> TargetsList = new List<IDamageable>();

    public static EnemyTargetsList instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        foreach (GameObject target in beforeStartTargets)
        {
            TargetsList.Add(target.GetComponent<IDamageable>());
        }
    }

    public void AddTargetToList(IDamageable target)
    {
        TargetsList.Add(target);
    }

    public void RemoveTargetFromList(IDamageable target)
    {
        TargetsList.Remove(target);
    }

    public IDamageable SearchForClosestTarget(Transform searchStartPos)
    {
        float closestTargetDistance = float.MaxValue;
        IDamageable closestTarget = null;
        
        foreach (IDamageable target in TargetsList)
        {
            float distance = Vector3.Distance(searchStartPos.position, target.GetPosition());
            if (distance <= closestTargetDistance)
            {
                closestTargetDistance = distance;
                closestTarget = target;
            }
        }
        
        return closestTarget;
    }
}
