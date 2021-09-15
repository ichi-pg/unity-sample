using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Ichi.Clicker.View
{
    public class SaveController : MonoBehaviour
    {
        [Inject]
        private ISaveDataRepository saveDataRepository;

        void OnApplicationFocus(bool focus) {
            this.saveDataRepository.Save();
        }

        void OnApplicationPause(bool pause) {
            this.saveDataRepository.Save();
        }

        void OnApplicationQuit() {
            this.saveDataRepository.Save();
        }
    }
}
