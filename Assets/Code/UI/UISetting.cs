using UnityEngine;
using DG.Tweening;

namespace TombOfTheMaskClone
{
    public class UISetting : DialogBox
    {
        [SerializeField] CanvasGroup _background;
        [SerializeField] float _fadeTime;
        [SerializeField] DialogBox _menuPanel;
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
            }); // Fade до 0 за 0.5 секунды, игнорируя Time.timeScale, после чего выполнить закрытие
            _menuPanel.Open();
        }
    }
}
