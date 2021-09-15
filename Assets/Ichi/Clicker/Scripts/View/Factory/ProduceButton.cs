using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Ichi.Clicker.View
{
    public class ProduceButton : MonoBehaviour
    {
        [Inject]
        private IClickerRepository clickerRepository;

        public void Produce() {
            this.clickerRepository.Produce();
        }
    }
}
