using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Ichi.Clicker.View
{
    public class CheatMode : MonoBehaviour
    {
        [Inject]
        private IClickerRepository clickerRepository;
        [Inject]
        private IFactoryRepository factoryRepository;
        [Inject]
        private IFeverRepository feverRepository;
        [SerializeField]
        private bool auto;
        [SerializeField]
        private bool boost;
        public bool Auto { get => this.auto; }

        void OnValidate() {
            this.clickerRepository.CheatMode(this.boost);
            this.factoryRepository.CheatMode(this.boost);
            this.feverRepository.CheatMode(this.boost);
        }
    }
}
