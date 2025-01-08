using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "Game/Skill")]
public class SkillData : ScriptableObject
{
    public string skillName;
    public string skillDescription;
    public int damage;
    public Sprite skillIcon;
}

