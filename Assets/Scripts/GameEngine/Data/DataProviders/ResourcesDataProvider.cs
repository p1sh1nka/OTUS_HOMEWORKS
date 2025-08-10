using System.Collections.Generic;

namespace SaveLoadSystem
{
    public class ResourcesDataProvider : ISaveLoadable
    {
        public List<ResourceData> Data = new();
    }
}