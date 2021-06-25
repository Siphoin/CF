using System.Linq;
using UnityEngine;
[CreateAssetMenu(menuName = "Units/Unit/Attack Data", order = 3)]
public class AttackData : StatsBase
    {
    [Header("Соотношение защит")]
    [SerializeField]
    private AttackDataElement[] elements = new AttackDataElement[]
    {
        new AttackDataElement(TypeArmor.Average),
        new AttackDataElement(TypeArmor.Heavy),
        new AttackDataElement(TypeArmor.Fortified),
        new AttackDataElement(TypeArmor.NotArmor, 100),
        new AttackDataElement(TypeArmor.Hero),
        new AttackDataElement(TypeArmor.Easy),
    };

    public long GetProcentDamageWithArmor (int damage, int armorCount, TypeArmor armorType)
    {
        AttackDataElement element = elements.First(a => a.TypeArmor == armorType);
        int procent = 0;

        for (int i = 0; i < armorCount; i++)
        {
            procent += element.ProcentOfDamage;
        }

        int resultProcent = damage * procent / 100;
        return Mathf.Clamp(damage -= resultProcent, 1, damage);
    }
    }