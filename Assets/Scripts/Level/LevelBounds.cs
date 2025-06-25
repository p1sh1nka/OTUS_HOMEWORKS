using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBounds : MonoBehaviour
    {
        [SerializeField]
        private Transform m_leftBorder;

        [SerializeField]
        private Transform m_rightBorder;

        [SerializeField]
        private Transform m_downBorder;

        [SerializeField]
        private Transform m_topBorder;
        
        public bool InBounds(Vector3 position)
        {
            var positionX = position.x;
            var positionY = position.y;
            return positionX > this.m_leftBorder.position.x
                   && positionX < this.m_rightBorder.position.x
                   && positionY > this.m_downBorder.position.y
                   && positionY < this.m_topBorder.position.y;
        }
    }
}