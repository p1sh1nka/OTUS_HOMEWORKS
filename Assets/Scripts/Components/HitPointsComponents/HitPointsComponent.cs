using UnityEngine;

namespace ShootEmUp
{
    public abstract class HitPointsComponent : MonoBehaviour
    {
        [SerializeField] private int m_hitPoints;
        
        public bool IsHitPointsExists() 
        {
            return this.m_hitPoints > 0;
        }

        public void TakeDamage(int damage)
        {
            this.m_hitPoints -= damage;
            
            if (this.m_hitPoints <= 0)
            {
                OnHpEmpty();
            }
        }
        
        public abstract void OnHpEmpty();
    }
}