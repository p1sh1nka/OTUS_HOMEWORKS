using GameCycleLogic;
using GameCycleLogic.GameCycleInterfaces;
using UnityEngine;

namespace ShootEmUp
{
    public class GameObjectEventsHandler : MonoBehaviour
    {
        [SerializeField] private GameCycle m_gameCycle;

        public void SubscribeAllEvents(GameObject go)
        {
            foreach (var listener in go.GetComponents<MonoBehaviour>())
            {
                if (listener is IGameStateListener gameStateListener)
                {
                    Debug.Log($"Subscribed {listener.GetType().Name}");
                    m_gameCycle.AddListener(gameStateListener);
                }
            }
        }

        public void UnsubscribeAllEvents(GameObject go)
        {
            foreach (var listener in go.GetComponents<MonoBehaviour>())
            {
                if (listener is IGameStateListener gameStateListener)
                {
                    Debug.Log($"Unsubscribed {listener.GetType().Name}");
                    m_gameCycle.RemoveListener(gameStateListener);
                }
            }
        }
    }
}