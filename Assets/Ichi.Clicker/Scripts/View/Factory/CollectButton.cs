using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker
{
    public class CollectButton : MonoBehaviour
    {
        public void Collect() {
            var repository = DIContainer.ItemRepository;
            repository.Sell(repository.Product);
            Common.DataInjector.Modify();
        }
    }
}
