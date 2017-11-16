using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Assets.Overland.Scripts.Players;
using UnityEngine.SceneManagement;

namespace Assets.Overland.Scripts.GameManagers
{
    public class GameManager : MonoBehaviour
    {
        public GameObject GameOverView;
        public GameObject GameClearView;

        private PlayerProvider playerProvider;
        private PlayerCore player;
        private bool gameOver = false;

        // Use this for initialization
        void Start()
        {
            playerProvider = GetComponent<PlayerProvider>();

            player = playerProvider.CreatePlayer();

            player.HP.Subscribe(x => OnPlayerDamage(x));
            player.HP.Where(x => x <= 0).Subscribe(_ => OnPlayerDie());

            player.OnTouchTargetLand.Subscribe(_ => OnGameClear());
        }

        private void Update()
        {
            if (this.gameOver && Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Title");
            }
        }

        void OnPlayerDamage(float damage)
        {
            // UI 変更用
        }

        void OnPlayerDie()
        {
            // UI 変更用
            GameOverView.SetActive(true);
            this.gameOver = true;
        }

        void OnGameClear()
        {
            GameClearView.SetActive(true);
            this.gameOver = true;
            player.GetComponent<PlayerController>().InputEnabled = false;
        }
    }
}
