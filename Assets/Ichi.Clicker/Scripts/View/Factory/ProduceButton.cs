using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker
{
    public class ProduceButton : MonoBehaviour
    {
        public void Produce() {
            var repository = Dependency.FactoryRepository;
            foreach (var factory in repository.ClickFactories) {
                if (!factory.IsLocked) {
                    repository.Produce(factory);
                }
            }
            Ichi.Common.DataInjector.Modify();
        }
    }
}
