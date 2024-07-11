using UnityEngine;

namespace TombOfTheMaskClone
{
    public class TrapTriggerSpike : MonoBehaviour
    {
        private const string ATTACK_ANIM = "Attack";
        [SerializeField] private Animator targetAnimator;
        [SerializeField] private float delayBeforeAttack = 1.5f; // Затримка перед початком анімації

        private bool isCooldown = false; // Флаг для перевірки часу затримки
        private float cooldownTimer = 0f; // Таймер для відліку часу затримки

        void Update()
        {
            if (isCooldown)
            {
                cooldownTimer += Time.deltaTime;
                if (cooldownTimer >= delayBeforeAttack)
                {
                    isCooldown = false;
                    cooldownTimer = 0f;
                    StartAttackAnimation();
                }
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !isCooldown)
            {
                isCooldown = true;
            }
        }

        private void StartAttackAnimation()
        {
            if (targetAnimator != null)
            {
                targetAnimator.SetTrigger(ATTACK_ANIM);
            }
        }
    }
}
