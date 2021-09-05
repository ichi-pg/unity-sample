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
    public class LevelUpButton : MonoBehaviour
    {
        [SerializeField]
        private FactoryView factoryView;

        void Start() {
            DIContainer.FactoryRepository.AlterHandler += this.OnAlter;
            this.OnAlter();
            this.StartCheatMode();
        }

        void OnDestroy() {
            DIContainer.FactoryRepository.AlterHandler -= this.OnAlter;
        }

        private void OnAlter() {
            this.factoryView.OnDestroy();
            this.factoryView.Initialize(
                DIContainer.FactoryRepository.Factories
                    .OrderBy(factory => factory.Cost).FirstOrDefault()
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
                    this.factoryView.LevelUp();
                }
                await UniTask.Delay(TimeSpan.FromMilliseconds(100), cancellationToken: token);
            }
        }
    }
}
