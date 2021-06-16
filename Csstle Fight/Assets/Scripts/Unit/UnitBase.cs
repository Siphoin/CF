using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : TeamObject, IPunObservable
{
    // Start is called before the first frame update
    void Start()
    {
        IniTeamObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
