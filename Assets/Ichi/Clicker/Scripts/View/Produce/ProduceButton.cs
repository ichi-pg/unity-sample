using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker
{
    public class ProduceButton : MonoBehaviour
    {
        public void Produce() {
            DIContainer.ProduceRepository.ClickProduce();
        }
    }
}
