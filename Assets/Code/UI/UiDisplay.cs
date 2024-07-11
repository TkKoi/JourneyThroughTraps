using UnityEngine;
using DG.Tweening;

namespace JourneyThroughTraps
{
    public class UIDisplay : MonoBehaviour
    {
        [SerializeField] private bool appearInstantly = false;
        [SerializeField] private float animationSpeed;
        [SerializeField] private Ease openEase = Ease.OutBack;
        [SerializeField] private Ease closeEase = Ease.OutQuart;
        [SerializeField] private UIDisplay previousDialog, nextDialog;

        private void Awake()
        {
            DOTween.Init();
        }

        public virtual void Open()
        {
            gameObject.SetActive(true);

            if (appearInstantly)
            {
                transform.localScale = Vector3.one;
            }
            else
            {
                float currentScale = transform.localScale.x;
                DOTween.To(() => currentScale, x => currentScale = x, 1f, animationSpeed)
                    .SetEase(openEase)
                    .OnUpdate(() =>
                    {
                        transform.localScale = Vector3.one * currentScale;
                    })
                    .SetUpdate(true); // Ensure it updates even when Time.timeScale is 0
            }
        }

        public virtual void Close()
        {
            float currentScale = transform.localScale.x;
            DOTween.To(() => currentScale, x => currentScale = x, 0f, animationSpeed)
                .SetEase(closeEase)
                .OnUpdate(() =>
                {
                    transform.localScale = Vector3.one * currentScale;
                })
                .OnComplete(() =>
                {
                    gameObject.SetActive(false);
                })
                .SetUpdate(true); // Ensure it updates even when Time.timeScale is 0
        }

        public void Return()
        {
            previousDialog?.Open();
            Close();
        }

        public void Continue()
        {
            nextDialog?.Open();
            Close();
        }
    }
}
