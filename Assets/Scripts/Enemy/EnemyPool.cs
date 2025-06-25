using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [Header("Spawn")]
        [SerializeField]
        private EnemyPositions m_enemyPositions;

        [SerializeField]
        private GameObject m_character;

        [SerializeField]
        private Transform m_worldTransform;

        [Header("Pool")]
        [SerializeField]
        private Transform m_container;

        [SerializeField]
        private GameObject m_prefab;

        private readonly Queue<GameObject> enemyPool = new();

        private int m_initialEnemy = 7;
        private void Awake()
        {
            for (var i = 0; i < m_initialEnemy; i++)
            {
                var enemy = Instantiate(this.m_prefab, this.m_container);
                this.enemyPool.Enqueue(enemy);
            }
        }

        public bool TrySpawnEnemy(out GameObject enemy)
        {
            if (!this.enemyPool.TryDequeue(out enemy))
            {
                return false;
            }

            enemy.transform.SetParent(this.m_worldTransform);

            var spawnPosition = this.m_enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;
            
            var attackPosition = this.m_enemyPositions.RandomAttackPosition();
            if (enemy.TryGetComponent(out EnemyMoveAgent moveAgent))
            {
                moveAgent.SetDestination(attackPosition.position);
            }

            if (enemy.TryGetComponent(out EnemyAttackAgent attackAgent))
            {
                attackAgent.SetTarget(this.m_character);
            }
            
            return enemy;
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(this.m_container);
            this.enemyPool.Enqueue(enemy);
        }
    }
}