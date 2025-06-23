using UnityEngine;

namespace ShootEmUp
{
    public static class BulletBuilder
    {
        public static Bullet BuildBullet(Bullet bullet, BulletArgs bulletArgs)
        {
            bullet.SetPosition(bulletArgs.position);
            bullet.SetColor(bulletArgs.color);
            bullet.SetPhysicsLayer(bulletArgs.physicsLayer);
            bullet.damage = bulletArgs.damage;
            bullet.isPlayer = bulletArgs.isPlayer;
            bullet.SetVelocity(bulletArgs.velocity);
            
            return bullet;
        }
    }
}