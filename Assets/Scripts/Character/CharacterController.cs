using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour
    {
        [SerializeField] 
        private GameObject m_character;
    
        [SerializeField] 
        private PlayerInputManager m_inputManager;

        private MoveComponent m_moveComponent;
        private PlayerHitPointsComponent m_hitPointsComponent;

        private void OnEnable()
        {
            if (m_character.TryGetComponent(out m_hitPointsComponent))
            {
                m_hitPointsComponent.OnHitPointsEmpty += OnCharacterDeath;
            }
        }

        private void Start()
        {
            if (!m_character.TryGetComponent(out m_moveComponent))
            {
                Debug.LogError("MoveComponent not found on character.");
            }
        }

        private void OnDisable()
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

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            float horizontalInput = m_inputManager.GetHorizontalDirection();
            m_moveComponent.MoveByRigidbodyVelocity(new Vector2(horizontalInput, 0) * Time.fixedDeltaTime);
        }
       
    }
}