using UnityEngine;
using Zenject;

namespace SaveLoadSystem
{
    public class GameLogicInstaller : MonoInstaller
    {
        [SerializeField] private Transform _unitsContainer;
        [SerializeField] private Transform _resourcesContainer;

        public override void InstallBindings()
        {
            InstallUnits();
            InstallResources();
            InstallFacades();
        }

        private void InstallUnits()
        {
            foreach (Unit unit in _unitsContainer.GetComponentsInChildren<Unit>())
            {
                Container.BindInstance(unit).AsTransient();
            }
        }

        private void InstallResources()
        {
            foreach (Resource resource in _resourcesContainer.GetComponentsInChildren<Resource>())
            {
                Container.BindInstance(resource).AsTransient();
            }
        }

        private void InstallFacades()
        {
            Container.Bind<UnitsFacade>().AsSingle();
            Container.Bind<ResourcesFacade>().AsSingle();
        }
    }
}