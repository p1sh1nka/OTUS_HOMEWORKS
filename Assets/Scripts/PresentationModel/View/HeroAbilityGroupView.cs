using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PM
{
    public class HeroAbilityGroupView : MonoBehaviour
    {
        [SerializeField] private Text[] _abilitiesText;
        
        private readonly Dictionary<IHeroAbilityPresenter, Text> _abilities = new();

        private int _currentAbilityIndex = -1;
        private int NextEmptyIndex => _currentAbilityIndex + 1;
        private int MaxAbilityCount => _abilitiesText.Length;
        
        private IHeroAbilityGroupPresenter _abilityGroupPresenter;

        [Inject]
        private void Construct(IHeroAbilityGroupPresenter abilityGroupPresenter)
        {
            _abilityGroupPresenter = abilityGroupPresenter;
        }

        public void Show()
        {
            InitializeValues(_abilityGroupPresenter.AbilityPresenters);
            
            _abilityGroupPresenter.OnAbilityAdded += SetAbilityValue;
            _abilityGroupPresenter.OnAbilityRemoved += RemoveValue;
        }
        
        public void Hide()
        {
            _abilities.Clear();
            _currentAbilityIndex = -1;
            
            _abilityGroupPresenter.OnAbilityAdded -= SetAbilityValue;
            _abilityGroupPresenter.OnAbilityRemoved -= RemoveValue;
        }


        private void InitializeValues(IReadOnlyList<IHeroAbilityPresenter> statPresenters)
        {
            for (int i = 0; i < statPresenters.Count; i++)
                SetAbilityValue(statPresenters[i]);
            
            for (int i = NextEmptyIndex; i < _abilitiesText.Length; i++)
                _abilitiesText[i].text = string.Empty;
        }

        private void SetAbilityValue(IHeroAbilityPresenter abilityPresenter)
        {
            if (_currentAbilityIndex >= MaxAbilityCount)
                return;
            
            Text abilityText = _abilitiesText[NextEmptyIndex];

            _abilities[abilityPresenter] = abilityText;
            AddValue(abilityPresenter);
            
            abilityPresenter.OnValueChanged += SetAbilityValue;
            
            _currentAbilityIndex = NextEmptyIndex;
            
            }

        private void AddValue(IHeroAbilityPresenter abilityPresenter)
        {
            if (!_abilities.ContainsKey(abilityPresenter)) 
                return;

            _abilities[abilityPresenter].text = $"{abilityPresenter.Name}: {abilityPresenter.Value}";
        }

        private void RemoveValue(IHeroAbilityPresenter abilityPresenter)
        {
            if (!_abilities.ContainsKey(abilityPresenter)) 
                return;
            
            _abilities[abilityPresenter].text = string.Empty;
            _abilities.Remove(abilityPresenter);

            _currentAbilityIndex--;
            
            abilityPresenter.OnValueChanged -= SetAbilityValue;
        } 
    }
}