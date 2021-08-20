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
            Common.DataInjector.ModifyHander += this.OnModify;
            this.OnModify();
        }

        void OnDestroy() {
            Common.DataInjector.ModifyHander -= this.OnModify;
        }

        private void OnModify() {
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
            Common.DataInjector.Modify();
        }
    }
}
