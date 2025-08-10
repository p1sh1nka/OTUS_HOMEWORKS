using System;

namespace SaveLoadSystem
{
    public interface IGameRepository
    {
        bool TryGetData<TData>(out TData data) where TData : ISaveLoadable;
        
        void AddData<TData>(TData data);

        void LoadState();
        
        void SaveState();
    }
}