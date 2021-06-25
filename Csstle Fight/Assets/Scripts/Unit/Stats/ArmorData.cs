using UnityEditor;
using UnityEngine;
[CreateAssetMenu(menuName = "Units/Unit/Armor Data", order = 2)]
public class ArmorData : StatsBase
    {
    [Header("% от полученного урона")]
    [Range(0, 100)]
    [SerializeField] private ushort procentOfDamage;

    public ushort ProcentOfDamage { get => procentOfDamage; }

    public long GetProcentDamageWithAttack(int damage)
    {
        int procent = damage * procentOfDamage / 100;
        return damage + procent;
    }
}