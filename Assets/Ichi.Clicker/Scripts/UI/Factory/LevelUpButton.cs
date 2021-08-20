using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker
{
    [RequireComponent(typeof(Button))]
    public class LevelUpButton : MonoBehaviour
    {
        [SerializeField]
        private Text text;

        void Start() {
            Ichi.Common.DataInjector.ModifyHander += this.OnModify;
            this.OnModify();
        }

        void OnDestroy() {
            Ichi.Common.DataInjector.ModifyHander -= this.OnModify;
        }

        private void OnModify() {
            var adpter = this.FindFactory();
            this.GetComponent<Button>().interactable = !adpter.LevelUpDisable;
            this.text.text = LocalizationText.Instance.ToString("LevelUpButton", adpter);
        }

        public void LevelUp() {
            this.FindFactory().LevelUp();
        }

        private FactoryAdapter FindFactory() {
            return new FactoryAdapter(
                Repositories.Instance.FactoryRepository
                .List()
                .OrderBy(t => t.Cost)
                .FirstOrDefault()
            );
        }
    }
}
