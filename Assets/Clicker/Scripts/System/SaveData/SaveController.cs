using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Clicker
{
    public class SaveController : MonoBehaviour
    {
        void OnApplicationFocus(bool focus) {
            Repositories.Instance.SaveRepository.Save();
        }

        void OnApplicationPause(bool pause) {
            Repositories.Instance.SaveRepository.Save();
        }

        void OnApplicationQuit() {
            Repositories.Instance.SaveRepository.Save();
        }
    }
}
