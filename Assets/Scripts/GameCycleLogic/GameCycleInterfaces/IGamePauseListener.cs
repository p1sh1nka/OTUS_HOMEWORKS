namespace GameCycleLogic.GameCycleInterfaces
{
    public interface IGamePauseListener : IGameStateListener
    {
        void OnGamePause();
    }
}