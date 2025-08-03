using System;
using System.Collections.Generic;
using UniRx;

namespace PM
{
    public interface IHeroAbilityGroupPresenter
    {
        event Action<IHeroAbilityPresenter> OnAbilityAdded;
        event Action<IHeroAbilityPresenter> OnAbilityRemoved;
        
        IReadOnlyList<IHeroAbilityPresenter> AbilityPresenters { get; }
    }
}