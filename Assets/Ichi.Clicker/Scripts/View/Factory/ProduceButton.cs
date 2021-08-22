using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker
{
    public class ProduceButton : MonoBehaviour
    {
        public void Produce() {
            var repository = Dependency.FactoryRepository;
            foreach (var factory in repository.List(Factory.Categories.Click)) {
                repository.Produce(factory);
            }
            Ichi.Common.DataInjector.Modify();
        }
    }
}
