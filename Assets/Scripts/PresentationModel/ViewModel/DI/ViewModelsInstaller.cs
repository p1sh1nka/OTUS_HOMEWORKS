using Zenject;

namespace PM
{
    public class ViewModelsInstaller : MonoInstaller
    {
        override public void InstallBindings()
        {
            InstallPresenters();
        }

        private void InstallPresenters()
        {
            Container.Bind<IHeroInfoPresenter>().To<HeroInfoPresenter>().AsCached();
            Container.Bind<IHeroLevelPresenter>().To<HeroLevelPresenter>().AsCached();
            Container.Bind<IHeroAbilityGroupPresenter>().To<HeroAbilityGroupPresenter>().AsCached();
        }
        
    }
}