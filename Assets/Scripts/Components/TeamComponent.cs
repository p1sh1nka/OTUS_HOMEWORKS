using UnityEngine;

namespace ShootEmUp
{
    public sealed class TeamComponent : MonoBehaviour
    {
        public bool IsPlayer
        {
            get { return this.m_isPlayer; }
        }
        
        [SerializeField] 
        private bool m_isPlayer;
    }
}