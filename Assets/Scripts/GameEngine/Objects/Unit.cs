using SaveLoadSystem;
using UnityEngine;

namespace SaveLoadSystem
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private UnitType _type;
        public UnitType Type => _type;
        
        [SerializeField] private int _healthPoints;
        public int HealthPoints => _healthPoints;
        
        [SerializeField] private int _damage;
        public int Damage => _damage;
        
        [SerializeField] private int _speed;
        public int Speed => _speed;

        public void SetData(UnitData unitData)
        {
            _type = unitData.Type;
            _healthPoints = unitData.HealthPoints;
            _damage = unitData.Damage;
            _speed = unitData.Speed;
        }
    }
}