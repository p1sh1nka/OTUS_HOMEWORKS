using System.Collections.Generic;

namespace SaveLoadSystem
{
    public class UnitsDataProvider : ISaveLoadable
    {
        public List<UnitData> Data = new();
    }
}