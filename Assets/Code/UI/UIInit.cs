using UnityEngine;

namespace TombOfTheMaskClone
{
    public class UIInit : MonoBehaviour
    {
        [SerializeField] UIPause uIPause;
        [SerializeField] UIWin uIWin;
        [SerializeField] UILose uILose;
        private void Awake()
        {
            uIPause.Init();
            uIWin.Init();
            uILose.Init();
        }
    }
}
