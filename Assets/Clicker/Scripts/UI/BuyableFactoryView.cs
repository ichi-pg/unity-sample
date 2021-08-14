using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker
{
    public class BuyableFactoryView : Common.PropertyInjector
    {
        [SerializeField]
        private Button button;
        private Factory Factory { get => this.Data as Factory; }

        void Start() {
            ModifyHander += this.UpdateButton;
        }

        void OnDestroy() {
            ModifyHander -= this.UpdateButton;
        }

        public void Buy() {
            Repositories.Instance.FactoryRepository.Buy(this.Factory);
            this.transform.parent.GetComponent<FactoryListView>().Reflesh();//TODO 足すだけで再構築しなくていい
        }

        private void UpdateButton() {
            Wallet wallet = Repositories.Instance.WalletRepository.Get();
            this.button.interactable = wallet.Coin >= this.Factory.BuyCost;
        }
    }
}
