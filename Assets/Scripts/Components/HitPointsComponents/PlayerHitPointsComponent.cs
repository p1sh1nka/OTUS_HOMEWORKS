using System;
using UnityEngine;

namespace ShootEmUp
{
    public class PlayerHitPointsComponent : HitPointsComponent
    {
        public Action hpEmpty;
        
        public override void OnHpEmpty()
        {
            this.hpEmpty?.Invoke();
        }
    }
}