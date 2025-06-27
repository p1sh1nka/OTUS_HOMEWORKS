namespace GameCycleLogic.GameCycleInterfaces
{
    public interface IFixedUpdatable : IGameStateListener
    {
        void OnFixedUpdate(float fixedDeltaTime);
    }
}