using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour
    {
        public bool IsReached
        {
            get { return this.m_isReached; }
        }

        [SerializeField] 
        private MoveComponent m_moveComponent;

        private Vector2 m_destination;

        private bool m_isReached;

        public void SetDestination(Vector2 endPoint)
        {
            this.m_destination = endPoint;
            this.m_isReached = false;
        }

        private void FixedUpdate()
        {
            if (this.m_isReached)
            {
                return;
            }
            
            var vector = this.m_destination - (Vector2) this.transform.position;
            if (vector.magnitude <= 0.25f)
            {
                this.m_isReached = true;
                return;
            }

            var direction = vector.normalized * Time.fixedDeltaTime;
            this.m_moveComponent.MoveByRigidbodyVelocity(direction);
        }
    }
}