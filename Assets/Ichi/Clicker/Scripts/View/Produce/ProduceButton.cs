using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker.View
{
    public class ProduceButton : MonoBehaviour
    {
        public void Produce() {
            //TODO Enemy
            DIContainer.ClickerRepository.Produce(new Enemy());
        }
    }
}
