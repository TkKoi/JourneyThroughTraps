using UnityEngine;

namespace TombOfTheMaskClone
{
    public class TrapBigSpike : MonoBehaviour
    {
        private const string ATTACK_ANIM = "Attack";

        [Header("Animation Settings")]
        [SerializeField] private float triggerInterval = 2f; // Інтервал у секундах для включення анімації
        [SerializeField] private Animator animator; // Компонент Animator

        private float timer;

        // Start is called before the first frame update
        void Start()
        {
            timer = triggerInterval;
        }

        // Update is called once per frame
        void Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                TriggerAnimation();
                timer = triggerInterval;
            }
        }

        private void TriggerAnimation()
        {
            if (animator != null)
            {
                animator.SetTrigger(ATTACK_ANIM);
            }
        }
    }
}
