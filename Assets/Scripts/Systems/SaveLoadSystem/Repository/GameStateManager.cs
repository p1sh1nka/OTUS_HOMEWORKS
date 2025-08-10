namespace SaveLoadSystem
{
    public class GameStateManager
    {
        private IGameRepository _gameRepository;

        public GameStateManager(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public void SaveState()
        {
            _gameRepository.SaveState();
        }

        public void LoadState()
        {
            _gameRepository.LoadState();
        }
    }
}