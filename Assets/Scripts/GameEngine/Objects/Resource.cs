using UnityEngine;

namespace SaveLoadSystem
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] private ResourceType _type;
        public ResourceType Type => _type;

        [SerializeField] private int _count;
        public int Count => _count;

        public void SetData(ResourceData resourceData)
        {
            _type = resourceData.Type;
            _count = resourceData.Count;
        }
    }
}