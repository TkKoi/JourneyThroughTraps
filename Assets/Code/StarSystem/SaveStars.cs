using System;
using UnityEngine;

namespace StarsSystem
{
    /// <summary>
    /// Manages the saving and updating of collected stars.
    /// </summary>
    public class SaveStars : MonoBehaviour
    {
        public Action<int> OnStarsChange;
        private int totalStars;
        private IStarStorage starStorage;

        [SerializeField] int level;
        [SerializeField] BiomData biome;

        private void Awake()
        {
            starStorage = new PlayerPrefsStarStorage(); // Can be replaced with another implementation if necessary
        }

        /// <summary>
        /// Adds stars to the total count.
        /// </summary>
        public void AddStars(int stars)
        {
            totalStars += stars;
            Debug.Log("add stars: " + totalStars);
            OnStarsChange?.Invoke(totalStars);
        }

        /// <summary>
        /// Gets the current total stars.
        /// </summary>
        public int GetStars()
        {
            return totalStars;
        }

        /// <summary>
        /// Sets the star rating for the current level and biome.
        /// </summary>
        public void SetStarRating()
        {
            int currentStars = starStorage.LoadStars(level, biome);

            if (totalStars > currentStars)
            {
                starStorage.SaveStars(level, biome, totalStars);
                Debug.Log($"Saved {totalStars} stars for Level {level} in Biome {biome}");
            }

            OnStarsChange?.Invoke(totalStars);
        }

        /// <summary>
        /// Loads the star rating for the current level and biome.
        /// </summary>
        public void LoadStarRating()
        {
            totalStars = starStorage.LoadStars(level, biome);
            OnStarsChange?.Invoke(totalStars);
            Debug.Log($"Loaded {totalStars} stars for Level {level} in Biome {biome}");
        }

        /// <summary>
        /// Gets the star rating for the specified level and biome.
        /// </summary>
        public int GetStarsRating(int level, BiomData biome)
        {
            return starStorage.LoadStars(level, biome);
        }
    }
}
