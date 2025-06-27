using GameCycleLogic;
using GameCycleLogic.GameCycleInterfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UILogic
{
    public class GameStartUI : 
        MonoBehaviour, 
        IInitializable
    {
        [SerializeField]
        private GameCycle m_GameCycle;

        private Button m_StartGameButton;

        void IInitializable.OnInitGame()
        {
            if (this.TryGetComponent(out Button m_StartGameButton))
            {
                m_StartGameButton.onClick.AddListener(m_GameCycle.OnStart);
            }
        }
    }
}