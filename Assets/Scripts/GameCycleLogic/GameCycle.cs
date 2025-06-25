using System;
using UnityEngine;
using System.Collections.Generic;
using GameCycleLogic.GameCycleInterfaces;

namespace GameCycleLogic
{
    public class GameCycle : MonoBehaviour
    {
        private List<IGameStateListener> _listeners = new List<IGameStateListener>();
        
        private List<IGameUpdateListener> _gameUpdateListeners = new List<IGameUpdateListener>();
        private List<IGameFixedUpdateListener> _gameFixedUpdateListeners = new List<IGameFixedUpdateListener>();

        private GameState _gameState = GameState.OFF;

        public void AddListener(IGameStateListener listener)
        {
            if(listener is IGameUpdateListener)
                _gameUpdateListeners.Add(listener as IGameUpdateListener);
            else if(listener is IGameFixedUpdateListener)
                _gameFixedUpdateListeners.Add(listener as IGameFixedUpdateListener);
            else
                _listeners.Add(listener as IGameStateListener);
        }
        
        private void Awake()
        {
            
        }

        void Start()
        {
            if(_gameState != GameState.OFF)
                return;
            
            foreach (IGameStateListener gameStateListener in _listeners)
            {
                if(gameStateListener is IGameStartListener)
                    ((IGameStartListener)gameStateListener).OnGameStart();
            }
            
            _gameState = GameState.PLAYING;
        }

        public void OnUpdate()
        {
            if (_gameState != GameState.PLAYING)
                return;
            
            float deltaTime = Time.deltaTime;
            
            foreach (IGameStateListener gameStateListener in _listeners)
            {
                
                if(gameStateListener is IGameUpdateListener)
                    ((IGameUpdateListener)gameStateListener).OnUpdate(deltaTime);
            }
        }

        public void OnFixedUpdate()
        {
            if (_gameState != GameState.PLAYING)
                return;
            
            float fixedDeltaTime = Time.fixedDeltaTime;
            
            foreach (IGameStateListener gameStateListener in _listeners)
            {
                
                if(gameStateListener is IGameFixedUpdateListener)
                    ((IGameFixedUpdateListener)gameStateListener).OnFixedUpdate(fixedDeltaTime);
            }
        }
    }
}