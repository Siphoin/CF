using Photon.Pun;
using Photon.Realtime;
using UnitsSystem;
using UnityEngine;
namespace Server.Matching
{
    public class MatchManager : MonoBehaviourPunCallbacks
    {
        [Header("Настройки матча")]
        [SerializeField] private MatchSettings matchSettings;

        [SerializeField] UnitFactory unitFactory;

        [SerializeField] UnitBase unitTest;

        private UnitBase lastCreatedUnit;
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
            CreateTestUnit();
            Invoke(nameof(CreateTestUnit), 0.5f);
        }

        private void CreateTestUnit()
        {
            lastCreatedUnit = unitFactory.CreateUnit(unitTest, TeamColor.Green, Vector3.zero, Quaternion.identity);
            Invoke(nameof(TestPoint), 0.02f);
        }

        private  void TestPoint()
        {

            lastCreatedUnit.SetPointMove(new Vector3(105.82f, 2.29f, -130.7f));
        }
    }

}