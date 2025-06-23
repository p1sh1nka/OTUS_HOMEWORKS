using System;
using UnityEngine;
using UnityEngine.Events;

namespace ShootEmUp
{
    public sealed class PlayerInputManager : MonoBehaviour
    {
        private float horizontalDirection;

        public Action OnSpacePressed;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnSpacePressed?.Invoke();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.horizontalDirection = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.horizontalDirection = 1;
            }
            else
            {
                this.horizontalDirection = 0;
            }
        }
        
        public float GetHorizontalDirection() => this.horizontalDirection;
    }
}