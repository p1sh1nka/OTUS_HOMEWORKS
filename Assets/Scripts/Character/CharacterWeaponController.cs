using System;
using UnityEngine;

namespace ShootEmUp
{
    public class CharacterWeaponController : MonoBehaviour
    {
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletConfig;
        [SerializeField] private GameObject character;
        [SerializeField] private PlayerInputManager inputManager;
         
        private WeaponComponent _weaponComponent;

        private void Start()
        {
            _weaponComponent = character.GetComponent<WeaponComponent>();
            inputManager.OnSpacePressed += OnFlyBullet;
        }
        
        private void OnFlyBullet()
        {
            BulletArgs bulletArgs = FormBulletArgs();
            _bulletSystem.FlyBulletByArgs(bulletArgs);
        }

        private BulletArgs FormBulletArgs()
        {
            return new BulletArgs
            {
                isPlayer = true,
                physicsLayer = (int)this._bulletConfig.physicsLayer,
                color = this._bulletConfig.color,
                damage = this._bulletConfig.damage,
                position = _weaponComponent.Position,
                velocity = _weaponComponent.Rotation * Vector3.up * this._bulletConfig.speed
            };
        }
    }
}