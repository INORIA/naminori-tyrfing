using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Assets.Overland.Scripts.Damages;

namespace Assets.Overland.Scripts.Players
{
    public class PlayerCore : MonoBehaviour, IDamageApplicable
    {
        public PlayerParameters parameters;
        public ReactiveProperty<float> HP = new ReactiveProperty<float>(100);
        public Subject<Unit> OnTouchTargetLand = new Subject<Unit>();

        // Use this for initialization
        void Start()
        {
            this.HP.Subscribe(x => OnPlayerDamage(x));
            this.HP.Where(x => x <= 0).Subscribe(_ => OnPlayerDie());
        }

        public void ApplyDamage(Damage damage)
        {
            HP.Value -= damage.Value;
        }

        void OnPlayerDamage(float damage)
        {
        }

        void OnPlayerDie()
        {
            Destroy(gameObject);
        }
    }
}
