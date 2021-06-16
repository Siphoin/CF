using UnityEditor;
using UnityEngine;

    public class StatsBase : ScriptableObject
    {
        [Header("Иконка")]
        [SerializeField] private Sprite icon;

    public Sprite Icon { get => icon; }
}