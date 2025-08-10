using Zenject;

namespace SaveLoadSystem
{
    public class SaveLoadSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallRepository();
            InstallSaveLoaders();
            InstallGameStateManager();
        }

        private void InstallRepository()
        {
            Container.Bind<IGameRepository>().To<GameRepository>().AsSingle();
        }
        
        private void InstallSaveLoaders()
        {
            Container.Bind<UnitsSaveLoader>().AsSingle();
            Container.Bind<ResourcesSaveLoader>().AsSingle();
        }

        private void InstallGameStateManager()
        {
            Container.Bind<GameStateManager>().AsSingle();
        }
    }
}