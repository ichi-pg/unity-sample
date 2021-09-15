using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker.View
{
    public class CollectButton : MonoBehaviour
    {
        public void Collect() {
            DIContainer.CommodityRepository.Collect();
        }
    }
}
