using UnityEngine;

namespace TombOfTheMaskClone
{
    public class TrapMovement : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] float _speed;
        [SerializeField] float _waitTime; // Час очікування на точці

        [Header("Movement Setting")]
        [Tooltip("Points for enemy movement")]
        [SerializeField] Transform[] points;
        private int currentPointIndex = 0;
        private bool isWaiting = false;
        private float waitTimer;

        // Called before the first frame update
        void Start()
        {
            if (points.Length > 0)
            {
                transform.position = points[0].position;
                currentPointIndex = 1;
            }
        }

        // Called once per frame
        void Update()
        {
            Move();
        }

        public void Move()
        {
            if (isWaiting)
            {
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0f)
                {
                    isWaiting = false;
                }
                return;
            }

            if (points.Length == 0) return;

            // Move towards the current point
            transform.position = Vector3.MoveTowards(transform.position, points[currentPointIndex].position, _speed * Time.deltaTime);

            // Check if the enemy has reached the current point exactly and update to the next point accordingly
            if (Vector3.Distance(transform.position, points[currentPointIndex].position) < 0.01f)
            {
                currentPointIndex = (currentPointIndex + 1) % points.Length;
                isWaiting = true;
                waitTimer = _waitTime;
            }
        }

        // Draw gizmos for movement points and path
        private void OnDrawGizmos()
        {
            if (points.Length > 0)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    Gizmos.DrawWireSphere(points[i].position, 0.5f);
                    if (i < points.Length - 1)
                    {
                        Gizmos.DrawLine(points[i].position, points[i + 1].position);
                    }
                    else
                    {
                        Gizmos.DrawLine(points[i].position, points[0].position); // Draw line to first point to complete the loop
                    }
                }
            }
        }
    }
}
