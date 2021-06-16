using System;
using System.Collections;
using UnityEngine;
using System.Linq;
[RequireComponent(typeof(MeshRenderer))]
    public class TeamColorMeshPart : MonoBehaviour, ITeamColorComponent
    {
        private Material[] materialsUnits;

    private MeshRenderer meshRenderer;

        private const string PREFIX_PATH_MATERIALS_UNITS = "Materials/Units/";

        private const string PREFIX_MATERIAL_UNIT = "TT_RTS_Units_";
        // Use this for initialization
        void Start()
        {

        }

      private void Ini ()
    {
        if (meshRenderer == null)
        {
            if (!TryGetComponent(out meshRenderer))
            {
                throw new TeamColorMeshPartException($"team color part object {name} not have component Mesh Renderer");
            }
        }
    }

        public void SetTeam(TeamColor team)
        {


        Ini();


        if (!ArrayMetarialsIsValid(materialsUnits))
        {
            throw new TeamColorMeshPartException("materials unit variants not seted");
        }


        string nameMaterial = $"{PREFIX_MATERIAL_UNIT}{GetStringOfFirstCharIsLower(team.ToString())}";

        meshRenderer.material.mainTexture = materialsUnits.First(t => t.name == nameMaterial).mainTexture;
        }

        public void CacheMaterialsUnits (Material[] data)
        {
        Ini();


            if (!ArrayMetarialsIsValid(data))
            {
                throw new TeamColorMeshPartException("data materials array not valid");
            }

            materialsUnits = data;

#if UNITY_EDITOR
            Debug.Log($"part unit {name} cached materials variants.");
#endif
        }

    private string GetStringOfFirstCharIsLower (string str)
    {
        if (string.IsNullOrEmpty(str) || char.IsLower(str, 0))
            return str;

        return char.ToLowerInvariant(str[0]) + str.Substring(1);
    }

    private bool ArrayMetarialsIsValid (Material[] materials)
    {
        return materials != null && materials.Length > 0;
    }

    }