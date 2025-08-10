using System;
using System.Collections.Generic;

namespace SaveLoadSystem
{
    [Serializable]
    public struct ResourceData
    {
        public ResourceType Type;

        public int Count;
    }
}