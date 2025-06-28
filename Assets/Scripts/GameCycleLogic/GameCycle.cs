using System;
using UnityEngine;
using System.Collections.Generic;
using GameCycleLogic.GameCycleInterfaces;
using ShootEmUp;

namespace GameCycleLogic
{
    public class GameCycle : MonoBehaviour
    {
        private List<IGameStateListener> m_listeners = new List<IGameStateListener>();
        
        private List<IUpdatable> m_gameUpdateListeners = new List<IUpdatable>();
        private List<IFixedUpdatable> m_gameFixedUpdateListeners = new List<IFixedUpdatable>();

        private GameState m_gameState = GameState.OFF;
        public void AddListener(IGameStateListener listener)
        {
            m_listeners.Add(listener as IGameStateListener);
            
            if (listener is IUpdatable)
            {
                m_gameUpdateListeners.Add(listener as IUpdatable);
            }
            if (listener is IFixedUpdatable)
            {
                m_gameFixedUpdateListeners.Add(listener as IFixedUpdatable);
            }
        }

        public void RemoveListener(IGameStateListener listener)
        {
            m_listeners.Remove(listener as IGameStateListener);
            
            if (listener is IUpdatable)
            {
                m_gameUpdateListeners.Remove(listener as IUpdatable);
            }
            if (listener is IFixedUpdatable)
            {
                m_gameFixedUpdateListeners.Remove(listener as IFixedUpdatable);
            }
        }

        public void AddListenersOfGameObject(GameObject gameObject)
        {
            foreach (var listener in gameObject.GetComponents<MonoBehaviour>())
            {
                if (listener is IGameStateListener gameStateListener)
                {
                    this.AddListener(gameStateListener);
                }
            }
        }

        public void RemoveListenersOfGameObject(GameObject gameObject)
        {
            foreach (var listener in gameObject.GetComponents<MonoBehaviour>())
            {
                if (listener is IGameStateListener gameStateListener)
                {
                    this.RemoveListener(gameStateListener);
                }
            }
        }

        public void OnInit()
        {
            foreach (var gameStateListener in m_listeners)
            {
                if (gameStateListener is IInitializable gameInitListener)
                {
                    gameInitListener.OnInitGame();
                }
            }

            m_gameState = GameState.INITIALIZED;
        }
        public void OnStart()
        {
            for (var index = 0; index < m_listeners.Count; index++)
            {
                var gameStateListener = m_listeners[index];
                if (gameStateListener is IStartable gameStartListener)
                {
                    gameStartListener.OnGameStart();
                }
            }

            m_gameState = GameState.PLAYING;
        }

        public void OnPause()
        {
            m_gameState = GameState.PAUSED;
            
            for (var index = 0; index < m_listeners.Count; index++)
            {
                var gameStateListener = m_listeners[index];
                if (gameStateListener is IPausable gamePauseListener)
                {
                    gamePauseListener.OnGamePause();
                }
            }
        }
        
        public void OnResume()
        {
            for (var index = 0; index < m_listeners.Count; index++)
            {
                var gameStateListener = m_listeners[index];
                if (gameStateListener is IResumable gameResumeListener)
                {
                    gameResumeListener.OnGameResume();
                }
            }
            
            m_gameState = GameState.PLAYING;
        }

        private void Update()
        {
            if (m_gameState != GameState.PLAYING)
                return;
            
            float deltaTime = Time.deltaTime;

            for (var index = 0; index < m_gameUpdateListeners.Count; index++)
            {
                var gameStateListener = m_gameUpdateListeners[index];
                if (gameStateListener is IUpdatable gameUpdateListener)
                {
                    gameUpdateListener.OnUpdate(deltaTime);
                }
            }
        }

        private void FixedUpdate()
        {
            if (m_gameState != GameState.PLAYING)
                return;
            
            float fixedDeltaTime = Time.fixedDeltaTime;

            for (var index = 0; index < m_gameFixedUpdateListeners.Count; index++)
            {
                var gameStateListener = m_gameFixedUpdateListeners[index];
                if (gameStateListener is IFixedUpdatable gameFixedUpdateListener)
                {
                    gameFixedUpdateListener.OnFixedUpdate(fixedDeltaTime);
                }
            }
        }

        public void OnFinish()
        {
            for (var index = 0; index < m_listeners.Count; index++)
            {
                var gameStateListener = m_listeners[index];
                if (gameStateListener is IFinishable gameFinishListener)
                {
                    gameFinishListener.OnGameFinish();
                }
            }

            m_gameState = GameState.FINISHED;
        }
    }
}