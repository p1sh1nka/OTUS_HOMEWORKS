using System;
using UnityEngine;

namespace ShootEmUp
{
    public abstract class HitPointsComponent : MonoBehaviour
    {
        [SerializeField] private int hitPoints;
        
        public bool IsHitPointsExists() {
            return this.hitPoints > 0;
        }

        public void TakeDamage(int damage)
        {
            this.hitPoints -= damage;
            
            if (this.hitPoints <= 0)
            {
                OnHpEmpty();
            }
        }
        
        public abstract void OnHpEmpty();
    }
}