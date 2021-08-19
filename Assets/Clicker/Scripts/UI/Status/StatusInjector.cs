using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker
{
    [RequireComponent(typeof(Common.PropertyInjector))]
    public class StatusInjector : MonoBehaviour
    {
        void Start() {
            this.GetComponent<Common.PropertyInjector>().Inject(
                new StatusAdapter(),
                ResourceLoader.Instance
            );
        }
    }
}
