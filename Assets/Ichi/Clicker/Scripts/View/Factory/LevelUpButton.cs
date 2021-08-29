using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker
{
    [RequireComponent(typeof(Button))]
    public class LevelUpButton : MonoBehaviour
    {
        //TODO ViewModelにしたい
        //TODO 長押し

        [SerializeField]
        private Text text;

        void Start() {
            Common.DataInjector.AlterHander += this.OnAlter;
            this.OnAlter();
            this.StartCheatMode();
        }

        void OnDestroy() {
            Common.DataInjector.AlterHander -= this.OnAlter;
        }

        private void OnAlter() {
            var adpter = this.FindFactory();
            this.GetComponent<Button>().interactable = !adpter.LevelUpDisable;
            this.text.text = DIContainer.TextLocalizer.Localize("LevelUpButton", adpter);
        }

        public void LevelUp() {
            this.FindFactory().LevelUp();
        }

        private FactoryAdapter FindFactory() {
            return new FactoryAdapter(
                DIContainer.FactoryRepository
                    .Factories
                    .OrderBy(factory => factory.Cost)
                    .FirstOrDefault()
            );
        }

        [Conditional("UNITY_EDITOR")]
        private void StartCheatMode() {
            this.CheatMode(this.GetCancellationTokenOnDestroy()).Forget();
        }

        private async UniTask CheatMode(CancellationToken token) {
            while (true)
            {
                var cheatMode = this.transform.root.GetComponentInChildren<CheatMode>();
                if (cheatMode != null && cheatMode.Auto) {
                    this.LevelUp();
                }
                await UniTask.Delay(TimeSpan.FromMilliseconds(100), cancellationToken: token);
            }
        }
    }
}
