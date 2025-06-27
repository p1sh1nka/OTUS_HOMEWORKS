using System;
using System.Collections;
using System.Collections.Generic;
using GameCycleLogic.GameCycleInterfaces;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : 
        MonoBehaviour,
        IStartable,
        IPausable,
        IResumable
    {
        [SerializeField]
        private EnemyPool m_enemyPool;

        [SerializeField]
        private BulletSystem m_bulletSystem;
        
        [SerializeField]
        private BulletConfig m_bulletConfig;
        
        [SerializeField]
        private GameObjectEventsHandler m_gameObjectEventsHandler;
        
        private readonly HashSet<GameObject> m_activeEnemies = new();

        private float m_enemySpawnDelayTime = 1f;

       void IStartable.OnGameStart()
       {
           StartCoroutine(OnStart());
       }
        
       public void OnGamePause()
       {
           StopCoroutine(OnStart());
       }

       public void OnGameResume()
       {
           StartCoroutine(OnStart());
       }
       
        private IEnumerator OnStart()
        {
            while (true)
            {
                yield return new WaitForSeconds(m_enemySpawnDelayTime);
                
                if (this.m_enemyPool.TrySpawnEnemy(out GameObject enemy))
                {
                    if (this.m_activeEnemies.Add(enemy))
                    {
                        if (enemy.TryGetComponent(out EnemyHitPointsComponent hitPoints))
                        {
                            hitPoints.OnHitPointsEmpty += OnDestroyed;
                        }

                        if (enemy.TryGetComponent(out EnemyAttackAgent attackAgent))
                        {
                            attackAgent.OnFire += OnFire;
                        }
                        
                        m_gameObjectEventsHandler.SubscribeAllEvents(enemy);
                    }    
                }
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (m_activeEnemies.Remove(enemy))
            {
                if (enemy.TryGetComponent(out EnemyHitPointsComponent hitPoints))
                {
                    hitPoints.OnHitPointsEmpty -= OnDestroyed;
                }

                if (enemy.TryGetComponent(out EnemyAttackAgent attackAgent))
                {
                    attackAgent.OnFire -= OnFire;
                }

                m_enemyPool.UnspawnEnemy(enemy);
            }
        }

        private void OnFire(GameObject enemy, Vector2 position, Vector2 direction)
        {
            m_bulletSystem.FlyBulletByArgs(new BulletArgs
            {
                IsPlayer = false,
                PhysicsLayer = (int)m_bulletConfig.PhysicsLayer,
                Color = m_bulletConfig.Color,
                Damage = m_bulletConfig.Damage,
                Position = position,
                Velocity = direction * m_bulletConfig.Speed,
            });
        }
    }
}