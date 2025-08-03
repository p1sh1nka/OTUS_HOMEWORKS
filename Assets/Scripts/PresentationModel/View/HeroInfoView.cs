using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PM
{
    public class HeroInfoView : MonoBehaviour
    {
        [SerializeField] private Text _name; 
        [SerializeField] private Text _description;
        [SerializeField] private Image _icon;
        
        private CompositeDisposable _disposable = new ();
        
        private IHeroInfoPresenter _heroInfoPresenter;

        [Inject]
        private void Construct(IHeroInfoPresenter heroInfoPresenter)
        {
            _heroInfoPresenter = heroInfoPresenter;
        }

        public void Show()
        {
            _heroInfoPresenter.Name.Subscribe(ChangeName).AddTo(_disposable);
            _heroInfoPresenter.Description.Subscribe(ChangeDescription).AddTo(_disposable);
            _heroInfoPresenter.Icon.Subscribe(ChangeIcon).AddTo(_disposable);
        }

        public void Hide()
        {
            _heroInfoPresenter.OnHided.Invoke();
            _disposable.Clear();
        }

        private void ChangeName(string name)
        {
            _name.text = name;
        }

        private void ChangeDescription(string description)
        {
            _description.text = description;
        }

        private void ChangeIcon(Sprite iconSprite)
        {
            _icon.sprite = iconSprite;
        }
    }
}