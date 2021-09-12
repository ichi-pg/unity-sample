using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker.View
{
    public class SaveController : MonoBehaviour
    {
        void OnApplicationFocus(bool focus) {
            DIContainer.SaveRepository.Save();
        }

        void OnApplicationPause(bool pause) {
            DIContainer.SaveRepository.Save();
        }

        void OnApplicationQuit() {
            DIContainer.SaveRepository.Save();
        }
    }
}
