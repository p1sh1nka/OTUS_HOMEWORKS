using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PM
{
    public sealed class HeroAbilityGroupService
    {
        public event Action<HeroAbilityService> OnHeroAbilityAdded;
        public event Action<HeroAbilityService> OnHeroAbilityRemoved;
        
        private readonly HashSet<HeroAbilityService> _abilityServices = new();

        public void TryAddHeroAbility(HeroAbilityService heroAbilityService)
        {
            Debug.Log(heroAbilityService.Name + " :" + heroAbilityService.Value + " added");
            
            if (_abilityServices.Add(heroAbilityService))
            {
                OnHeroAbilityAdded?.Invoke(heroAbilityService);
            }
            else
            {
                throw new Exception("Hero Stat already added");
            }
        }

        public void TryRemoveHeroAbility(HeroAbilityService heroAbilityService)
        {
            Debug.Log(heroAbilityService.Name + " :" + heroAbilityService.Value + " removed");
            
            if (_abilityServices.Remove(heroAbilityService))
            {
                OnHeroAbilityRemoved?.Invoke(heroAbilityService);
            }
            else
            {
                throw new Exception("Hero Stat removing failed");
            }
        }

        public HeroAbilityService GetHeroAbilityService(string heroName)
        {
            foreach (HeroAbilityService heroStatService in _abilityServices)
            {
                if(heroStatService.Name.Equals(heroName))
                    return heroStatService;
            }
            
            throw new Exception("Hero Stat not found by name");
        }

        public void ResetValues()
        {
            _abilityServices.Clear();
        }

        public HeroAbilityService[] GetAbilities()
        {
            return _abilityServices.ToArray();
        }
    }
}