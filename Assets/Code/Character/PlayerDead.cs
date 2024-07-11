using UnityEngine;

namespace JourneyThroughTraps
{
    [RequireComponent(typeof(Health))]
    public class PlayerDead : MonoBehaviour
    {
        [Header("Health")]
        [SerializeField] Health _health;
        [SerializeField] string _enemyTag = "Enemy";
        [SerializeField] int allEnemyDamage = 1;

        private UILose uiLose;

        [Header("Components")]
        [SerializeField] SpriteRenderer _playerSprite;
        [SerializeField] ComponentDestroy componentData;
        [SerializeField] ParticleSystem deadParticl;

        private void Awake()
        {
            uiLose = FindObjectOfType<UILose>();
        }

        private void OnEnable()
        {
            _health.OnHealthChange += Death;
        }

        private void OnDisable()
        {
            _health.OnHealthChange -= Death;
        }

        private void Death(int health)
        {
            if (health <= 0)
            {
                CameraShake.Instance.StartShake();
                Instantiate(deadParticl.gameObject, new Vector3(transform.position.x, transform.position.y, -0.1f), Quaternion.identity);
                componentData.DisableAllComponents();
                _playerSprite.gameObject.SetActive(false);
                uiLose.Open();
                Debug.Log("Death");
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(_enemyTag))
            {
                _health.ApplyDamage(allEnemyDamage);
                Debug.Log("Damage: " + _health.CurrentHealth);
            }
        }
    }
}
