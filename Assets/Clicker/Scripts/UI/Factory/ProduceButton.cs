using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker
{
    public class ProduceButton : MonoBehaviour
    {
        public void Produce() {
            var repository = Repositories.Instance.FactoryRepository;
            foreach (var factory in repository.List()) {
                if (!factory.IsLocked) {
                    repository.Produce(factory);
                }
            }
            Common.PropertyInjector.Modify();
        }
    }
}
