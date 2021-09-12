using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker.View
{
    public class LevelUpButton : MonoBehaviour
    {
        [SerializeField]
        private FactoryView factoryView;
        [SerializeField]
        private FactoryCategory category;

        void Start() {
            DIContainer.FromFactoryCategory(this.category).AlterHandler += this.OnAlter;
            this.OnAlter();
            this.StartCheatMode();
        }

        void OnDestroy() {
            DIContainer.FromFactoryCategory(this.category).AlterHandler -= this.OnAlter;
        }

        private void OnAlter() {
            this.factoryView.OnDestroy();
            this.factoryView.Initialize(
                DIContainer.FromFactoryCategory(this.category).Factories
                    .OrderBy(factory => factory.Cost).FirstOrDefault()
            );
        }

        [Conditional("UNITY_EDITOR")]
        private void StartCheatMode() {
            this.CheatMode(this.GetCancellationTokenOnDestroy()).Forget();
        }

        private async UniTask CheatMode(CancellationToken token) {
            var cheatMode = (CheatMode)FindObjectOfType(typeof(CheatMode));
            while (true) {
                if (cheatMode.Auto) {
                    this.factoryView.LevelUp();
                }
                await UniTask.Delay(TimeSpan.FromMilliseconds(100), cancellationToken: token);
            }
        }
    }
}
