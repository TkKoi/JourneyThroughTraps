using UnityEngine;

namespace StarsSystem
{
    /// <summary>
    /// Updates the UI counter for collected stars.
    /// </summary>
    public class UIStarCounter : MonoBehaviour
    {
        public GameObject[] starObjects; // Array of star objects for display
        [SerializeField] private SaveStars saveStars;

        private void OnEnable()
        {
            saveStars.OnStarsChange += UpdateStarDisplay;
        }

        private void OnDisable()
        {
            saveStars.OnStarsChange -= UpdateStarDisplay;
        }

        /// <summary>
        /// Updates the star display based on the number of collected stars.
        /// </summary>
        private void UpdateStarDisplay(int stars)
        {
            Debug.Log("Updating star display: " + stars);
            // Enable or disable stars based on the number of collected stars
            for (int i = 0; i < starObjects.Length; i++)
            {
                starObjects[i].SetActive(i < stars);
            }
        }
    }
}
