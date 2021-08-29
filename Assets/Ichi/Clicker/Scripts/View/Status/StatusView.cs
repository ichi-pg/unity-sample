using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker
{
    public class StatusView : MonoBehaviour
    {
        [SerializeField]
        private Text coin;
        [SerializeField]
        private Text product;
        [SerializeField]
        private Text clickPower;
        [SerializeField]
        private Text autoPower;

        private StatusAdapter adapter;

        void Start() {
            this.adapter = new StatusAdapter();
            DIContainer.FactoryRepository.AlterHandler += this.OnAlter;
            DIContainer.CoinRepository.Coin.AlterHandler += this.OnAlter;
            DIContainer.ProductRepository.Product.AlterHandler += this.OnAlter;
            this.OnAlter();
        }

        void OnDestroy() {
            DIContainer.FactoryRepository.AlterHandler -= this.OnAlter;
            DIContainer.CoinRepository.Coin.AlterHandler -= this.OnAlter;
            DIContainer.ProductRepository.Product.AlterHandler -= this.OnAlter;
        }

        private void OnAlter() {
            this.coin.text = DIContainer.TextLocalizer.Localize("Status.Coin", this.adapter);
            this.product.text = DIContainer.TextLocalizer.Localize("Status.Product", this.adapter);
            this.clickPower.text = DIContainer.TextLocalizer.Localize("Status.ClickPower", this.adapter);
            this.autoPower.text = DIContainer.TextLocalizer.Localize("Status.AutoPower", this.adapter);
            //TODO フィーバーレート表示
            //TODO フィーバー残り時間表示
            //TODO フィーバークールタイム表示
        }
    }
}
