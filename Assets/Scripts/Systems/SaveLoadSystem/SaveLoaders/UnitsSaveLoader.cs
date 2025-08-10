using System.Collections.Generic;

namespace SaveLoadSystem
{
    public class UnitsSaveLoader : SaveLoader<UnitsDataProvider>
    {
        private UnitsFacade _unitFacade;
        
        public UnitsSaveLoader(UnitsFacade facade, IGameRepository repository) : base(repository)
        {
            _unitFacade = facade;
        }
 
        protected override UnitsDataProvider ConvertToData()
        {
            return _unitFacade.GetUnitsData();
        }

        protected override void SetupData(UnitsDataProvider data)
        {
            _unitFacade.SetupUnitsFromData(data);
        }
    }
}