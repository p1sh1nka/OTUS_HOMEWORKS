using System;

namespace SaveLoadSystem
{
    public abstract class SaveLoader<TData> : ISaveLoader where TData : ISaveLoadable
    {
        private IGameRepository _repository;

        public SaveLoader(IGameRepository repository)
        {
            _repository = repository;
        }

        public void Save()
        {
            TData data = ConvertToData();
            _repository.AddData(data);
        }

        public void Load()
        {
            if (_repository.TryGetData(out TData data))
            {
                SetupData(data);
            }
            else
            {
                throw new Exception("No data found");
            }
        }

        protected abstract TData ConvertToData();
        protected abstract void SetupData(TData data);
    }
}