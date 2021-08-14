using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker
{
    public class BuyableFactoryView : MonoBehaviour
    {
        [SerializeField]
        private Button button;
        private Common.PropertyInjector PropertyInjector { get => this.GetComponent<Common.PropertyInjector>(); }
        private Factory Factory { get => this.PropertyInjector.Data as Factory; }

        void Start() {
            Common.PropertyInjector.ModifyHander += this.UpdateButton;
        }

        void OnDestroy() {
            Common.PropertyInjector.ModifyHander -= this.UpdateButton;
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
