using UnityEngine;
using UnityEngine.UI;

namespace TombOfTheMaskClone
{
    public class UILevelUnlock : MonoBehaviour
    {
        private const string LevelKeyPrefix = "Level_";
        [SerializeField] private Button levelButton; // Одна кнопка для управления
        [SerializeField] private int currentButtonID = 0; // ID текущей кнопки
        [SerializeField] Image lockImage;

        private void UnlockLevel(int levelID)
        {
            // Разблокировка уровня, если он еще не разблокирован
            if (PlayerPrefs.GetInt(LevelKeyPrefix + levelID, 0) == 0)
            {
                PlayerPrefs.SetInt(LevelKeyPrefix + levelID, 1);
                PlayerPrefs.Save();
            }
        }

        private void UpdateButtonInteractivity()
        {
            bool isLevelUnlocked = PlayerPrefs.GetInt(LevelKeyPrefix + currentButtonID, 0) == 1;
            levelButton.interactable = isLevelUnlocked;
            lockImage.gameObject.SetActive(!isLevelUnlocked);
        }

        public void SetCurrentButtonID(int id)
        {
            UnlockLevel(0);
            currentButtonID = id;
            UpdateButtonInteractivity();
        }
    }
}