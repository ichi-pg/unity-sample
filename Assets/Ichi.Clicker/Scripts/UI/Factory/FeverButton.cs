using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker
{
    [RequireComponent(typeof(Button))]
    public class FeverButton : MonoBehaviour
    {
        public void Fever() {
            foreach (var autoProducer in this.transform.root.GetComponentsInChildren<AutoProducer>()) {
                autoProducer.StartCoroutine("Fever");
            }
            this.StartCoroutine("Disable");
        }

        IEnumerator Disable() {
            var button = this.GetComponent<Button>();
            button.interactable = false;
            yield return new WaitForSeconds(AutoProducer.FeverSeconds);
            button.interactable = true;
        }
    }
}
