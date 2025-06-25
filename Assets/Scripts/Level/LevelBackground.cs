using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBackground : MonoBehaviour
    {
        private float m_startPositionY;

        private float m_endPositionY;

        private float m_movingSpeedY;

        private float m_positionX;

        private float m_positionZ;

        private Transform m_myTransform;

        [SerializeField]
        private Params m_params;

        private void Awake()
        {
            this.m_startPositionY = this.m_params.StartPositionY;
            this.m_endPositionY = this.m_params.EndPositionY;
            this.m_movingSpeedY = this.m_params.MovingSpeedY;
            this.m_myTransform = this.transform;
            var position = this.m_myTransform.position;
            this.m_positionX = position.x;
            this.m_positionZ = position.z;
        }

        private void FixedUpdate()
        {
            if (this.m_myTransform.position.y <= this.m_endPositionY)
            {
                this.m_myTransform.position = new Vector3(
                    this.m_positionX,
                    this.m_startPositionY,
                    this.m_positionZ
                );
            }

            this.m_myTransform.position -= new Vector3(
                this.m_positionX,
                this.m_movingSpeedY * Time.fixedDeltaTime,
                this.m_positionZ
            );
        }

        [Serializable]
        public sealed class Params
        {
            [SerializeField]
            public float StartPositionY;

            [SerializeField]
            public float EndPositionY;

            [SerializeField]
            public float MovingSpeedY;
        }
    }
}