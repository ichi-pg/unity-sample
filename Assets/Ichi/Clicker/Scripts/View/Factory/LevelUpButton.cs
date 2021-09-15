using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Zenject;

namespace Ichi.Clicker.View
{
    public class LevelUpButton : MonoBehaviour
    {
        [Inject]
        private IFactoryRepositories factoryRepositories;
        [SerializeField]
        private FactoryView factoryView;
        [SerializeField]
        private FactoryCategory category;

        void Start() {
            foreach (var factory in this.factoryRepositories.Get(this.category).Factories) {
                factory.OnLevelUp.Subscribe(_ => this.OnAlter()).AddTo(this);
            }
            this.OnAlter();
            this.StartCheatMode();
        }

        private void OnAlter() {
            //NOTE 購読が蓄積する
            this.factoryView.Initialize(
                this.factoryRepositories.Get(this.category).Factories
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
