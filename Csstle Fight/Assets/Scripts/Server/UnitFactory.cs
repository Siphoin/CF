using Photon.Pun;
using System.Collections;
using UnityEngine;
    public class UnitFactory : NetworkObject
    {
      
        // Use this for initialization
        void Start()
        {
        Ini();
        }

    public UnitBase CreateUnit (UnitBase unitPrefab, TeamColor team, Vector3 pos, Quaternion rotation, bool sceneObject = false)
    {
        if (!unitPrefab)
        {
            throw new UnitFactoryException("unit prefab argument is null");
        }
        UnitBase unit = null;


        GameObject gameObject = sceneObject ? PhotonNetwork.InstantiateRoomObject(unitPrefab.name, pos, rotation) : PhotonNetwork.Instantiate(unitPrefab.name, pos, rotation);

        if (!GOHasComponentUnitBase(gameObject, out unit))
        {
            throw new UnitFactoryException($"{gameObject.name} not have component Unit Base");
        }

        unit.SetTeam(team);


        return unit;
    }

    private bool GOHasComponentUnitBase (GameObject gameObject, out UnitBase unitComponent)
    {
        return gameObject.TryGetComponent(out unitComponent);
    }

    }