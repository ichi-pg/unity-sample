using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker
{
    [RequireComponent(typeof(Common.PropertyInjector))]
    public class StatusInjector : MonoBehaviour
    {
        void Start() {
            var injector = this.GetComponent<Common.PropertyInjector>();
            var adapter = new StatusAdapter();
            injector.Inject(adapter);
        }
    }
}
