using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker
{
    public class StatusInjector : MonoBehaviour
    {
        void Start() {
            var injector = this.GetComponent<Common.PropertyInjector>();
            var adapter = new StatusAdapter();
            injector.Inject(adapter);
        }
    }
}
