using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker
{
    public class SaveController : MonoBehaviour
    {
        void OnApplicationFocus(bool focus) {
            Dependency.SaveRepository.Save();
        }

        void OnApplicationPause(bool pause) {
            Dependency.SaveRepository.Save();
        }

        void OnApplicationQuit() {
            Dependency.SaveRepository.Save();
        }
    }
}
