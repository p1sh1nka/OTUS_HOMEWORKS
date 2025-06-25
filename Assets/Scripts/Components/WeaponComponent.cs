using UnityEngine;

namespace ShootEmUp
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        public Vector2 Position
        {
            get { return this.m_firePoint.position; }
        }

        public Quaternion Rotation
        {
            get { return this.m_firePoint.rotation; }
        }

        [SerializeField] 
        private Transform m_firePoint;
    }
}