using System.Collections.Generic;
using UnityEngine;

namespace StarsSystem
{
    /// <summary>
    /// Implementation of IStarStorage using PlayerPrefs.
    /// </summary>
    public class PlayerPrefsStarStorage : IStarStorage
    {
        /// <summary>
        /// Saves the number of stars for a specific level and biome.
        /// </summary>
        public void SaveStars(int level, BiomData biome, int stars)
        {
            PlayerPrefs.SetInt($"Stars_Biome_{(int)biome}_Level_{level}", stars);
            PlayerPrefs.Save();
            // Debug.Log($"Saved {stars} stars for Level {level} in Biome {biome}");
        }

        /// <summary>
        /// Loads the number of stars for a specific level and biome.
        /// </summary>
        public int LoadStars(int level, BiomData biome)
        {
            int stars = PlayerPrefs.GetInt($"Stars_Biome_{(int)biome}_Level_{level}", 0);
            // Debug.Log($"Loaded {stars} stars for Level {level} in Biome {biome}");
            return stars;
        }
    }
}
