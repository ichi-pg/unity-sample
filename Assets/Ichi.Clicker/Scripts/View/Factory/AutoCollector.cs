using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker
{
    public class AutoCollector : MonoBehaviour
    {
        IEnumerator Start() {
            var repository = Dependency.FactoryRepository;
            while (true) {
                foreach (var factory in repository.List(FactoryCategory.Auto)) {
                    repository.Collect(factory);
                }
                Ichi.Common.DataInjector.Modify();
                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}
