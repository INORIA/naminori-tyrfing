using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Overland.Scripts.Damages
{

    public interface IDamageApplicable 
    {
        void ApplyDamage(Damage damage);
    }

}
