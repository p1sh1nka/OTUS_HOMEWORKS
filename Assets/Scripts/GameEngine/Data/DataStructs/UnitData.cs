using System;
using System.Collections.Generic;

namespace SaveLoadSystem
{
    [Serializable]
    public struct UnitData
    {
        public UnitType Type;

        public int HealthPoints;

        public int Damage;

        public int Speed;
    }
}