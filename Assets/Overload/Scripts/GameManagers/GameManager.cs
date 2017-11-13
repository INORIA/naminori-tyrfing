using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Assets.Overland.Scripts.Players;

namespace Assets.Overland.Scripts.GameManagers
{
    public class GameManager : MonoBehaviour
    {
        private PlayerProvider playerProvider;
        private PlayerCore player;

        // Use this for initialization
        void Start()
        {
            playerProvider = GetComponent<PlayerProvider>();

            player = playerProvider.CreatePlayer();

            player.HP.Subscribe(x => OnPlayerDamage(x));
            player.HP.Where(x => x <= 0).Subscribe(_ => OnPlayerDie());
        }

        void OnPlayerDamage(float damage)
        {
            // UI 変更用
        }

        void OnPlayerDie()
        {
            // UI 変更用
        }
    }
}
