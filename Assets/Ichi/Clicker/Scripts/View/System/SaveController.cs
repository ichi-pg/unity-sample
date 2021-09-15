using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker.View
{
    public class SaveController : MonoBehaviour
    {
        void OnApplicationFocus(bool focus) {
            DIContainer.SaveDataRepository.Save();
        }

        void OnApplicationPause(bool pause) {
            DIContainer.SaveDataRepository.Save();
        }

        void OnApplicationQuit() {
            DIContainer.SaveDataRepository.Save();
        }
    }
}
