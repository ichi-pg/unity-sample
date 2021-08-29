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

        [SerializeField]
        private Text text;
        private Button button;

        void Start() {
            this.button = this.GetComponent<Button>();
            DIContainer.FactoryRepository.AlterHandler += this.OnAlter;
            DIContainer.CoinRepository.Coin.AlterHandler += this.OnAlter;
            this.OnAlter();
            this.StartCheatMode();
        }

        void OnDestroy() {
            DIContainer.FactoryRepository.AlterHandler -= this.OnAlter;
            DIContainer.CoinRepository.Coin.AlterHandler -= this.OnAlter;
        }

        private void OnAlter() {
            var adpter = new FactoryAdapter(this.FindFactory());
            this.button.interactable = adpter.CanLevelUp;
            this.text.text = DIContainer.TextLocalizer.Localize("LevelUpButton", adpter);
        }

        public void LevelUp() {
            DIContainer.FactoryRepository.LevelUp(this.FindFactory());
            //TODO 長押し
        }

        private IFactory FindFactory() {
            return DIContainer.FactoryRepository
                    .Factories
                    .OrderBy(factory => factory.Cost)
                    .FirstOrDefault();
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
