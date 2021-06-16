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

    public long GetProcentDamageWithArmor (int damage, TypeArmor armorType)
    {
        int procent = elements.First(a => a.TypeArmor == armorType).ProcentOfDamage;      
        return damage * procent / 100;
    }
    }