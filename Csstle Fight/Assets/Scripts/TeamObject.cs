using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamObject : MonoBehaviour, ITeamColorComponent
{

    private const string PREFIX_PATH_MATERIALS_UNITS = "Materials/Units/";

    private const string PREFIX_MATERIAL_UNIT = "TT_RTS_Units_";

    private Material[] materialsUnits;

    [Header("Части модели для раскраски тим колора")]
    [SerializeField] TeamColorMeshPart[] partsColorUnit;

    [ReadOnlyField]
    [Header("Текущая команда игрока")]
    [SerializeField] private TeamColor teamColor;

    public TeamColor CurrentTeam { get => teamColor; }



    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < partsColorUnit.Length; i++)
        {
            partsColorUnit[i].CacheMaterialsUnits(materialsUnits);
        }
    }

    protected void IniTeamObject ()
    {
        if (materialsUnits == null)
        {
        materialsUnits = Resources.LoadAll<Material>(PREFIX_PATH_MATERIALS_UNITS);
        }

    }

    public void SetTeam (TeamColor team)
    {
        for (int i = 0; i < partsColorUnit.Length; i++)
        {
            partsColorUnit[i].SetTeam(team);
        }

        teamColor = team;
    }
}
