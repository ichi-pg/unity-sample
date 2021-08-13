using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker
{
    public class FactoryView : Common.PropertyInjector
    {
        private Factory Factory { get => this.Data as Factory; }

        void Start() {
            this.StartCoroutine("AutoProduce");
        }

        public void LevelUp() {
            Repositories.Instance.FactoryRepository.LevelUp(this.Factory);
            this.Modify();
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

        //TODO オートモードとタップモードの切り替え（楽 or 効率）
        //TODO コイン足りない時ボタンDisable
    }
}
