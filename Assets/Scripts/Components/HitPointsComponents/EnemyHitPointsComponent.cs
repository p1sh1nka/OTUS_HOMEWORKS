using UnityEngine;
using System;

namespace ShootEmUp
{
    public class EnemyHitPointsComponent : HitPointsComponent
    {
        public Action<GameObject> hpEmpty;
        
        public override void OnHpEmpty()
        {
            this.hpEmpty?.Invoke(this.gameObject);
        }
    }
}