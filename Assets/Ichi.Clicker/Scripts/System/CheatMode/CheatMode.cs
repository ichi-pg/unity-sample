using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker
{
    public class CheatMode : MonoBehaviour
    {
        [SerializeField]
        private bool enable;
        public bool Enable { get => this.enable; }
    }
}
