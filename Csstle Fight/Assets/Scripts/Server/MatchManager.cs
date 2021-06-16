using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class MatchManager : MonoBehaviourPunCallbacks
    {
    [Header("Настройки матча")]
    [SerializeField] private MatchSettings matchSettings;
        // Use this for initialization
        void Start()
        {

        if (matchSettings == null)
        {
            throw new MatchManagerException("match settings not seted");
        }


        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        }

    public override void OnConnectedToMaster()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = false;
        roomOptions.MaxPlayers = matchSettings.MaxCountPlayersOnMatch;
        PhotonNetwork.JoinOrCreateRoom("testMatch", roomOptions, TypedLobby.Default);

    }


    public override void OnJoinedRoom()
    {
        Debug.Log("room joined");
    }
}