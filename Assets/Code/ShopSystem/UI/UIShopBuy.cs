using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TombOfTheMaskClone
{
    public class UIShopBuy : MonoBehaviour
    {
        private UIShopData _uiHangarData; // Reference to the shop data
        private int[] _secondaryIntArray; // Array to store whether each skin is bought or not
        [SerializeField]
        [Tooltip("Text to display the price of the ship")]
        private TextMeshProUGUI _priceText;
        [SerializeField]
        [Tooltip("Button to buy the ship")]
        private Button _buyButton;
        [SerializeField]
        [Tooltip("Button to select the ship")]
        private Button _selectButton;

        [Header("Not Enough Money Effect")]
        [SerializeField]
        [Tooltip("Image to apply the effect when not enough money")]
        private Image _notEnoughMoneyImage;
        [SerializeField]
        [Tooltip("Duration for showing the not enough money effect in seconds")]
        private float _notEnoughMoneyEffectDuration = 2.0f; // Duration to show the effect

        private bool _isNotEnoughMoneyEffectActive = false; // Flag to indicate if the effect is active

        [Header("Selected Character Indicator")]
        [SerializeField]
        [Tooltip("GameObject to indicate the selected character")]
        private GameObject _selectedCharacterIndicator;

        public void Initialize(UIShopData uiHangarData)
        {
            _uiHangarData = uiHangarData;
            _secondaryIntArray = new int[_uiHangarData._shopData.Length];

            // Load saved data for bought skin
            for (int i = 0; i < _secondaryIntArray.Length; i++)
            {
                int savedValue = PlayerPrefs.GetInt("HangarSelection" + i, 0);
                _secondaryIntArray[i] = savedValue;
            }

            // Ensure the first item is always unlocked
            _secondaryIntArray[0] = 1;
            PlayerPrefs.SetInt("HangarSelection" + 0, 1);
            PlayerPrefs.Save();

            UpdatePriceText(); // Update price text on initialization
            UpdateSelectedCharacterIndicator(); // Update the selected character indicator on initialization
        }

        // Buy the currently selected ship
        public void Buy()
        {
            int currentIndex = _uiHangarData.GetCurrentSelectionIndex();
            int currentPrice = _uiHangarData._shopData[currentIndex].price;

            // Check if the ship is not bought and the player has enough coins
            if (_secondaryIntArray[currentIndex] == 0 && CoinSystem.coins >= currentPrice)
            {
                CoinSystem.TakeCoins(currentPrice); // Deduct coins for the purchase
                _secondaryIntArray[currentIndex] = 1; // Mark the ship as bought
                PlayerPrefs.SetInt("HangarSelection" + currentIndex, 1); // Save the purchase state
                PlayerPrefs.Save();
                UpdatePriceText(); // Update UI state after purchase
            }
            else
            {
                Debug.Log("Not enough coins to buy this ship.");
                if (!_isNotEnoughMoneyEffectActive) // Check if the effect is already active
                {
                    StartCoroutine(ShowNotEnoughMoneyEffect()); // Show the not enough money effect
                }
            }
        }

        // Coroutine to show the not enough money effect for a few seconds
        private IEnumerator ShowNotEnoughMoneyEffect()
        {
            _isNotEnoughMoneyEffectActive = true; // Set the flag to indicate the effect is active
            _notEnoughMoneyImage.gameObject.SetActive(true); // Show the image
            yield return new WaitForSeconds(_notEnoughMoneyEffectDuration); // Wait for the specified duration
            _notEnoughMoneyImage.gameObject.SetActive(false); // Hide the image
            _isNotEnoughMoneyEffectActive = false; // Reset the flag
        }

        // Select the currently selected ship
        public void Select()
        {
            int currentIndex = _uiHangarData.GetCurrentSelectionIndex();

            // Check if the ship is bought
            if (_secondaryIntArray[currentIndex] == 1)
            {
                // Save the selected ship index
                PlayerPrefs.SetInt("SelectedShipIndex", currentIndex);
                PlayerPrefs.Save();

                Debug.Log("Ship selected and saved.");
                UpdateSelectedCharacterIndicator(); // Update the selected character indicator
                // Additional logic for selected ship if needed
            }
            else
            {
                Debug.Log("You must buy the ship before selecting it.");
            }
        }

        // Update the price text based on the ship's purchase state
        public void UpdatePriceText()
        {
            int currentIndex = _uiHangarData.GetCurrentSelectionIndex();
            int currentPrice = _uiHangarData._shopData[currentIndex].price;

            // Check if the ship is already bought
            if (_secondaryIntArray[currentIndex] == 1)
            {
                _priceText.text = "SELECT";
                _selectButton.gameObject.SetActive(true);
                _buyButton.gameObject.SetActive(false);
                _selectButton.interactable = true; // Enable the select button if bought
                _buyButton.interactable = false; // Disable the buy button if already bought
            }
            else
            {
                _priceText.text = currentPrice.ToString(); // Display the price of the ship
                _selectButton.gameObject.SetActive(false);
                _buyButton.gameObject.SetActive(true);
                _selectButton.interactable = false; // Disable the select button if not bought
                _buyButton.interactable = true; // Enable the buy button if not bought
            }

            UpdateSelectedCharacterIndicator(); // Update the selected character indicator whenever the selection changes
        }

        // Update the selected character indicator based on the selected ship
        private void UpdateSelectedCharacterIndicator()
        {
            int selectedShipIndex = PlayerPrefs.GetInt("SelectedShipIndex", 0);
            int currentIndex = _uiHangarData.GetCurrentSelectionIndex();

            // Enable or disable the selected character indicator based on the current selection
            _selectedCharacterIndicator.SetActive(currentIndex == selectedShipIndex);
        }
    }
}
