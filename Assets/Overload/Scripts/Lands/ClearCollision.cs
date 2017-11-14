using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Assets.Overland.Scripts.Players;

namespace Assets.Overland.Scripts.Lands
{
    public class ClearCollision : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            this.OnCollisionEnter2DAsObservable()
                .Select(x => x.gameObject.GetComponent<PlayerCore>())
                .Where(x => x != null)
                .Subscribe(player =>
                {
                    player.OnTouchTargetLand.OnNext(Unit.Default);
                    player.OnTouchTargetLand.OnCompleted();
                });
        }
    }
}