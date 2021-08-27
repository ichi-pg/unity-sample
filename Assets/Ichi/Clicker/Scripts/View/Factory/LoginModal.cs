using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ichi.Clicker
{
    public class LoginModal : MonoBehaviour
    {
        public void Collect() {
            DIContainer.LoginRepository.Collect(false);
            //TODO 広告で2倍
            //TODO 表示
        }
    }
}
