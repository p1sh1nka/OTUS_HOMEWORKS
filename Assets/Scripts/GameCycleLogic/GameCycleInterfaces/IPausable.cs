namespace GameCycleLogic.GameCycleInterfaces
{
    public interface IPausable : IGameStateListener
    {
        void OnGamePause();
    }
}