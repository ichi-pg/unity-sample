using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker.View
{
    public class CoinView : MonoBehaviour
    {
        [SerializeField]
        private Text coin;

        void Start() {
            DIContainer.CoinRepository.Coin.AlterHandler += this.OnAlter;
            this.OnAlter();
        }

        void OnDestroy() {
            DIContainer.CoinRepository.Coin.AlterHandler -= this.OnAlter;
        }

        private void OnAlter() {
            this.coin.text = Common.BigIntegerText.ToString(DIContainer.CoinRepository.Coin.Quantity);
        }
    }
}
