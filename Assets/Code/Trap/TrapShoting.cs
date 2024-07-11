using UnityEngine;
using Lean.Pool;

namespace TombOfTheMaskClone
{
    public class TrapShooting : MonoBehaviour
    {
        [SerializeField] private ShootingDirection shotingDirection;
        [SerializeField] private Transform spawnPosition;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float shootingInterval = 1f;
        [SerializeField] private float bulletSpeed = 5f;
        [SerializeField] private Animator animator;

        private float shootingTimer;

        // Start is called before the first frame update
        void Start()
        {
            shootingTimer = shootingInterval;
        }

        // Update is called once per frame
        void Update()
        {
            shootingTimer -= Time.deltaTime;
            if (shootingTimer <= 0f)
            {
                Shot();
                shootingTimer = shootingInterval;
            }
        }

        public void Shot()
        {
            GameObject bullet = LeanPool.Spawn(bulletPrefab, spawnPosition.transform.position, Quaternion.identity);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                Vector3 direction = GetDirectionVector();
                float angle = GetRotationAngle(shotingDirection.direction);
                bulletScript.SetDirection(direction, angle);
                bulletScript.SetSpeed(bulletSpeed);
            }
        }

        private Vector3 GetDirectionVector()
        {
            switch (shotingDirection.direction)
            {
                case ShootingDirection.Direction.Left:
                    return Vector3.left;
                case ShootingDirection.Direction.Right:
                    return Vector3.right;
                case ShootingDirection.Direction.Up:
                    return Vector3.up;
                case ShootingDirection.Direction.Down:
                    return Vector3.down;
                default:
                    return Vector3.zero;
            }
        }

        private float GetRotationAngle(ShootingDirection.Direction direction)
        {
            return shotingDirection.rotationAngle;
        }
    }
}


[System.Serializable]
public class ShootingDirection
{
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }

    public Direction direction;
    public float rotationAngle;
}