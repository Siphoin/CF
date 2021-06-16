using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamObject : NetworkObject, ITeamColorComponent, IPunObservable
{

    private const string PREFIX_PATH_MATERIALS_UNITS = "Materials/Units/";

    private const string PREFIX_MATERIAL_UNIT = "TT_RTS_Units_";

    private Material[] materialsUnits;

    [Header("����� ������ ��� ��������� ��� ������")]
    [SerializeField] TeamColorMeshPart[] partsColorUnit;

    [ReadOnlyField]
    [Header("������� ������� ������")]
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
        Ini();

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

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {

        }
    }

}
