using UnityEngine;

namespace JourneyThroughTraps
{
    public class TrapMovement : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] float _speed; // Speed of the trap movement
        [SerializeField] float _waitTime; // Wait time at each point

        [Header("Movement Setting")]
        [Tooltip("Points for enemy movement")]
        [SerializeField] Transform[] points; // Points the trap will move between
        private int currentPointIndex = 0;
        private bool isWaiting = false;
        private float waitTimer;

        void Start()
        {
            if (points.Length > 0)
            {
                transform.position = points[0].position; // Set initial position to the first point
                currentPointIndex = 1; // Set the next point index
            }
        }

        void Update()
        {
            Move();
        }

        // Function to handle movement between points
        public void Move()
        {
            if (isWaiting)
            {
                waitTimer -= Time.deltaTime; // Decrease the wait timer
                if (waitTimer <= 0f)
                {
                    isWaiting = false; // Stop waiting when the timer is up
                }
                return;
            }

            if (points.Length == 0) return;

            // Move towards the current point
            transform.position = Vector3.MoveTowards(transform.position, points[currentPointIndex].position, _speed * Time.deltaTime);

            // Check if the trap has reached the current point exactly and update to the next point accordingly
            if (Vector3.Distance(transform.position, points[currentPointIndex].position) < 0.01f)
            {
                currentPointIndex = (currentPointIndex + 1) % points.Length; // Update to the next point index
                isWaiting = true; // Start waiting
                waitTimer = _waitTime; // Reset the wait timer
            }
        }

        // Draw gizmos for movement points and path
        private void OnDrawGizmos()
        {
            if (points.Length > 0)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    Gizmos.DrawWireSphere(points[i].position, 0.5f); // Draw spheres at the points
                    if (i < points.Length - 1)
                    {
                        Gizmos.DrawLine(points[i].position, points[i + 1].position); // Draw lines between points
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
