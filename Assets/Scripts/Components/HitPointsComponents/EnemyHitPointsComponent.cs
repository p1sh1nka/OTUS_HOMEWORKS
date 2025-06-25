using UnityEngine;
using System;

namespace ShootEmUp
{
    public class EnemyHitPointsComponent : HitPointsComponent
    {
        public event Action<GameObject> OnHitPointsEmpty;
        
        public override void OnHpEmpty()
        {
            this.OnHitPointsEmpty?.Invoke(this.gameObject);
        }
    }
}