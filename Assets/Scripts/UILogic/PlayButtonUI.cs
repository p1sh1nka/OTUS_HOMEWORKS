using GameCycleLogic;
using GameCycleLogic.GameCycleInterfaces;
using ShootEmUp;
using UnityEngine;
using UnityEngine.UI;

namespace UILogic
{
    public class PlayButtonUI : MonoBehaviour, IInitializable
    {
        [SerializeField] 
        private ResumeCountdownManager m_resumeCountdownManager;
        
        private Button m_button;
        public void OnInitGame()
        {
            if (this.TryGetComponent(out Button m_button))
            {
                m_button.onClick.AddListener(m_resumeCountdownManager.OnResume);
            }
        }
    }
}