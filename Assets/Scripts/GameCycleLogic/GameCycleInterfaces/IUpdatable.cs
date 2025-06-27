namespace GameCycleLogic.GameCycleInterfaces
{
    public interface IUpdatable : IGameStateListener
    {
        void OnUpdate(float deltaTime);
    }
}