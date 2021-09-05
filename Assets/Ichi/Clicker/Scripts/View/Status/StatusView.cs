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
        private Text coolTime;

        private StatusAdapter adapter;

        void Start() {
            this.adapter = new StatusAdapter();
            DIContainer.FactoryRepository.AlterHandler += this.OnAlter;
            DIContainer.CoinRepository.Coin.AlterHandler += this.OnAlter;
            DIContainer.CommodityRepository.Commodity.AlterHandler += this.OnAlter;
            this.OnAlter();
        }

        void OnDestroy() {
            DIContainer.FactoryRepository.AlterHandler -= this.OnAlter;
            DIContainer.CoinRepository.Coin.AlterHandler -= this.OnAlter;
            DIContainer.CommodityRepository.Commodity.AlterHandler -= this.OnAlter;
        }

        private void OnAlter() {
            this.coin.text = this.adapter.Coin;
            this.coolTime.text = this.adapter.FeverCoolTime;
        }

        //TODO 分ける
    }
}
