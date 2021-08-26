using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker
{
    public class CheatMode : MonoBehaviour
    {
        [SerializeField]
        private bool auto;
        [SerializeField]
        private bool boost;
        public bool Auto { get => this.auto; }

        void OnValidate() {
            Dependency.FactoryRepository.CheatMode(this.boost);
            //TODO オート操作と倍率チートを勘違いするので分ける
        }
    }
}
