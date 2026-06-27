using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesList : MonoBehaviour
{
    [HideInInspector]
    public List<Enemy> enemiesList = new List<Enemy>();
    
    public static EnemiesList instance;
    
    private void Awake()
    {
        instance = this;
    }
    
    public void AddTargetToList(Enemy target)
    {
        enemiesList.Add(target);
    }

    public void RemoveTargetFromList(Enemy target)
    {
        enemiesList.Remove(target);
    }
    
    public Enemy SearchForClosestTarget(Transform searchStartPos, float minDistance = 0)
    {
        float closestTargetDistance = float.MaxValue;
        Enemy closestTarget = null;
        
        foreach (Enemy target in enemiesList)
        {
            float distance = Vector3.Distance(searchStartPos.position, target.transform.position);
            if (distance <= closestTargetDistance && distance >= minDistance)
            {
                closestTargetDistance = distance;
                closestTarget = target;
            }
        }
        
        return closestTarget;
    }
}
