namespace GameCycleLogic.GameCycleInterfaces
{
    public interface IGameUpdateListener : IGameStateListener
    {
        void OnUpdate(float deltaTime);
    }
}