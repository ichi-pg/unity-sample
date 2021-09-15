using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Ichi.Clicker.View
{
    public class CollectButton : MonoBehaviour
    {
        [Inject]
        private ICommodityRepository commodityRepository;

        public void Collect() {
            this.commodityRepository.Collect();
        }
    }
}
