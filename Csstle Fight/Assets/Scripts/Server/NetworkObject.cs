using Photon.Pun;
using System.Collections;
using UnityEngine;
[RequireComponent(typeof(PhotonView))]
    public class NetworkObject : MonoBehaviour
    {
    protected PhotonView view;



     protected void Ini ()
    {
        if (view == null)
        {
        view = PhotonView.Get(this);

        if (view == null)
        {
            throw new NetworkObjectException($"{name} bot have component Photon View");
        }
        }

    }

    }