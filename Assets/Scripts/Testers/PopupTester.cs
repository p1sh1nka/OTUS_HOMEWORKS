using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PM
{
    public class PopupTester : MonoBehaviour
    {
        [SerializeField] private string _newName;
        
        [SerializeField] private string _newDescription;
        
        [SerializeField] private Sprite _newIcon;
        
        [SerializeField] private int _expToAdd;
        
        [SerializeField] private string _newAbilityName;
        
        [SerializeField] private int _newAbilityValue;
        
        private HeroView _heroView;
        private HeroInfoService _heroInfoService;
        private HeroLevelService _heroLevelService;
        private HeroAbilityGroupService _heroAbilityGroupService;

        [Inject]
        private void Construct(HeroView heroView, HeroInfoService heroInfoService, HeroLevelService heroLevelService, HeroAbilityGroupService heroAbilityGroupService)
        {
            _heroView = heroView;
            _heroInfoService = heroInfoService;
            _heroLevelService = heroLevelService;
            _heroAbilityGroupService = heroAbilityGroupService;
        }

        [ContextMenu("Change Name")]
        public void ChangeName()
        {
            _heroInfoService.UpdateName(_newName);
        }
        
        [ContextMenu("Change Description")]
        public void ChangeDescription()
        {
            _heroInfoService.UpdateDescription(_newDescription);
        }
        
        [ContextMenu("Change Icon")]
        public void ChangeIcon()
        {
            _heroInfoService.UpdateIcon(_newIcon);
        }
        
        [ContextMenu("Add Exp")]
        public void AddExp()
        {
            _heroLevelService.AddExp(_expToAdd);
        }
        
        [ContextMenu("Add Ability")]
        public void AddAbility()
        {
            HeroAbilityService heroAbilityService = new HeroAbilityService();
            
            heroAbilityService.ChangeName(_newAbilityName);
            heroAbilityService.ChangeValue(_newAbilityValue);
            
            _heroAbilityGroupService.TryAddHeroAbility(heroAbilityService);
        }
        
        [ContextMenu("Remove Ability")]
        public void RemoveAbility()
        {
            HeroAbilityService[] heroAbilityServices = _heroAbilityGroupService.GetAbilities();
            _heroAbilityGroupService.TryRemoveHeroAbility(heroAbilityServices[^1]);
        }
        
        [ContextMenu("Show Popup")]
        internal void ShowPopup()
        {
            _heroView.Show();
        }
        
        [ContextMenu("Hide Popup")]
        internal void HidePopup()
        {
            _heroView.Hide();
        }
    }
}