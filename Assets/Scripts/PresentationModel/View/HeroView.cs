using UnityEngine;
using UnityEngine.UI;

namespace PM
{
    public class HeroView : MonoBehaviour
    {
        [SerializeField] private HeroInfoView _heroInfoView;
        [SerializeField] private HeroLevelView _heroLevelView;
        [SerializeField] private HeroAbilityGroupView _heroAbilityGroupView;
        
        [SerializeField] private Button _closeButton;

        private void Awake()
        {
            if (this.TryGetComponent(out HeroInfoView heroInfoView))
            {
                _heroInfoView = heroInfoView;
            }

            if (this.TryGetComponent(out HeroLevelView heroLevelView))
            {
                _heroLevelView = heroLevelView;
            }

            if (this.TryGetComponent(out HeroAbilityGroupView heroAbilityGroupView))
            {
                _heroAbilityGroupView = heroAbilityGroupView;
            }
        }

        public void Show()
        {
            this.gameObject.SetActive(true);
            
            _heroInfoView.Show();
            _heroLevelView.Show();
            _heroAbilityGroupView.Show();
            
            _closeButton.onClick.AddListener(Hide);
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
            
            _heroInfoView.Hide();
            _heroLevelView.Hide();
            _heroAbilityGroupView.Hide();
            
            _closeButton.onClick.RemoveListener(Hide);
        }
    }
}