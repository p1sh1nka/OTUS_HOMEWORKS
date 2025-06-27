using System.Collections.Generic;
using GameCycleLogic.GameCycleInterfaces;
using UnityEngine;

namespace GameCycleLogic
{
    [DefaultExecutionOrder(-5000)] 
    public class GameCycleInstaller : MonoBehaviour
    {
        [SerializeField]
        private GameCycle m_gameCycle;
        
        public MonoBehaviour[] m_monoBehaviours;
        
        private void Awake()
        {
            m_monoBehaviours = Resources.FindObjectsOfTypeAll<MonoBehaviour>();

            foreach (var monoBehaviour in m_monoBehaviours)
            {
                if (monoBehaviour is IGameStateListener listener)
                {
                    m_gameCycle.AddListener(listener);
                }
            }
            
            m_gameCycle.OnInit();
        }
    }
}