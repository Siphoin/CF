using System;
using UnityEngine;

[Serializable]
 public   class AttackDataElement
    {
    [Header("Процент урона")]
    [Range(0, 100)]
    [SerializeField] private ushort procentOfDamage;

    [Header("Соотношение к защите")]
    [SerializeField] private TypeArmor typeArmor;

    public ushort ProcentOfDamage { get => procentOfDamage; }
    public TypeArmor TypeArmor { get => typeArmor; }

    public AttackDataElement ()
    {

    }

    public AttackDataElement (TypeArmor typeArmor)
    {
        this.typeArmor = typeArmor;
    }

    public AttackDataElement(TypeArmor typeArmor, ushort procent)
    {
        procent = (ushort)Mathf.Clamp(procent, 0, 100);
        this.typeArmor = typeArmor;
        procentOfDamage = procent;
    }
}
