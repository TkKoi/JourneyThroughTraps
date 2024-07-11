using Lean.Pool;
using UnityEngine;

namespace TombOfTheMaskClone
{
    public class Bullet : MonoBehaviour
    {
        private Vector3 direction;
        private float speed;
        [SerializeField] private LayerMask obstacleLayerMask; // LayerMask для визначення об'єктів зіткнення

        // Update is called once per frame
        void Update()
        {
            transform.position += direction * speed * Time.deltaTime;
        }

        public void SetDirection(Vector3 dir, float angle)
        {
            direction = dir;
            // Rotate the bullet to face the direction of travel
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        public void SetSpeed(float spd)
        {
            speed = spd;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (((1 << other.gameObject.layer) & obstacleLayerMask) != 0)
            {
                LeanPool.Despawn(gameObject);
            }
        }
    }
}
