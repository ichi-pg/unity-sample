using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker
{
    public class LoginModal : MonoBehaviour
    {
        [SerializeField]
        private Text quantity;
        [SerializeField]
        private Text percentage;

        void Start() {
            this.quantity.text = Common.BigIntegerText.ToString(DIContainer.LoginRepository.Quantity);
            this.percentage.text = DIContainer.LoginRepository.Percentage+"%";
        }

        public void Collect() {
            DIContainer.LoginRepository.Collect(false);
            //TODO 広告で2倍
        }
    }
}
