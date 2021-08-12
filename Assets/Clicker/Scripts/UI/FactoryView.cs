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
            StartCoroutine("Produce");
        }

        private IEnumerator Produce() {
            while (true) {
                yield return new WaitForSeconds(1.0f);//TODO 生産速度はドメイン
                Repositories.Instance.FactoryRepository.Produce(this.Factory);
            }
        }

        //TODO コイン足りない時ボタンDisable
        //TODO もっと Common にできる？
    }
}
