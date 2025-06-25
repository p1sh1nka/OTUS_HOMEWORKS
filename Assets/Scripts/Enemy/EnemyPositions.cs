using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPositions : MonoBehaviour
    {
        [SerializeField]
        private Transform[] m_spawnPositions;

        [SerializeField]
        private Transform[] m_attackPositions;

        public Transform RandomSpawnPosition()
        {
            return this.RandomTransform(this.m_spawnPositions);
        }

        public Transform RandomAttackPosition()
        {
            return this.RandomTransform(this.m_attackPositions);
        }

        private Transform RandomTransform(Transform[] transforms)
        {
            var index = Random.Range(0, transforms.Length);
            return transforms[index];
        }
    }
}