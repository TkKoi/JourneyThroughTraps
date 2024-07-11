using UnityEngine;
using DG.Tweening;

namespace JourneyThroughTraps
{
    public class TrapSuriken : MonoBehaviour
    {
        [Header("Animation Settings")]
        [SerializeField] private float interval = 2f; // Interval between animations
        [SerializeField] private float scaleMultiplier = 1.5f; // Scale multiplier for the animation
        [SerializeField] private float animationDuration = 0.5f; // Duration of the animation
        [SerializeField] private float holdDuration = 1f; // Duration to hold the animation

        private Vector3 originalScale;
        private float timer;

        void Start()
        {
            originalScale = transform.localScale;
            timer = interval;
        }

        void Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                TriggerAnimation();
                timer = interval;
            }
        }

        // Trigger the scaling animation using DOTween
        private void TriggerAnimation()
        {
            transform.DOScale(originalScale * scaleMultiplier, animationDuration).OnComplete(() =>
            {
                transform.DOScale(originalScale, animationDuration).SetDelay(holdDuration); // Return to original scale after holding
            });
        }
    }
}
