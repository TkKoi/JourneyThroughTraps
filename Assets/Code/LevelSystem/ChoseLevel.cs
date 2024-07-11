using UnityEngine;
using UnityEngine.SceneManagement;

namespace TombOfTheMaskClone
{
    public class ChoseLevel : MonoBehaviour
    {
        public void choseLevel(string LevelName)
        {
            ShowLoadingPanel.LoadLevel(LevelName);
        }
    }
}
