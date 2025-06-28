

using System.Collections;
using GameCycleLogic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public class ResumeCountdownManager : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text m_countdownText;
        [SerializeField]
        private GameObject m_pauseButton;

        [SerializeField] 
        private GameCycle m_gameCycle;

        private int m_countdown = 3;

        public void OnResume()
        {
            StartCoroutine(OnResumeCountdown());
        }
        
        private IEnumerator OnResumeCountdown()
        {
            m_countdown = 3;
            m_countdownText.gameObject.SetActive(true);
            
            while (m_countdown > 0)
            {
                m_countdownText.text = m_countdown.ToString();
                yield return new WaitForSeconds(1f);
                m_countdown--;
            }

            m_countdownText.text = "GO!";
            yield return new WaitForSeconds(1f);
            
            m_countdownText.gameObject.SetActive(false);
            m_pauseButton.gameObject.SetActive(true);
            
            m_gameCycle.OnResume();
        }
    }
}