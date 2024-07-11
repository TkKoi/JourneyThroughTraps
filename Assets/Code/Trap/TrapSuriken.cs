using UnityEngine;
using DG.Tweening;

namespace TombOfTheMaskClone
{
    public class TrapSuriken : MonoBehaviour
    {
        [Header("Animation Settings")]
        [SerializeField] private float interval = 2f; // Інтервал у секундах для включення анімації
        [SerializeField] private float scaleMultiplier = 1.5f; // Коефіцієнт збільшення масштабу
        [SerializeField] private float animationDuration = 0.5f; // Тривалість анімації
        [SerializeField] private float holdDuration = 1f; // Тривалість затримки у збільшеному стані

        private Vector3 originalScale;
        private float timer;

        // Start is called before the first frame update
        void Start()
        {
            originalScale = transform.localScale;
            timer = interval;
        }

        // Update is called once per frame
        void Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                TriggerAnimation();
                timer = interval;
            }
        }

        private void TriggerAnimation()
        {
            // Збільшуємо масштаб об'єкта
            transform.DOScale(originalScale * scaleMultiplier, animationDuration).OnComplete(() =>
            {
                // Повертаємося до початкового масштабу після затримки
                transform.DOScale(originalScale, animationDuration).SetDelay(holdDuration);
            });
        }
    }
}
