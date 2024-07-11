using System.Collections.Generic;
using UnityEngine;

namespace StarsSystem
{
    /// <summary>
    /// Loads the stars data from storage.
    /// </summary>
    public class LoadStars : MonoBehaviour
    {
        private IStarStorage starStorage;
        [SerializeField] BiomData biome;

        private void Awake()
        {
            starStorage = new PlayerPrefsStarStorage(); // Can be replaced with another implementation if necessary
        }

        /// <summary>
        /// Loads the number of stars for a specific level and biome.
        /// </summary>
        public int Load_Stars(int level)
        {
            return starStorage.LoadStars(level, biome);
        }
    }
}
