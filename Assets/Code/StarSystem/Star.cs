using UnityEngine;

namespace StarsSystem
{
    /// <summary>
    /// Handles the star collection by the player.
    /// </summary>
    public class Star : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                SaveStars saveStars = FindObjectOfType<SaveStars>();
                if (saveStars != null)
                {
                    saveStars.AddStars(1);
                }
                Destroy(gameObject);
            }
        }
    }
}
