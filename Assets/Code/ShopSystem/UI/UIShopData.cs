using UnityEngine;
using UnityEngine.UI;

namespace JourneyThroughTraps
{
    public class UIShopData : MonoBehaviour
    {
        private const string shopSkinKey = "SelectedSkinIndex";
        [Header("Data")]
        [SerializeField] public ShopData[] _shopData; // Array of shop data
        private int _currentSelectionIndex = 0; // Index of the currently selected skin

        [Header("Main")]
        [SerializeField] Image _spaceShipIcon; // Image to display the skin icon

        /// <summary>
        /// Initializes the hangar UI with the selected skins.
        /// </summary>
        public void Initialize()
        {
            _currentSelectionIndex = PlayerPrefs.GetInt(shopSkinKey, 0);
            ShowSpaceshipInfo(_currentSelectionIndex);
        }

        /// <summary>
        /// Switches to the next or previous skins in the shop.
        /// </summary>
        /// <param name="direction">The direction to switch: -1 for previous, 1 for next.</param>
        public void SwitchSpaceship(int direction)
        {
            _currentSelectionIndex += direction;
            if (_currentSelectionIndex < 0)
                _currentSelectionIndex = _shopData.Length - 1;
            else if (_currentSelectionIndex >= _shopData.Length)
                _currentSelectionIndex = 0;

            ShowSpaceshipInfo(_currentSelectionIndex);
        }

        /// <summary>
        /// Gets the index of the currently selected skin.
        /// </summary>
        /// <returns>The index of the currently selected skin.</returns>
        public int GetCurrentSelectionIndex()
        {
            return _currentSelectionIndex;
        }

        /// <summary>
        /// Displays information about the selected skin.
        /// </summary>
        /// <param name="index">The index of the selected skin in the array.</param>
        private void ShowSpaceshipInfo(int index)
        {
            ShopData selectedSpaceship = _shopData[index];
            _spaceShipIcon.sprite = selectedSpaceship.icon;
        }
    }
}