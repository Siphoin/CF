using UnityEditor;
using UnityEngine;
[CreateAssetMenu(menuName = "Units/Unit/Blunders Settings", order = 4)]
public class BlundersUnitsSettings : ScriptableObject
    {
    [Header("% шанса промахов")]
    [Range(0, 100)]
    [SerializeField] private ushort procentProbalityBlunder = 20;

    public ushort ProcentProbalityBlunder { get => procentProbalityBlunder; }
}