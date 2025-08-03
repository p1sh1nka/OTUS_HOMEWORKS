using System;
using UnityEngine;

namespace PM
{
    public sealed class HeroInfoService
    {
        public event Action<string> OnNameUpdated;
        public event Action<string> OnDescriptionUpdated;
        public event Action<Sprite> OnIconUpdated;
        
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Sprite Icon { get; private set; }
        
        public void UpdateName(string name)
        {
            Name = name;
            OnNameUpdated?.Invoke(name);
        }

        public void UpdateDescription(string description)
        {
            Description = description;
            OnDescriptionUpdated?.Invoke(description);
        }

        public void UpdateIcon(Sprite icon)
        {
            Icon = icon;
            OnIconUpdated?.Invoke(icon);
        }

        public void ResetValues()
        {
            Name = string.Empty;
            Description = string.Empty;
            Icon = null;
        }
    }
}