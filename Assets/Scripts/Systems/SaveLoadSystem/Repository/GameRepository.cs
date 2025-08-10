using System;
using System.Collections.Generic;
using System.IO;
using SaveLoadSystem;
using UnityEngine;
using Unity.Plastic.Newtonsoft.Json;

namespace SaveLoadSystem
{
    public sealed class GameRepository : IGameRepository
    {
        private Dictionary<Type, string> _gameData = new();
        
        private readonly string _filePath = Application.persistentDataPath + "/Storage.json";

        public GameRepository()
        {
            LoadState();
        }
        
        public bool TryGetData<TData>(out TData data) where TData : ISaveLoadable
        {
            Type dataType = typeof(TData);
            
            if (_gameData.TryGetValue(dataType, out string serializedData))
            {
                data = JsonUtility.FromJson<TData>(serializedData);
                
                Debug.Log(serializedData);
                
                return true;
            }
            
            data = default;
            return false;
        }

        public void AddData<TData>(TData data)
        {
            Type dataType = typeof(TData);
            string serializedData = JsonUtility.ToJson(data);
            _gameData[dataType] = serializedData;
        }

        public void LoadState()
        {
            string encryptedData = File.ReadAllText(_filePath);
            string decryptedData = AESManager.Decrypt(encryptedData);
            _gameData = JsonConvert.DeserializeObject<Dictionary<Type, string>>(decryptedData);
        }

        public void SaveState()
        {
            string serializedData = JsonConvert.SerializeObject(_gameData);
            string encryptedData = AESManager.Encrypt(serializedData);
            File.WriteAllText(_filePath, encryptedData);
            
            Debug.Log(_filePath);
            Debug.Log("Here");
        }
    }
}