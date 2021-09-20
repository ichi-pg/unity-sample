using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker.View
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GadgetViewDataList", order = 1)]
    public class GadgetViewDataList : ScriptableObject
    {
        [SerializeField]
        private GadgetViewData[] list;

        public GadgetViewData GetViewData(GadgetCategory category) {
            return list[(int)category];
        }
    }
}
