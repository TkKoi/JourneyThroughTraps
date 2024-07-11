using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TombOfTheMaskClone
{
    using UnityEngine;
    using UnityEngine.UI;

    public class ScrollRectFix : MonoBehaviour
    {
        public Scrollbar scrollbar;

        void OnEnable()
        {
            if (scrollbar != null)
            {
                scrollbar.value = 1f; // Установите значение, которое вам нужно
            }
        }
    }
}
