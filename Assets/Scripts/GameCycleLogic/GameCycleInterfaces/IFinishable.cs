namespace GameCycleLogic.GameCycleInterfaces
{
    public interface IFinishable : IGameStateListener
    {
        void OnGameFinish();
    }
}