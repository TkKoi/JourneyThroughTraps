using UnityEngine;
using DG.Tweening;

namespace JourneyThroughTraps
{
    /// <summary>
    /// This class handles the shaking rotation effect of a game object. It uses
    /// DOTween to create a sequence of rotations that simulate a shaking motion.
    /// </summary>
    public class ShakeRotation : MonoBehaviour
    {
        [SerializeField] float shakeDuration = 0.2f; // Duration of one shake
        [SerializeField] float shakeAngle = 10f; // Rotation angle during shake
        [SerializeField] float interval = 2f; // Interval between shakes

        private void Start()
        {
            InvokeRepeating(nameof(Shake), interval, interval);
        }

        /// <summary>
        /// Creates a shaking effect by rotating the game object back and forth.
        /// </summary>
        private void Shake()
        {
            Sequence shakeSequence = DOTween.Sequence();

            // Append rotations to the sequence to create the shaking effect
            shakeSequence.Append(transform.DORotate(new Vector3(0, 0, shakeAngle), shakeDuration).SetEase(Ease.InOutQuad))
                         .Append(transform.DORotate(new Vector3(0, 0, -shakeAngle), shakeDuration).SetEase(Ease.InOutQuad))
                         .Append(transform.DORotate(Vector3.zero, shakeDuration).SetEase(Ease.InOutQuad)).SetUpdate(true);
        }
    }
}
