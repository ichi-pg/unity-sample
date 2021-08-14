using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker
{
    public class FactoryView : Common.PropertyInjector
    {
        [SerializeField]
        private Button button;
        private Factory Factory { get => this.Data as Factory; }

        void Start() {
            this.StartCoroutine("AutoProduce");
            ModifyHander += this.UpdateButton;
        }

        void OnDestroy() {
            ModifyHander -= this.UpdateButton;
        }

        public void LevelUp() {
            Repositories.Instance.FactoryRepository.LevelUp(this.Factory);
            this.transform.parent.GetComponent<FactoryListView>().Reflesh();//TODO 数が増えた時だけ足すだけ
        }

        private IEnumerator AutoProduce() {
            while (this.Data == null) {
                yield return null;
            }
            while (true) {
                yield return new WaitForSeconds(this.Factory.AutoProduceInterval);
                this.Produce();
            }
        }

        public void Produce() {
            Repositories.Instance.FactoryRepository.Produce(this.Factory);
            this.Modify();
        }

        private void UpdateButton() {
            var wallet = Repositories.Instance.WalletRepository.Get();
            this.button.interactable = wallet.Coin >= this.Factory.LevelUpCost;
        }

        //TODO オートモードとタップモードの切り替え（楽 or 効率）
    }
}
