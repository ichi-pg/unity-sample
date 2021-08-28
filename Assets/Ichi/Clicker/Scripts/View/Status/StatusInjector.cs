using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker
{
    [RequireComponent(typeof(Common.DataInjector))]
    public class StatusInjector : MonoBehaviour
    {
        void Start() {
            this.GetComponent<Common.DataInjector>().Inject(
                new StatusAdapter(),
                DIContainer.ResourceLoader
            );
        }
    }
}
