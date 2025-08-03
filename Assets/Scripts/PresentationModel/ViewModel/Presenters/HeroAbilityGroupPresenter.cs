using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace PM
{
    public class HeroAbilityGroupPresenter : IHeroAbilityGroupPresenter, IDisposable
    {
        public event Action<IHeroAbilityPresenter> OnAbilityAdded;
        public event Action<IHeroAbilityPresenter> OnAbilityRemoved;

        IReadOnlyList<IHeroAbilityPresenter> IHeroAbilityGroupPresenter.AbilityPresenters => _abilityPresenters;
        
        private readonly List<IHeroAbilityPresenter> _abilityPresenters = new();

        private readonly Dictionary<HeroAbilityService, HeroAbilityPresenter> _abilities = new();
        
        private readonly HeroAbilityGroupService _heroAbilityGroupService;

        public HeroAbilityGroupPresenter(HeroAbilityGroupService heroAbilityGroupService)
        {
            _heroAbilityGroupService = heroAbilityGroupService;
            
            foreach (HeroAbilityService characterAbilityService in _heroAbilityGroupService.GetAbilities())
            {
                HeroAbilityPresenter heroAbilityPresenter = new HeroAbilityPresenter(characterAbilityService);

                if (_abilities.TryAdd(characterAbilityService, heroAbilityPresenter))
                {
                    _abilityPresenters.Add(heroAbilityPresenter);
                }
            }
            
            _heroAbilityGroupService.OnHeroAbilityAdded += CreateStatPresenter;
            _heroAbilityGroupService.OnHeroAbilityRemoved += RemoveStatPresenter;
        }

        private void CreateStatPresenter(HeroAbilityService heroAbilityService)
        {
            HeroAbilityPresenter heroAbilityPresenter =  new HeroAbilityPresenter(heroAbilityService);
            
            OnAbilityAdded?.Invoke(heroAbilityPresenter);
            
            _abilities.Add(heroAbilityService, heroAbilityPresenter);
        }

        private void RemoveStatPresenter(HeroAbilityService heroAbilityService)
        {
            HeroAbilityPresenter heroAbilityPresenter = _abilities[heroAbilityService];
            
            OnAbilityRemoved?.Invoke(heroAbilityPresenter);
            
            heroAbilityPresenter.Dispose();
            _abilities.Remove(heroAbilityService);
        }

        public void Dispose()
        {
            _heroAbilityGroupService.OnHeroAbilityAdded -= CreateStatPresenter;
            _heroAbilityGroupService.OnHeroAbilityRemoved -= RemoveStatPresenter;

            foreach (var heroAbilityPresenter in _abilities.Values)
            {
                heroAbilityPresenter.Dispose();
            }
        }
    }
}