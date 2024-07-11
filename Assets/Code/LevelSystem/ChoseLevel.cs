using UnityEngine;

namespace JourneyThroughTraps
{
    public class ChoseLevel : MonoBehaviour
    {
        public void choseLevel(string LevelName)
        {
            ShowLoadingPanel.LoadLevel(LevelName);
        }
    }
}
