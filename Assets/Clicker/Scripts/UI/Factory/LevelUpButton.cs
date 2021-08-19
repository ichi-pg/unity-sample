using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker
{
    [RequireComponent(typeof(Button))]
    public class LevelUpButton : MonoBehaviour
    {
        [SerializeField]
        private Text text;

        private Factory EfficiencyFactory {
            get {
                var coin = Repositories.Instance.WalletRepository.Get().Coin;
                return Repositories.Instance.FactoryRepository.List()
                    .Where(t => t.Cost <= coin)
                    .OrderBy(t => t.LevelUpEfficiency)
                    .FirstOrDefault();
            }
        }

        void Start() {
            Common.PropertyInjector.ModifyHander += this.Modify;
            this.Modify();
        }

        void OnDestory() {
            Common.PropertyInjector.ModifyHander -= this.Modify;
        }

        private void Modify() {
            var factory = this.EfficiencyFactory;
            var button = this.GetComponent<Button>();
            button.interactable = factory != null;
            if (factory != null) {
                this.text.text = Common.BigIntegerText.ToString(factory.Cost);//TODO もうちょい詳細に
            } else {
                //TODO 何を表示？お金貯まる具合で変化しちゃうから、一番安いのを返すのが正解？
            }
        }

        public void LevelUp() {
            var factory = this.EfficiencyFactory;
            if (factory != null) {
                Repositories.Instance.FactoryRepository.LevelUp(this.EfficiencyFactory);
                Common.PropertyInjector.Modify();
            }
        }
    }
}
