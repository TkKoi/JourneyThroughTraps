using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

namespace JourneyThroughTraps
{
    public class UILose : UIDisplay
    {
        [SerializeField] CanvasGroup _background;
        [SerializeField] float _fadeTime;
        [SerializeField] float _openDelay = 2f;

        public void Init()
        {
            _background.alpha = 0;
            _background.gameObject.SetActive(false);
        }

        public override void Open()
        {
            DOVirtual.DelayedCall(_openDelay, () =>
            {
                _background.gameObject.SetActive(true);
                _background.DOFade(0.5f, _fadeTime).SetUpdate(true);
                Time.timeScale = 0;
                base.Open();
            }).SetUpdate(true);
        }

        public override void Close()
        {
            base.Close();
            _background.DOFade(0f, _fadeTime).SetUpdate(true).OnComplete(() =>
            {
                _background.gameObject.SetActive(false);
                Time.timeScale = 1;
            });
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
    }
}
