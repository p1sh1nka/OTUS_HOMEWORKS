namespace GameCycleLogic.GameCycleInterfaces
{
    public interface IStartable : IGameStateListener
    {
        void OnGameStart();
    }
}