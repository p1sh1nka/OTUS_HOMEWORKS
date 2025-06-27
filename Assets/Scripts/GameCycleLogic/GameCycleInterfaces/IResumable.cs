namespace GameCycleLogic.GameCycleInterfaces
{
    public interface IResumable : IGameStateListener
    {
        void OnGameResume();
    }
}