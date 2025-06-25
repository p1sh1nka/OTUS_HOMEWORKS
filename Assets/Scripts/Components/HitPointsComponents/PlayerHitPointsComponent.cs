using System;

namespace ShootEmUp
{
    public class PlayerHitPointsComponent : HitPointsComponent
    {
        public event Action OnHitPointsEmpty;
        
        public override void OnHpEmpty()
        {
            this.OnHitPointsEmpty?.Invoke();
        }
    }
}