using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker
{
    [RequireComponent(typeof(Ichi.Common.DataInjector))]
    public class StatusInjector : MonoBehaviour
    {
        void Start() {
            this.GetComponent<Ichi.Common.DataInjector>().Inject(
                new StatusAdapter(),
                Dependency.ResourceLoader
            );
        }
    }
}
