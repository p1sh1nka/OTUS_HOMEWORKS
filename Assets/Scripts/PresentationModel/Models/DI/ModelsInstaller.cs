using System;
using UnityEngine;
using Zenject;

namespace PM
{
    public sealed class ModelsInstaller : MonoInstaller
    {
        [SerializeField] private HeroConfig _heroConfig;
        
        public override void InstallBindings()
        {
            InstallHeroInfoService();
            InstallHeroLevelService();
            InstallHeroAbilityGroupService();
        }
        
        private void InstallHeroInfoService()
        {
            Container.Bind<HeroInfoService>().FromMethod(() =>
            {
                HeroInfoService heroInfoService = new HeroInfoService();
                
                heroInfoService.UpdateName(_heroConfig.Name);
                heroInfoService.UpdateDescription(_heroConfig.Description);
                heroInfoService.UpdateIcon(_heroConfig.Icon);
                
                return heroInfoService;
            }).AsCached();
        }

        private void InstallHeroLevelService()
        {
            Container.Bind<HeroLevelService>().AsCached();
        }

        private void InstallHeroAbilityGroupService()
        {
            Container.Bind<HeroAbilityGroupService>().FromMethod(() =>
            {
                HeroAbilityGroupService heroAbilityGroupService = new();

                foreach (var ability in _heroConfig.DefaultAbilities)
                {
                    HeroAbilityService heroAbilityService = new();
                    heroAbilityService.ChangeName(ability.Key);
                    heroAbilityService.ChangeValue(ability.Value);

                    heroAbilityGroupService.TryAddHeroAbility(heroAbilityService);
                }

                return heroAbilityGroupService;
            }).AsCached();
        }
    }
}