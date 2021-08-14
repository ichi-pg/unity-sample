using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker
{
    public class WalletView : MonoBehaviour
    {
        private Common.PropertyInjector PropertyInjector { get => this.GetComponent<Common.PropertyInjector>(); }

        void Start() {
            PropertyInjector.Inject(Repositories.Instance.WalletRepository.Get());
        }
    }
}
