using UnityEngine;
using DG.Tweening;

namespace TombOfTheMaskClone
{
    public class ShakeRotation : MonoBehaviour
    {
        [SerializeField] float shakeDuration = 0.2f; // Тривалість одного трусіння
        [SerializeField] float shakeAngle = 10f; // Кут повороту при трусінні
        [SerializeField] float interval = 2f; // Інтервал між трусіннями

        private void Start()
        {
            InvokeRepeating(nameof(Shake), interval, interval);
        }

        private void Shake()
        {
            Sequence shakeSequence = DOTween.Sequence();

            shakeSequence.Append(transform.DORotate(new Vector3(0, 0, shakeAngle), shakeDuration).SetEase(Ease.InOutQuad))
                         .Append(transform.DORotate(new Vector3(0, 0, -shakeAngle), shakeDuration).SetEase(Ease.InOutQuad))
                         .Append(transform.DORotate(Vector3.zero, shakeDuration).SetEase(Ease.InOutQuad)).SetUpdate(true);
        }
    }
}
