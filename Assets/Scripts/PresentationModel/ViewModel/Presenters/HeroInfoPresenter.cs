using System;
using UniRx;
using UnityEngine;

namespace PM
{
    public class HeroInfoPresenter : IHeroInfoPresenter, IDisposable
    {
        public Action OnHided { get; }
        public IReadOnlyReactiveProperty<string> Name => _name;
        public IReadOnlyReactiveProperty<string> Description => _description;
        public IReadOnlyReactiveProperty<Sprite> Icon => _icon;
        
        private readonly ReactiveProperty<string> _name;
        private readonly ReactiveProperty<string> _description;
        private readonly ReactiveProperty<Sprite> _icon;
        
        HeroInfoService _heroInfoService;

        public HeroInfoPresenter(HeroInfoService heroInfoService)
        {
            _heroInfoService = heroInfoService;
            
            _name = new ReactiveProperty<string>(heroInfoService.Name);
            _description = new ReactiveProperty<string>(heroInfoService.Description);
            _icon = new ReactiveProperty<Sprite>(heroInfoService.Icon);

            _heroInfoService.OnNameUpdated += UpdateName;
            _heroInfoService.OnDescriptionUpdated += UpdateDescription;
            _heroInfoService.OnIconUpdated += UpdateIcon;

            OnHided += _heroInfoService.ResetValues;
        }

        private void UpdateName(string name)
        {
            _name.Value = name;
        }

        private void UpdateDescription(string description)
        {
            _description.Value = description;
        }

        private void UpdateIcon(Sprite icon)
        {
            _icon.Value = icon;
        }

        public void Dispose()
        {
            _heroInfoService.OnNameUpdated -= UpdateName;
            _heroInfoService.OnDescriptionUpdated -= UpdateDescription;
            _heroInfoService.OnIconUpdated -= UpdateIcon;
        }
    }
}