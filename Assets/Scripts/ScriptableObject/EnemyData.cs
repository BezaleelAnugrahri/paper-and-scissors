using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Battle/Enemy")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int maxHealth;
    public int attack;
    public int defense;

    [TextArea]
    public string description;

    [Header("Skills")]
    public List<SkillData> skills;
}
