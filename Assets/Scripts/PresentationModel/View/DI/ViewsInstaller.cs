using UnityEngine;
using Zenject;

namespace PM
{
    public class ViewsInstaller : MonoInstaller
    {
        [SerializeField] private HeroView heroView;
        [SerializeField] private HeroInfoView heroInfoView;
        [SerializeField] private HeroLevelView heroLevelView;
        [SerializeField] private HeroAbilityGroupView heroAbilityGroupView;
        
        public override void InstallBindings()
        {
            InstallHeroView();
        }

        private void InstallHeroView()
        {
            Container.Bind<HeroInfoView>().FromInstance(heroInfoView).AsSingle();
            Container.Bind<HeroLevelView>().FromInstance(heroLevelView).AsSingle();
            Container.Bind<HeroAbilityGroupView>().FromInstance(heroAbilityGroupView).AsSingle();
            
            Container.Bind<HeroView>().FromInstance(heroView).AsCached();
        }
    }
}