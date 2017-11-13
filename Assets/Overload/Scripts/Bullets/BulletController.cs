using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Assets.Overland.Scripts.Damages;
using Assets.Overland.Scripts.Attackers.AttackerImpls;

public class BulletController : MonoBehaviour
{
    public Collider2D col;

    // Use this for initialization
    void Start()
    {
        this.OnTriggerExit2DAsObservable()
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
