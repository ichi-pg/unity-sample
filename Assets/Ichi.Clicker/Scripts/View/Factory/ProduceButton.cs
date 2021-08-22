using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker
{
    public class ProduceButton : MonoBehaviour
    {
        public const float FeverInterval = 0.1f;

        public void Produce() {
            var repository = Dependency.FactoryRepository;
            foreach (var factory in repository.List(FactoryCategory.Click)) {
                repository.Produce(factory);
            }
            Ichi.Common.DataInjector.Modify();
        }

        IEnumerator Fever() {
            while (true) {
                this.Produce();
                yield return new WaitForSeconds(FeverInterval);
            }
        }
    }
}
