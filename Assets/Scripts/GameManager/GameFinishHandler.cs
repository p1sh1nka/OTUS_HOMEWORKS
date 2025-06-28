using GameCycleLogic.GameCycleInterfaces;
using UnityEngine;

namespace ShootEmUp
{
    public class GameFinishHandler :
        MonoBehaviour, 
        IFinishable
    {
        [SerializeField]
        private GameObject m_gameFinishUI;
        
        public void OnGameFinish()
        {
            m_gameFinishUI.SetActive(true);
        }
    }
}