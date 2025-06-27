namespace GameCycleLogic.GameCycleInterfaces
{
    public interface IInitializable : IGameStateListener
    {
        void OnInitGame();
    }
}