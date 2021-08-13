using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker
{
    public class BuyableFactoryView : Common.PropertyInjector
    {
        private Factory Factory { get => this.Data as Factory; }

        public void Buy() {
            Repositories.Instance.FactoryRepository.Buy(this.Factory);
            this.Modify();
            this.transform.parent.GetComponent<FactoryListView>().Reflesh();
        }

        //TODO コイン足りない時ボタンDisable
    }
}
