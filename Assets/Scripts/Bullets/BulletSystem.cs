using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour
    {
        [SerializeField] 
        private int m_initialCount = 50;
        
        [SerializeField] 
        private Transform m_container;
        
        [SerializeField] 
        private Bullet m_prefab;
        
        [SerializeField] 
        private Transform m_worldTransform;
        
        [SerializeField] 
        private LevelBounds m_levelBounds;

        private BulletPool m_bulletPool;
        private readonly HashSet<Bullet> m_activeBullets = new();
        private readonly List<Bullet> m_cache = new();

        private void Awake()
        {
            m_bulletPool = new BulletPool(m_prefab, m_container, m_initialCount);
        }

        private void FixedUpdate()
        {
            m_cache.Clear();
            m_cache.AddRange(m_activeBullets);
            
            CheckOutOfBoundsBullets();
        }

        private void CheckOutOfBoundsBullets()
        {
            foreach (var bullet in m_cache)
            {
                if (!m_levelBounds.InBounds(bullet.transform.position))
                {
                    TryRemoveBullet(bullet);
                }
            }
        }

        public void FlyBulletByArgs(BulletArgs bulletArgs)
        {
            if (!m_bulletPool.TryGetBullet(out var bullet))
            {
                return;
            }

            bullet.transform.SetParent(m_worldTransform);
            
            bullet = BulletBuilder.BuildBullet(bullet, bulletArgs);

            if (m_activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            BulletUtils.DealDamage(bullet, collision.gameObject);
            TryRemoveBullet(bullet);
        }

        private bool TryRemoveBullet(Bullet bullet)
        {
            if (!m_activeBullets.Remove(bullet))
            {
                return false;
            }

            bullet.OnCollisionEntered -= OnBulletCollision;
            
            m_bulletPool.ReturnBullet(bullet);
            
            return true;
        }
    }
}