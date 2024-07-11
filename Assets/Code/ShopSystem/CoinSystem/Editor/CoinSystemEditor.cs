using UnityEngine;
using UnityEditor;

namespace TombOfTheMaskClone
{
    [CustomEditor(typeof(CoinSystem))]
    public class CoinSystemEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector(); // Відображення стандартних налаштувань
            // Кнопка для додавання монет
            if (GUILayout.Button("Add 50 Coins"))
            {
                CoinSystem.AddCoins(50);
            }
        }
    }

}