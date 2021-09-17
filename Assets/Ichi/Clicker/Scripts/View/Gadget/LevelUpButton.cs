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

namespace Ichi.Clicker.View
{
    public class LevelUpButton : MonoBehaviour
    {
        [SerializeField]
        private GadgetView gadgetView;
        [SerializeField]
        private GadgetCategory category;
        [SerializeField]
        private Sprite costSprite;
        [SerializeField]
        private Sprite[] gadgetSprites;
        //TODO カテゴリごとの素材設定共通化

        void Start() {
            foreach (var factory in DIContainer.FromGadgetCategory(this.category).Gadgets) {
                factory.OnLevelUp.Subscribe(_ => this.OnAlter()).AddTo(this);
            }
            this.OnAlter();
            this.StartCheatMode();
        }

        private void OnAlter() {
            //NOTE 購読が蓄積する
            this.gadgetView.Initialize(
                DIContainer.FromGadgetCategory(this.category).Gadgets
                    .OrderBy(factory => factory.Cost).FirstOrDefault(),
                this.gadgetSprites,
                this.costSprite
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
                    this.gadgetView.LevelUp();
                }
                await UniTask.Delay(TimeSpan.FromMilliseconds(100), cancellationToken: token);
            }
        }
    }
}
