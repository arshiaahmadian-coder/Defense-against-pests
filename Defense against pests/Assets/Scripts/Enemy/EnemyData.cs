using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultEnemy", menuName = "Scriptable Objects/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public float maxHealth;
    public float movementSpeed;
    public float killExpGain;
    [Header("Attack")]
    public float attackDamage;
    public float baseAttackTime;
    public float attackRange;
}
