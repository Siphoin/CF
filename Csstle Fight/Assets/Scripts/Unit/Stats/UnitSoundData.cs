using UnityEditor;
using UnityEngine;
[CreateAssetMenu(menuName = "Units/Unit/Unit Sound Pack", order = 1)]
public class UnitSoundData : ScriptableObject
    {
    [Header("Звук при создании юнита на карте")]
    [SerializeField] private AudioClip spawnSound;

    [Header("Звук при смерти")]
    [SerializeField] private AudioClip deathSound;

    public AudioClip SpawnSound { get => spawnSound; }
    public AudioClip DeathSound { get => deathSound; }
}