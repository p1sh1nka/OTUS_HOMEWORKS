using System;
using UnityEngine;
using Zenject;

namespace PM
{
    [CreateAssetMenu(fileName = "Scriptable Objects Installer", menuName = "Installers/ScriptableObjects Installer")]
    public sealed class ScriptableObjectsInstaller : ScriptableObjectInstaller<ScriptableObjectsInstaller>
    {
        public Settings _settings;
        
        public override void InstallBindings()
        {
            InstallExpConfig();
        }

        private void InstallExpConfig()
        {
            Container.Bind<ExpConfig>().FromInstance(_settings.ExpConfig).AsSingle();
            Container.Bind<HeroConfig>().FromInstance(_settings.HeroConfig).AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public ExpConfig ExpConfig;
            public HeroConfig HeroConfig;
        }
    }
}