using UnityEditor;
using UnityEngine;
[CreateAssetMenu(menuName = "Units/Unit/Armor Data", order = 2)]
public class ArmorData : StatsBase
    {
    [Header("% от полученного урона")]
    [Range(0, 100)]
    [SerializeField] private ushort procentOfDamage;

    public ushort ProcentOfDamage { get => procentOfDamage; }
}