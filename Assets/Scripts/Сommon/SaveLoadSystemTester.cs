using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace SaveLoadSystem
{
    public class SaveLoadSystemTester : MonoBehaviour
    {
        private GameStateManager _gameStateManager;
        private UnitsSaveLoader _unitsSaveLoader;
        private ResourcesSaveLoader _resourcesSaveLoader;

        [Inject]
        public void Construct(GameStateManager gameStateManager, UnitsSaveLoader unitsSaveLoader, ResourcesSaveLoader resourcesSaveLoader)
        {
            _gameStateManager = gameStateManager;
            _unitsSaveLoader = unitsSaveLoader;
            _resourcesSaveLoader = resourcesSaveLoader;

            Load();
        }
        
        [Button]
        public void Save()
        {
            _unitsSaveLoader.Save();
            _resourcesSaveLoader.Save();
            
            _gameStateManager.SaveState();
        }
        
        [Button]
        public void Load()
        {
            _unitsSaveLoader.Load();
            _resourcesSaveLoader.Load();
            
            _gameStateManager.LoadState();
        }
    }
}