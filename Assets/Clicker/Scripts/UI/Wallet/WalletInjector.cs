using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker
{
    public class WalletInjector : MonoBehaviour
    {
        void Start() {
            var injector = this.GetComponent<Common.PropertyInjector>();
            var adapter = new WalletAdapter(Repositories.Instance.WalletRepository.Get());
            injector.Inject(adapter);
        }
    }
}
