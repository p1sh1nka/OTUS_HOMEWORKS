using GameCycleLogic;
using GameCycleLogic.GameCycleInterfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UILogic
{
    public class PauseButtonUI : MonoBehaviour, IInitializable
    {
        [SerializeField] 
        private GameCycle m_gameCycle;
        
        private Button m_button; 
        void IInitializable.OnInitGame()
        {
            if (this.TryGetComponent(out Button m_button))
            {
                m_button.onClick.AddListener(m_gameCycle.OnPause);
            }
        }
    }
}