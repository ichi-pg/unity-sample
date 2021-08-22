using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker
{
    [RequireComponent(typeof(Button))]
    public class FeverButton : MonoBehaviour
    {
        public const float FeverSeconds = 30.0f;

        public void Fever() {
            foreach (var produceButton in this.transform.root.GetComponentsInChildren<ProduceButton>()) {
                produceButton.StartCoroutine("Fever");
            }
            this.StartCoroutine("Disable");
            //TODO 広告
        }

        IEnumerator Disable() {
            var button = this.GetComponent<Button>();
            button.interactable = false;
            yield return new WaitForSeconds(FeverSeconds);
            foreach (var produceButton in this.transform.root.GetComponentsInChildren<ProduceButton>()) {
                produceButton.StopCoroutine("Fever");
            }
            button.interactable = true;
            //TODO 残り時間の表示
        }
    }
}
