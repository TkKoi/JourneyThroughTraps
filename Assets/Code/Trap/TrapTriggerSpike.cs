using UnityEngine;

namespace JourneyThroughTraps
{
    public class TrapTriggerSpike : MonoBehaviour
    {
        private const string ATTACK_ANIM = "Attack";
        [SerializeField] private Animator targetAnimator;
        [SerializeField] private float delayBeforeAttack = 1.5f; // Delay before the spike attacks

        private bool isCooldown = false;
        private float cooldownTimer = 0f;

        void Update()
        {
            if (isCooldown)
            {
                cooldownTimer += Time.deltaTime; // Increase the cooldown timer
                if (cooldownTimer >= delayBeforeAttack)
                {
                    isCooldown = false;
                    cooldownTimer = 0f;
                    StartAttackAnimation(); // Start the attack animation after the delay
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

        // Start the attack animation
        private void StartAttackAnimation()
        {
            if (targetAnimator != null)
            {
                targetAnimator.SetTrigger(ATTACK_ANIM);
            }
        }
    }
}
