using System;
using UniRx;

namespace PM
{
    public interface IHeroAbilityPresenter
    {
        event Action<IHeroAbilityPresenter> OnValueChanged;
 
        IReadOnlyReactiveProperty<string> Name { get; }
        IReadOnlyReactiveProperty<int> Value { get; }
    }
}