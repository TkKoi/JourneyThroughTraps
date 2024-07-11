using UnityEngine;
using DG.Tweening;

namespace JourneyThroughTraps
{
    public class UISetting : UIDisplay
    {
        [SerializeField] CanvasGroup _background;
        [SerializeField] float _fadeTime;
        [SerializeField] UIDisplay _menuPanel;
        public void Start()
        {
            _background.alpha = 0;
            _background.gameObject.SetActive(false);
        }
        public override void Open()
        {
            _menuPanel.Close();
            _background.gameObject.SetActive(true);
            _background.DOFade(0.5f, _fadeTime).SetUpdate(true);
            Time.timeScale = 0;
            base.Open();
        }

        public override void Close()
        {
            base.Close();
            _background.DOFade(0f, _fadeTime).SetUpdate(true).OnComplete(() =>
            {
                _background.gameObject.SetActive(false);
                Time.timeScale = 1;
            });
            _menuPanel.Open();
        }
    }
}
