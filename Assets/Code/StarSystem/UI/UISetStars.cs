using UnityEngine;

namespace StarsSystem
{
    /// <summary>
    /// Updates the UI to reflect the number of collected stars.
    /// </summary>
    public class UISetStars : MonoBehaviour
    {
        [SerializeField] GameObject[] starObjects; // Array of star objects for display
        [SerializeField] private LoadStars loadStars; // Reference to LoadStars script
        private int level; // Level for which to load the saved stars

        /// <summary>
        /// Sets the level for which to display the stars and updates the display.
        /// </summary>
        /// <param name="level">The level to set.</param>
        public void SetLevel(int level)
        {
            this.level = level;
            UpdateStarDisplay();
        }

        /// <summary>
        /// Updates the star display based on the saved stars for the current level.
        /// </summary>
        private void UpdateStarDisplay()
        {
            if (loadStars != null)
            {
                int stars = loadStars.Load_Stars(level);
                // Enable or disable stars based on the number of saved stars
                for (int i = 0; i < starObjects.Length; i++)
                {
                    starObjects[i].SetActive(i < stars);
                }
            }
            else
            {
                // If loadStars is not found, disable all stars
                for (int i = 0; i < starObjects.Length; i++)
                {
                    starObjects[i].SetActive(false);
                }
            }
        }
    }
}
