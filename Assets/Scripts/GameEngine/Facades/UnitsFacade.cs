using System.Collections.Generic;

namespace SaveLoadSystem
{
    public class UnitsFacade
    {
        private List<Unit> _units;

        public UnitsFacade(List<Unit> units)
        {
            _units = units;
        }

        public UnitsDataProvider GetUnitsData()
        {
            UnitsDataProvider unitsData = new UnitsDataProvider();
            
            foreach (Unit unit in _units)
            {
                UnitData unitData = new UnitData();
                unitData.Type = unit.Type;
                unitData.HealthPoints = unit.HealthPoints;
                unitData.Damage = unit.Damage;
                unitData.Speed = unit.Speed;
                
                
                unitsData.Data.Add(unitData);
            }
            
            return unitsData;
        }

        public void SetupUnitsFromData(UnitsDataProvider unitsData)
        {
            for (int i = 0; i < _units.Count; i++)
            {
                _units[i].SetData(unitsData.Data[i]);
            }
        }
        
        public List<Unit> GetUnits() => _units;
    }
}