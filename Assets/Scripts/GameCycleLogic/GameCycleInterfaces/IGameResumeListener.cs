namespace GameCycleLogic.GameCycleInterfaces
{
    public interface IGameResumeListener : IGameStateListener
    {
        void OnGameResume();
    }
}