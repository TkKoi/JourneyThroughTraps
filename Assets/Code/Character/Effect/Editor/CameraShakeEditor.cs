using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(CameraShake))]
public class CameraShakeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.Space(20);
        if (GUILayout.Button("Test Camera Shake"))
        {
            CameraShake.Instance.StartShake();
        }
    }
}
#endif