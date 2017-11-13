using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Assets.Overland.Scripts.Damages;
using Assets.Overland.Scripts.Attackers.AttackerImpls;

namespace Assets.Overland.Scripts.Bullets
{
    public class EnemyCollision : MonoBehaviour
    {
        private void Start()
        {
            this.OnTriggerEnter2DAsObservable()
                .Select(x => x.GetComponent<IDamageApplicable>())
            .Where(x => x != null)
            .Subscribe(x =>
            {
                var damage = new Damage
                {
                    Attacker = new EnemyAttacker(),
                    Value = 300,
                };
                x.ApplyDamage(damage);
            });
        }
    }
}
