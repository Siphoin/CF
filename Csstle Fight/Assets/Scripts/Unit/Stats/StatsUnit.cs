using UnityEngine;
[CreateAssetMenu(menuName = "Units/Unit/Unit Stats", order = 0)]
public class StatsUnit : StatsBase
    {

    [Header("Имя")]
    [SerializeField] private string nameUnit;

    [Header("Описание")]
    [TextArea]
    [SerializeField] private string description;



    [Header("Урон")]
    [SerializeField] private ulong damage;

    [Header("Базовая защита")]
    [SerializeField] private ulong armorIndex;


    [Header("Стартовое значение здоровья")]
    [SerializeField] private ulong startHitPoints;

    [Header("Стартовое значение маны")]
    [SerializeField] private ulong startManaPoints;

    [Header("Разброс урона")]
    [SerializeField] private ulong damageSpread;

    [Header("Скорость передвижения")]
    [SerializeField] private float speedMovement;

    [Header("Скорость атаки")]
    [SerializeField] private float speedAttack;

    [Header("Скорость регенерации здоровья")]
    [SerializeField] private float speedRegenHitPoints;


    [Header("Скорость регенерации маны")]
    [SerializeField] private float speedRegenManaPoints;

    [Header("Тип брони")]
    [SerializeField] private TypeArmor typeArmor = TypeArmor.Heavy;

    [Header("Тип атаки")]
    [SerializeField] private TypeAttack typeAttack = TypeAttack.Usual;

    [Header("Горячая клавиша вызова")]
    [SerializeField] private KeyCode hotKey;

    [Header("Требуемые ресурсы")]
    [SerializeField] private ResourceRequirements[] resourceRequirements;

    [Header("Набор звуков")]
    [SerializeField] private UnitSoundData packSounds;

    public string NameUnit { get => nameUnit; }
    public string Description { get => description; }
    public ulong Damage { get => damage; }
    public ulong ArmorIndex { get => armorIndex; }
    public ulong StartHitPoints { get => startHitPoints; }
    public ulong StartManaPoints { get => startManaPoints; }
    public ulong DamageSpread { get => damageSpread; }
    public float SpeedMovement { get => speedMovement; }
    public float SpeedAttack { get => speedAttack; }
    public float SpeedRegenHitPoints { get => speedRegenHitPoints; }
    public float SpeedRegenManaPoints { get => speedRegenManaPoints; }
    public TypeArmor TypeArmor { get => typeArmor; }
    public TypeAttack TypeAttack { get => typeAttack; }
    public KeyCode HotKey { get => hotKey; }
    public ResourceRequirements[] ResourceRequirements { get => resourceRequirements; }
    public UnitSoundData PackSounds { get => packSounds; }
}