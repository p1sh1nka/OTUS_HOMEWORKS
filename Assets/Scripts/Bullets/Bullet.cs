using UnityEngine;
using System;
using GameCycleLogic.GameCycleInterfaces;

namespace ShootEmUp
{
    public sealed class Bullet : 
        MonoBehaviour,
        IPausable,
        IResumable
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;

        [NonSerialized] 
        public bool IsPlayer;
        
        [NonSerialized] 
        public int Damage;

        [SerializeField] 
        private new Rigidbody2D m_rigidbody2D;
        
        [SerializeField] 
        private SpriteRenderer m_spriteRenderer;
        
        private Vector2 m_activeVelocity;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            this.OnCollisionEntered?.Invoke(this, collision);
        }

        public void SetVelocity(Vector2 velocity)
        {
            this.m_rigidbody2D.velocity = velocity;
            m_activeVelocity = velocity;
        }

        public void SetPhysicsLayer(int physicsLayer)
        {
            this.gameObject.layer = physicsLayer;
        }

        public void SetPosition(Vector3 position)
        {
            this.transform.position = position;
        }

        public void SetColor(Color color)
        {
            this.m_spriteRenderer.color = color;
        }

        [ContextMenu("Pause")]
        public void OnGamePause()
        {
            this.m_rigidbody2D.velocity = Vector2.zero;
        }

        public void OnGameResume()
        {
            this.m_rigidbody2D.velocity = m_activeVelocity;
        }
    }
}