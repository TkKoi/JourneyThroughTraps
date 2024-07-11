using UnityEngine;
using DG.Tweening;

namespace TombOfTheMaskClone
{
    public class UIPause : DialogBox
    {
        [SerializeField] CanvasGroup _background;
        [SerializeField] float _fadeTime;
        public void Init()
        {
            _background.alpha = 0;
            _background.gameObject.SetActive(false);
        }
        public override void Open()
        {
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
        }
    }
}
