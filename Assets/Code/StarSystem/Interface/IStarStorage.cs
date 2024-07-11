using System.Collections.Generic;

namespace StarsSystem
{
    /// <summary>
    /// Interface for star storage operations.
    /// </summary>
    public interface IStarStorage
    {
        /// <summary>
        /// Saves the number of stars for a specific level and biome.
        /// </summary>
        void SaveStars(int level, BiomData biome, int stars);

        /// <summary>
        /// Loads the number of stars for a specific level and biome.
        /// </summary>
        int LoadStars(int level, BiomData biome);
    }
}
