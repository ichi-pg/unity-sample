using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker.View
{
    public class ProduceButton : MonoBehaviour
    {
        public void Produce() {
            DIContainer.ClickerRepository.Produce();
        }
    }
}
