using GameCycleLogic.GameCycleInterfaces;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : 
        MonoBehaviour, 
        IInitializable, 
        IFixedUpdatable, 
        IFinishable
    {
        [SerializeField] 
        private GameObject m_character;
    
        [SerializeField] 
        private PlayerInputManager m_inputManager;

        private MoveComponent m_moveComponent;
        private PlayerHitPointsComponent m_hitPointsComponent;
        
        void IInitializable.OnInitGame()
        {
            if (m_character.TryGetComponent(out m_hitPointsComponent))
            {
                m_hitPointsComponent.OnHitPointsEmpty += OnCharacterDeath;
            }
            
            if (!m_character.TryGetComponent(out m_moveComponent))
            {
                Debug.LogError("MoveComponent not found on character.");
            }
        }

        public void OnGameFinish()
        {
            if (m_hitPointsComponent != null)
            {
                m_hitPointsComponent.OnHitPointsEmpty -= OnCharacterDeath;
            }
        }

        private void OnCharacterDeath()
        {
            GameFinishHandler.FinishGame();
        }

        void IFixedUpdatable.OnFixedUpdate(float fixedDeltaTime)
        {
            MovePlayer(fixedDeltaTime);
        }

        private void MovePlayer(float fixedDeltaTime)
        {
            float horizontalInput = m_inputManager.GetHorizontalDirection();
            m_moveComponent.MoveByRigidbodyVelocity(new Vector2(horizontalInput, 0) * fixedDeltaTime);
        }
    }
}