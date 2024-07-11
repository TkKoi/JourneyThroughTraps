using UnityEngine;
using UnityEditor;

namespace JourneyThroughTraps
{
    [CustomEditor(typeof(CoinSystem))]
    public class CoinSystemEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if (GUILayout.Button("Add 50 Coins"))
            {
                CoinSystem.AddCoins(50);
            }
        }
    }

}