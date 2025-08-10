namespace SaveLoadSystem
{
    public class ResourcesSaveLoader : SaveLoader<ResourcesDataProvider>
    {
        private ResourcesFacade _resourcesFacade;
        
        public ResourcesSaveLoader(ResourcesFacade resourcesFacade, IGameRepository repository) : base(repository)
        {
            _resourcesFacade = resourcesFacade;
        }

        protected override ResourcesDataProvider ConvertToData()
        {
            return _resourcesFacade.GetResourcesData();
        }

        protected override void SetupData(ResourcesDataProvider data)
        {
            _resourcesFacade.SetupResourcesFromData(data);
        }
    }
}