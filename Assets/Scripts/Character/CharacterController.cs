using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour
    {
        [SerializeField] private GameObject character;
        [SerializeField] private PlayerInputManager inputManager;
        
        private MoveComponent moveComponent;
        
        private void OnEnable()
        {
            this.character.GetComponent<PlayerHitPointsComponent>().hpEmpty += this.OnCharacterDeath;
        }

        private void Start()
        {
            moveComponent = character.GetComponent<MoveComponent>();
        }

        private void OnDisable()
        {
            this.character.GetComponent<PlayerHitPointsComponent>().hpEmpty -= this.OnCharacterDeath;
        }

        private void OnCharacterDeath() => GameFinishHandler.FinishGame();

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            float horizontalInput = inputManager.GetHorizontalDirection();
            moveComponent.MoveByRigidbodyVelocity(new Vector2(horizontalInput, 0) * Time.fixedDeltaTime);
        }

       
    }
}