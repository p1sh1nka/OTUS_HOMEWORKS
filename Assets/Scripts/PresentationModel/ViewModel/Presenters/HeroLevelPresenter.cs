using System;
using UniRx;

namespace PM
{
    public class HeroLevelPresenter : IHeroLevelPresenter
    {
        public Action OnHided { get; }

        public IReadOnlyReactiveProperty<string> CurrentLevel => _currentLevel;
        public IReadOnlyReactiveProperty<string> CurrentExp => _currentExp;
        
        public IReadOnlyReactiveProperty<string> RequiredExp => _requiredExp;

        bool IHeroLevelPresenter.CanLevelUp() => _heroLevelService.CanLevelUp();

        void IHeroLevelPresenter.LevelUp() => _heroLevelService.LevelUp();

        private readonly ReactiveProperty<string> _currentLevel;
        private readonly ReactiveProperty<string> _currentExp;
        private readonly ReactiveProperty<string> _requiredExp;
        
        private HeroLevelService _heroLevelService;

        public HeroLevelPresenter(HeroLevelService heroLevelService)
        {
            _heroLevelService = heroLevelService;
            
            _currentExp = new ReactiveProperty<string>($"{_heroLevelService.CurrentExp}/{heroLevelService.RequiredExp}");
            _currentLevel = new ReactiveProperty<string>("Level: " + _heroLevelService.CurrentExp.ToString());
            _requiredExp = new ReactiveProperty<string>(_heroLevelService.RequiredExp.ToString());
            
            _heroLevelService.OnExpUp += UpdateExp;
            _heroLevelService.OnLevelUp += UpdateLevel;

            OnHided += _heroLevelService.ResetValues;
        }

        public void UpdateExp(int currentExp, int requiredExp)
        {
            _currentExp.Value = $"{currentExp}/{requiredExp}";
        }

        public void UpdateLevel(int level)
        {
            _currentLevel.Value = $"Level: {level.ToString()}";
        }
    }
}