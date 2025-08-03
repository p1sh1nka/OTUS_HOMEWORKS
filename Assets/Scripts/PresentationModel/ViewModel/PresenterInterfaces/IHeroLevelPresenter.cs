using System;
using UniRx;

namespace PM
{
    public interface IHeroLevelPresenter
    {
        public Action OnHided { get; }
        IReadOnlyReactiveProperty<string> CurrentLevel { get; }
        IReadOnlyReactiveProperty<string> CurrentExp { get; }
        IReadOnlyReactiveProperty<string> RequiredExp { get; }
        
        bool CanLevelUp();
        void LevelUp();
    }
}