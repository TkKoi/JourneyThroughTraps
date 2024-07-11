using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TombOfTheMaskClone
{
    public class ComponentDestroy : MonoBehaviour
    {
        [SerializeField] MonoBehaviour[] monoBehaviour;

        // Метод для отключения всех компонентов
        public void DisableAllComponents()
        {
            foreach (var component in monoBehaviour)
            {
                component.enabled = false;

                // Если требуется, можно также убирать активацию игрового объекта компонента
                // component.gameObject.SetActive(false);
            }
        }

        // Метод для включения всех компонентов
        public void EnableAllComponents()
        {
            foreach (var component in monoBehaviour)
            {
                component.enabled = true;

                // Если игровой объект был деактивирован, можно вернуть его к активному состоянию
                // component.gameObject.SetActive(true);
            }
        }
    }
}
