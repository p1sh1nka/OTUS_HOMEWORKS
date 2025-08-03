using System;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace PM
{
    public class HeroLevelView : MonoBehaviour
    {
        [SerializeField] private Text _levelText;
        
        [SerializeField] private Text _expText;
        
        [SerializeField] private Button _levelUpButton;
        
        [SerializeField] private Sprite _levelUpButtonActive;
        [SerializeField] private Sprite _levelUpButronInactive;
        
        [SerializeField] private Image _levelProgressBarNotCompleted;
        [SerializeField] private Image _levelProgressBarCompleted;

        private CompositeDisposable _disposables = new();
        
        private IHeroLevelPresenter _heroLevelPresenter;

        [Inject]
        private void Construct(IHeroLevelPresenter heroLevelPresenter)
        {
            _heroLevelPresenter = heroLevelPresenter;
        }

        public void Show()
        {
            _heroLevelPresenter.CurrentExp.Subscribe(UpdateExp).AddTo(_disposables);
            _heroLevelPresenter.CurrentLevel.Subscribe(UpdateLevel).AddTo(_disposables);
            
            _levelUpButton.onClick.AddListener(_heroLevelPresenter.LevelUp);
            _levelUpButton.onClick.AddListener(UpdateLevelUpButtonState);
            _levelUpButton.onClick.AddListener(UpdateLevelProgressBarState);
        }

        public void Hide()
        {
            _heroLevelPresenter.OnHided.Invoke();
            
            _disposables.Clear();
            
            _levelUpButton.onClick.RemoveListener(_heroLevelPresenter.LevelUp);
            _levelUpButton.onClick.RemoveListener(UpdateLevelUpButtonState);
            _levelUpButton.onClick.RemoveListener(UpdateLevelProgressBarState);
        }
        private void UpdateExp(string exp)
        {
            _expText.text = exp;

            UpdateLevelUpButtonState();
            UpdateLevelProgressBarState();
        }

        private void UpdateLevel(string level)
        {
            _levelText.text = level;
        }

        private void UpdateLevelUpButtonState()
        {
            bool isReadyToLevelUp = _heroLevelPresenter.CanLevelUp();

            if (isReadyToLevelUp)
            {
                _levelUpButton.image.sprite = _levelUpButtonActive;
                _levelUpButton.enabled = true;
            }
            else
            {
                _levelUpButton.image.sprite = _levelUpButronInactive;
                _levelUpButton.enabled = false;
            }
        }

        private void UpdateLevelProgressBarState()
        {
            Debug.Log(_heroLevelPresenter.CurrentExp.Value);
            Debug.Log(_heroLevelPresenter.RequiredExp.Value);
            
            int currentExp = Convert.ToInt32(_heroLevelPresenter.CurrentExp.Value.Split('/')[0]); // небольшой костыль для получения текушей exp во вьюшке 
            int requiredExp = Convert.ToInt32(_heroLevelPresenter.RequiredExp.Value);
            
            if (currentExp <= requiredExp)
            {
                _levelProgressBarCompleted.gameObject.SetActive(false);
                _levelProgressBarNotCompleted.gameObject.SetActive(true);
                _levelProgressBarNotCompleted.fillAmount = (float)currentExp / (float)requiredExp;
            }
            else
            {
                _levelProgressBarCompleted.gameObject.SetActive(true);
                _levelProgressBarNotCompleted.gameObject.SetActive(false);
                _levelProgressBarNotCompleted.fillAmount = (float)currentExp / (float)requiredExp;
            }
            
            
        }
    }
}