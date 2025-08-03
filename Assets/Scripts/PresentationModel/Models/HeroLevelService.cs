using System;

namespace PM
{
    public sealed class HeroLevelService
    {
        public event Action<int,int> OnExpUp;
        public event Action<int> OnLevelUp;
        
        public int CurrentLevel { get; private set; }
        public int CurrentExp { get; private set; }
        public int RequiredExp => (CurrentLevel + 1) * _expConfig.RequiredExpIncreaseFactor;

        private ExpConfig _expConfig;
        
        public HeroLevelService(ExpConfig expConfig)
        {
            _expConfig = expConfig;
        }

        public void AddExp(int amount)
        {
            CurrentExp += amount;
            OnExpUp?.Invoke(CurrentExp, RequiredExp);
        }
        
        public void LevelUp()
        {
            if (CanLevelUp() != true)
                return;
            
            do
            {
                CurrentExp -= RequiredExp;
                CurrentLevel++;
            } while (CurrentExp >= RequiredExp);
            
            OnLevelUp?.Invoke(CurrentLevel);
        }

        public bool CanLevelUp()
        {
            if (CurrentExp >= RequiredExp)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ResetValues()
        {
            CurrentLevel = 1;
            CurrentExp = 0;
            
            OnLevelUp?.Invoke(CurrentLevel);
            OnExpUp?.Invoke(CurrentExp, RequiredExp);
        }
    }
}