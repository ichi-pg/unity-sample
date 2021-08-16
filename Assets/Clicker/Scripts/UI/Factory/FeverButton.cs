using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker
{
    public class FeverButton : MonoBehaviour
    {
        public void Fever() {
            foreach (var autoProducer in this.transform.root.GetComponentsInChildren<AutoProducer>()) {
                autoProducer.StartCoroutine("Fever");
            }
        }
    }
}
