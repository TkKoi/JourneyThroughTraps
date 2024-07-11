using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vampire
{
    public class StartLoad : MonoBehaviour
    {
        void Start()
        {
            ShowLoadingPanel.LoadLevel("MainMenu");
        }
    }
}
