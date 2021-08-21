using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker
{
    public class TextLocalizer : MonoBehaviour
    {
        private const string Prefix = "Localize.";

        void Start() {
            this.OverwriteTexts();
        }

        void OnGUI() {
            this.OverwriteTexts();
        }

        private void OverwriteTexts() {
            foreach (Text text in this.GetComponentsInChildren<Text>()) {
                if (text.name.StartsWith(Prefix)) {
                    var key = text.name.Replace(Prefix,"");
                    text.text = Dependency.LocalizationText.Localize(key);
                }
            }
        }
    }
}
