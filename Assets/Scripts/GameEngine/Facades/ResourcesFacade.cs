using System.Collections.Generic;

namespace SaveLoadSystem
{
    public class ResourcesFacade
    {
        private List<Resource> _resources;

        public ResourcesFacade(List<Resource> resources)
        {
            _resources = resources;
        }

        public ResourcesDataProvider GetResourcesData()
        {
            ResourcesDataProvider resourcesDataProvider = new ResourcesDataProvider();

            foreach (Resource resource in _resources)
            {
                ResourceData resourceData = new ResourceData();
                resourceData.Type = resource.Type;
                resourceData.Count = resource.Count;
                
                resourcesDataProvider.Data.Add(resourceData);
            }
            
            return resourcesDataProvider;
        }

        public void SetupResourcesFromData(ResourcesDataProvider resourcesData)
        {
            for (int i = 0; i < _resources.Count; i++)
            {
                _resources[i].SetData(resourcesData.Data[i]);
            }
        }

        private List<Resource> GetResources() => _resources;
    }
}