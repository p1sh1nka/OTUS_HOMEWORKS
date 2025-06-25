using System.Collections.Generic;
using UnityEngine;


namespace ShootEmUp
{
    public class BulletPool
    {
        private readonly Queue<Bullet> m_pool = new();
        private readonly Bullet m_prefab;
        private readonly Transform m_container;

        public BulletPool(Bullet prefab, Transform container, int initialCount)
        {
            m_prefab = prefab;
            m_container = container;
            Initialize(initialCount);
        }

        private void Initialize(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var bullet = Object.Instantiate(m_prefab, m_container);
                m_pool.Enqueue(bullet);
            }
        }

        public bool TryGetBullet(out Bullet bullet)
        {
            if (m_pool.Count > 0)
            {
                bullet = m_pool.Dequeue();
                return true;
            }

            bullet = Object.Instantiate(m_prefab, m_container);
            
            return bullet != null;
        }

        public void ReturnBullet(Bullet bullet)
        {
            bullet.transform.SetParent(m_container);
            m_pool.Enqueue(bullet);
        }
    }
}