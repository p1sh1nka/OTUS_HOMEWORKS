using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField] 
        private new Rigidbody2D m_rigidbody2D;

        [SerializeField]
        private float speed = 5.0f;
        
        public void MoveByRigidbodyVelocity(Vector2 vector)
        {
            var nextPosition = this.m_rigidbody2D.position + vector * this.speed;
            this.m_rigidbody2D.MovePosition(nextPosition);
        }
    }
}