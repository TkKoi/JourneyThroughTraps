using UnityEngine;

namespace JourneyThroughTraps
{
    public class UIInit : MonoBehaviour
    {
        [SerializeField] UIPause uIPause;
        [SerializeField] UIWin uIWinWithCoin;
        [SerializeField] UIWin uIWinWithoutCoin;
        [SerializeField] UILose uILose;
        private void Awake()
        {
            uIPause.Init();
            uIWinWithCoin.Init();
            uIWinWithoutCoin.Init();
            uILose.Init();
        }
    }
}
