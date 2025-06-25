namespace GameCycleLogic.GameCycleInterfaces
{
    public interface IGameFinishListener : IGameStateListener
    {
        void OnGameFinish();
    }
}