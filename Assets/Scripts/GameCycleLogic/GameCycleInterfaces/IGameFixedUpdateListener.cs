namespace GameCycleLogic.GameCycleInterfaces
{
    public interface IGameFixedUpdateListener : IGameStateListener
    {
        void OnFixedUpdate(float fixedDeltaTime);
    }
}