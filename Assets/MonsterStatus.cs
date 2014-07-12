using UnityEngine;
using System.Collections;

public class MonsterStatus : MonoBehaviour
{
    public int MaxHealth { set; get; }
    public int CurrentHealth { set; get; }
    public float AttackSpeed { set; get; }
    public int AttackDamage { set; get; }
    public int GoldDrop { set; get; }

    void Awake()
    {
        CurrentHealth = 100;
    }
}
