using UnityEngine;

namespace ShootEmUp
{
    public class CharacterWeaponController : MonoBehaviour
    {
        [SerializeField] 
        private BulletSystem m_bulletSystem;
        
        [SerializeField] 
        private BulletConfig m_bulletConfig;
        
        [SerializeField] 
        private WeaponComponent m_characterWeaponComponent;
        
        [SerializeField] 
        private PlayerInputManager m_inputManager;

        private void Start()
        {
            m_inputManager.OnSpacePressed += OnFlyBullet;
        }
        
        private void OnFlyBullet()
        {
            BulletArgs bulletArgs = FormBulletArgs();
            m_bulletSystem.FlyBulletByArgs(bulletArgs);
        }

        private BulletArgs FormBulletArgs()
        {
            return new BulletArgs
            {
                IsPlayer = true,
                PhysicsLayer = (int)this.m_bulletConfig.PhysicsLayer,
                Color = this.m_bulletConfig.Color,
                Damage = this.m_bulletConfig.Damage,
                Position = m_characterWeaponComponent.Position,
                Velocity = m_characterWeaponComponent.Rotation * Vector3.up * this.m_bulletConfig.Speed
            };
        }
    }
}