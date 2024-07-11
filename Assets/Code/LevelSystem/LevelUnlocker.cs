using UnityEngine;

namespace TombOfTheMaskClone
{
    public class LevelUnlocker : MonoBehaviour
    {
        [SerializeField] private int levelIndex;
        private const string LevelKeyPrefix = "Level_";
        public void UnlockLevel()
        {
            PlayerPrefs.SetInt(LevelKeyPrefix + levelIndex, 1);
            PlayerPrefs.Save();
        }

        public bool IsLevelUnlocked()
        {
            return PlayerPrefs.GetInt(LevelKeyPrefix + levelIndex, 0) == 1;
        }
    }
}
