using System;
using UniRx;
using UnityEngine;

namespace PM
{
    public interface IHeroInfoPresenter
    {
        public Action OnHided { get; }

        IReadOnlyReactiveProperty<string> Name { get; }
        IReadOnlyReactiveProperty<string> Description { get; }
        IReadOnlyReactiveProperty<Sprite> Icon { get; }
    }
}