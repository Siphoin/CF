using UnityEditor;
using UnityEngine;
namespace Server.Matching
{
    [CreateAssetMenu(menuName = "Match/Match Settings", order = 0)]
    public class MatchSettings : ScriptableObject
    {
        [Header("Максимальное кол-во игроков")]
        [SerializeField] private byte maxCountPlayersOnMatch;

        public byte MaxCountPlayersOnMatch { get => maxCountPlayersOnMatch; }
    }

}