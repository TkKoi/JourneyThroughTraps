using StarsSystem;
using UnityEngine;
using TMPro;

namespace JourneyThroughTraps
{
    public class UnlockObject : MonoBehaviour
    {
        [SerializeField] LevelUnlocker levelUnlocker;
        [SerializeField] UIWin uIWinWithCoins;
        [SerializeField] UIWin uIWinWithoutCoins;

        [Header("Stars Setting")]
        [SerializeField] SaveStars starSystem;

        [Header("Coin System")]
        [SerializeField] TextMeshProUGUI addCoinText;
        [SerializeField] int AddCoinsCount;

        [Header("Trigger Setting")]
        [SerializeField] float timeAfterUIOpen;
        [SerializeField] string PlayerTag = "Player";
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(PlayerTag))
            {
                if (!levelUnlocker.IsLevelUnlocked())
                {
                    addCoinText.text = AddCoinsCount.ToString();
                    CoinSystem.AddCoins(AddCoinsCount);
                }
                OpenUI();
                starSystem.SetStarRating();
                levelUnlocker.UnlockLevel();
            }
        }

        private void OpenUI()
        {
            if (!levelUnlocker.IsLevelUnlocked())
            {
                uIWinWithCoins.Open();
            }
            else
            {
                uIWinWithoutCoins.Open();
            }
        }
    }
}
