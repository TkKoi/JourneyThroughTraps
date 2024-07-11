using UnityEngine;

namespace JourneyThroughTraps
{
    public class TrapBigSpike : MonoBehaviour
    {
        private const string ATTACK_ANIM = "Attack";

        [Header("Animation Settings")]
        [SerializeField] private float triggerInterval = 2f; // Interval between spike attacks
        [SerializeField] private Animator animator;

        private float timer;


        void Start()
        {
            timer = triggerInterval;
        }


        void Update()
        {
            timer -= Time.deltaTime; // Decrease the timer
            if (timer <= 0f)
            {
                TriggerAnimation(); // Trigger the attack animation
                timer = triggerInterval; // Reset the timer
            }
        }

        // Trigger the attack animation
        private void TriggerAnimation()
        {
            if (animator != null)
            {
                animator.SetTrigger(ATTACK_ANIM);
            }
        }
    }
}
