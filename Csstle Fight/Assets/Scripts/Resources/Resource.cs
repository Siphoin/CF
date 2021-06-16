using UnityEditor;
using UnityEngine;
[CreateAssetMenu(menuName = "Others/Resources/Resource", order = 0)]
public class Resource : ScriptableObject
    {
    [Header("Иконка ресурса")]
    [SerializeField] private Sprite icon;

    [Header("Название ресурса")]
    [SerializeField] private string nameResource;

    [Header("Описание ресурса")]
    [TextArea]
    [SerializeField] private string description;

    public Sprite Icon { get => icon; }
    public string NameResource { get => nameResource; }
    public string Description { get => description; }
}