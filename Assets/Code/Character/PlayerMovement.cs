using UnityEngine;

namespace JourneyThroughTraps
{
    public enum Direction
    {
        None, Up, Down, Left, Right
    }

    public class PlayerMovement : MonoBehaviour
    {
        [Tooltip("Player's movement speed")]
        [SerializeField] private float speed;
        
        [Tooltip("Position to check if player is grounded")]
        [SerializeField] private Transform groundCheck;
        
        [Tooltip("Radius to check if player is grounded")]
        [SerializeField] private float checkRadius;
        
        [Tooltip("Layer mask to identify ground")]
        [SerializeField] private LayerMask whatIsGround;

        private Rigidbody2D rb;
        
        [SerializeField] private Direction movingDir = Direction.None;
        private Vector3 rotationVector = Vector3.zero;
        private bool isGrounded;

        // Swipe variables
        private const float MAX_SWIPE_TIME = 0.5f;
        private const float MIN_SWIPE_DISTANCE = 0.17f;
        private bool swipedRight = false;
        private bool swipedLeft = false;
        private bool swipedUp = false;
        private bool swipedDown = false;

        private bool debugWithArrowKeys = true;

        private Vector2 startPos;
        private float startTime;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            SwipeMode();
            if (isGrounded)
            {
                if (swipedUp)
                {
                    movingDir = Direction.Up;
                    rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                }
                else if (swipedDown)
                {
                    movingDir = Direction.Down;
                    rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                }
                else if (swipedLeft)
                {
                    movingDir = Direction.Left;
                    rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                }
                else if (swipedRight)
                {
                    movingDir = Direction.Right;
                    rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                }
            }

            UpdateRotation();
        }

        void FixedUpdate()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

            switch (movingDir)
            {
                case Direction.Up:
                    rb.velocity = new Vector2(0, speed * Time.fixedDeltaTime);
                    break;
                case Direction.Down:
                    rb.velocity = new Vector2(0, -speed * Time.fixedDeltaTime);
                    break;
                case Direction.Right:
                    rb.velocity = new Vector2(speed * Time.fixedDeltaTime, 0);
                    break;
                case Direction.Left:
                    rb.velocity = new Vector2(-speed * Time.fixedDeltaTime, 0);
                    break;
                default:
                    rb.velocity = Vector2.zero;
                    break;
            }
        }

        /// <summary>
        /// Handles swipe detection and sets the appropriate swipe flags based on the input.
        /// </summary>
        private void SwipeMode()
        {
            swipedRight = false;
            swipedLeft = false;
            swipedUp = false;
            swipedDown = false;

            if (Input.touches.Length > 0)
            {
                Touch t = Input.GetTouch(0);
                if (t.phase == TouchPhase.Began)
                {
                    startPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);
                    startTime = Time.time;
                }
                if (t.phase == TouchPhase.Ended)
                {
                    if (Time.time - startTime > MAX_SWIPE_TIME) // press too long
                        return;

                    Vector2 endPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);
                    Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);

                    if (swipe.magnitude < MIN_SWIPE_DISTANCE) // Too short swipe
                        return;

                    if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
                    { // Horizontal swipe
                        if (swipe.x > 0)
                            swipedRight = true;
                        else
                            swipedLeft = true;
                    }
                    else
                    { // Vertical swipe
                        if (swipe.y > 0)
                            swipedUp = true;
                        else
                            swipedDown = true;
                    }
                }
            }

            // Debug mode with arrow keys
            if (debugWithArrowKeys)
            {
                swipedDown = swipedDown || Input.GetKeyDown(KeyCode.DownArrow);
                swipedUp = swipedUp || Input.GetKeyDown(KeyCode.UpArrow);
                swipedRight = swipedRight || Input.GetKeyDown(KeyCode.RightArrow);
                swipedLeft = swipedLeft || Input.GetKeyDown(KeyCode.LeftArrow);
            }
        }

        /// <summary>
        /// Updates the player's rotation based on the current movement direction.
        /// </summary>
        private void UpdateRotation()
        {
            switch (movingDir)
            {
                case Direction.Up:
                    rotationVector.z = 180;
                    break;
                case Direction.Down:
                    rotationVector.z = 0;
                    break;
                case Direction.Left:
                    rotationVector.z = -90;
                    break;
                case Direction.Right:
                    rotationVector.z = 90;
                    break;
                default:
                    break;
            }
            transform.rotation = Quaternion.Euler(rotationVector);
        }

        /// <summary>
        /// Draws gizmos in the editor to visualize the ground check radius.
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            if (groundCheck != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
            }
        }
    }
}
