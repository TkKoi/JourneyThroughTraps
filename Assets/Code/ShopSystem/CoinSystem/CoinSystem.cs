using System;
using UnityEngine;

namespace JourneyThroughTraps
{
    public class CoinSystem : MonoBehaviour
    {
        // Event to notify when the number of coins changes
        public static Action<int> OnChangeCoin;

        // Static variable to hold the total number of coins
        public static int coins;

        void Start()
        {
            coins = PlayerPrefs.GetInt("Coins", 0);
        }

        /// <summary>
        /// Add coins to the total count.
        /// </summary>
        /// <param name="_coins">Number of coins to add.</param>
        public static void AddCoins(int _coins)
        {
            coins += _coins;
            PlayerPrefs.SetInt("Coins", coins);
            PlayerPrefs.Save();
            OnChangeCoin?.Invoke(coins);
        }

        /// <summary>
        /// Deduct coins from the total count.
        /// </summary>
        /// <param name="_coins">Number of coins to deduct.</param>
        public static void TakeCoins(int _coins)
        {
            coins -= _coins;
            if (coins < 0)
                coins = 0;

            PlayerPrefs.SetInt("Coins", coins);
            PlayerPrefs.Save();
            OnChangeCoin?.Invoke(coins);
        }
    }
}