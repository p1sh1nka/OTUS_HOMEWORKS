using System;
using GameCycleLogic.GameCycleInterfaces;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerInputManager : 
        MonoBehaviour, 
        IUpdatable
    {
        private float m_horizontalDirection;

        public event Action OnSpacePressed;
        
        void IUpdatable.OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnSpacePressed?.Invoke();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.m_horizontalDirection = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.m_horizontalDirection = 1;
            }
            else
            {
                this.m_horizontalDirection = 0;
            }
        }
        
        public float GetHorizontalDirection() => this.m_horizontalDirection;
    }
}