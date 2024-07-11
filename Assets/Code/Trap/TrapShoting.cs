using UnityEngine;
using Lean.Pool;

namespace JourneyThroughTraps
{
    public class TrapShooting : MonoBehaviour
    {
        [SerializeField] private ShootingDirection shotingDirection;
        [SerializeField] private Transform spawnPosition;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float shootingInterval = 1f; // Interval between shots
        [SerializeField] private float bulletSpeed = 5f; // Speed of the bullet
        [SerializeField] private Animator animator;

        private float shootingTimer;


        void Start()
        {
            shootingTimer = shootingInterval; // Initialize the shooting timer
        }


        void Update()
        {
            shootingTimer -= Time.deltaTime; // Decrease the shooting timer
            if (shootingTimer <= 0f)
            {
                Shot(); // Shoot a bullet
                shootingTimer = shootingInterval; // Reset the shooting timer
            }
        }

        // Shoot a bullet
        public void Shot()
        {
            GameObject bullet = LeanPool.Spawn(bulletPrefab, spawnPosition.transform.position, Quaternion.identity); // Spawn a bullet
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                Vector3 direction = GetDirectionVector(); // Get the direction vector
                float angle = GetRotationAngle(shotingDirection.direction); // Get the rotation angle
                bulletScript.SetDirection(direction, angle); // Set the bullet's direction and angle
                bulletScript.SetSpeed(bulletSpeed); // Set the bullet's speed
            }
        }

        // Get the direction vector based on the shooting direction
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

        // Get the rotation angle based on the shooting direction
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

    public Direction direction; // Direction of the shooting
    public float rotationAngle; // Rotation angle of the shooting
}
