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

        private Factory Factory {
            get => Repositories.Instance.FactoryRepository
                .List()
                .OrderBy(t => t.Cost)
                .FirstOrDefault();
        }

        void Start() {
            Common.PropertyInjector.ModifyHander += this.Modify;
            this.Modify();
        }

        void OnDestory() {
            Common.PropertyInjector.ModifyHander -= this.Modify;
        }

        private void Modify() {
            var factory = this.Factory;
            var wallet = Repositories.Instance.WalletRepository.Get();
            var button = this.GetComponent<Button>();
            button.interactable = wallet.Coin >= factory.Cost;
            this.text.text = "Rank"+factory.Rank+
                " Lv"+factory.Level+
                "\n"+Common.BigIntegerText.ToString(factory.Cost);
        }

        public void LevelUp() {
            var factory = this.Factory;
            var wallet = Repositories.Instance.WalletRepository.Get();
            if (wallet.Coin < factory.Cost) {
                return;
            }
            Repositories.Instance.FactoryRepository.LevelUp(factory);
            Common.PropertyInjector.Modify();
        }
    }
}
