namespace ShootEmUp
{
    public static class BulletBuilder
    {
        public static Bullet BuildBullet(Bullet bullet, BulletArgs bulletArgs)
        {
            bullet.SetPosition(bulletArgs.Position);
            bullet.SetColor(bulletArgs.Color);
            bullet.SetPhysicsLayer(bulletArgs.PhysicsLayer);
            bullet.Damage = bulletArgs.Damage;
            bullet.IsPlayer = bulletArgs.IsPlayer;
            bullet.SetVelocity(bulletArgs.Velocity);
            
            return bullet;
        }
    }
}