using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Ichi.Clicker.View
{
    [CustomEditor(typeof(SaveController))]
    public class SaveControllerEditor : Editor
    {
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            if (GUILayout.Button("Delete")) {
                if (DIContainer.SaveRepository.Exists) {
                    DIContainer.SaveRepository.Delete();
                    if (EditorApplication.isPlaying) {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }
                }
            }
        }
    }
}
