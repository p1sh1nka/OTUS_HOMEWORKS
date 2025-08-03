using System;
using UniRx;

namespace PM
{
    public class HeroAbilityPresenter : IHeroAbilityPresenter, IDisposable
    {
        public event Action<IHeroAbilityPresenter> OnValueChanged;
        
        public IReadOnlyReactiveProperty<string> Name => _name;
        public IReadOnlyReactiveProperty<int> Value => _value;

        private readonly ReactiveProperty<string> _name;
        private readonly ReactiveProperty<int> _value;
        
        private HeroAbilityService _heroAbilityService;

        public HeroAbilityPresenter(HeroAbilityService heroAbilityService)
        {
            _heroAbilityService = heroAbilityService;
            
            _name = new ReactiveProperty<string>(heroAbilityService.Name);
            _value = new ReactiveProperty<int>(heroAbilityService.Value);

            _heroAbilityService.OnNameChanged += ChangeName;
            _heroAbilityService.OnValueChanged += ChangeValue;
        }

        public void ChangeName(string name)
        {
            _name.Value = name;
        }

        public void ChangeValue(int value)
        {
            _value.Value = value;
        }

        public void Dispose()
        {
            _heroAbilityService.OnNameChanged -= ChangeName;
            _heroAbilityService.OnValueChanged -= ChangeValue;
        }
    }
}