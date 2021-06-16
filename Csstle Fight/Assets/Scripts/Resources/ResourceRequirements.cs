using System;
using UnityEngine;

[Serializable]
  public  class ResourceRequirements
    {
    [Header("Требуемый ресурс")]
    [SerializeField]
    private Resource requirementResource;

    [Header("Количество")]
    [SerializeField]
    private ulong count;

    public Resource RequirementResource { get => requirementResource; set => requirementResource = value; }
    public long Count { get => (long)count; }
}
