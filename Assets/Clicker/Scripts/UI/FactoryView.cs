using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker
{
    public class FactoryView : Common.PropertyInjector
    {
        private Factory Factory { get => this.Data as Factory; }

        public void LevelUp() {
            Repositories.Instance.FactoryRepository.LevelUp(this.Factory);
            StartCoroutine("AutoProduce");
        }

        private IEnumerator AutoProduce() {
            while (true) {
                yield return new WaitForSeconds(this.Factory.AutoProduceInterval);
                this.Produce();
            }
        }

        public void Produce() {
            Repositories.Instance.FactoryRepository.Produce(this.Factory);
        }

        //TODO オートモードとタップモードの切り替え（楽 or 効率）
        //TODO コイン足りない時ボタンDisable
        //TODO もっと Common にできる？
    }
}
