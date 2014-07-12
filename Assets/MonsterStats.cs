using UnityEngine;
using System.Collections;

public class MonsterStats {
    public int MaxHealth { set; get; }
    public int CurrentHealth { set; get; }
    public float AttackSpeed { set; get; }
    public int AttackDamage { set; get; }
    public int GoldDrop { set; get; }
    public MonsterStats(float attackSpeed, int attackDamage, int maxHealth, int goldDrop)
    {
        AttackSpeed = attackSpeed;
        AttackDamage = attackDamage;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        GoldDrop = goldDrop;
    }
}
