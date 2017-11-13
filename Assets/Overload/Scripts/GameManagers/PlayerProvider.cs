using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Overland.Scripts.Players;

namespace Assets.Overland.Scripts.GameManagers
{
    public class PlayerProvider : MonoBehaviour
    {
        public GameObject PlayerPrefab;

        public PlayerCore CreatePlayer() {
            var p = Instantiate(PlayerPrefab);
            var pc = p.GetComponent<PlayerCore>();
            return pc;
        }
    }
}
