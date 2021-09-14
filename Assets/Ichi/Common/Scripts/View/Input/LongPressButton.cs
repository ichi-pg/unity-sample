using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Ichi.Common
{
    public class LongPressButton : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent onLongPress = new UnityEvent();
        [SerializeField]
        private int intervalMilliseconds;
        private CancellationTokenSource token;

        void OnDestroy() {
            this.token?.Cancel();
        }

        void OnPointerDown(PointerEventData eventData) {
            this.token?.Cancel();
            this.token = new CancellationTokenSource();
            this.LongPress().Forget();
        }

        void OnPointerUp(PointerEventData eventData) {
            this.token?.Cancel();
            //TODO 押したままフォーカス外れた時キャンセルされない説
        }

        private async UniTask LongPress() {
            var interval = TimeSpan.FromMilliseconds(this.intervalMilliseconds);
            while (this.token != null)
            {
                this.onLongPress.Invoke();
                await UniTask.Delay(interval, cancellationToken: this.token.Token);
            }
            //TODO ポッ、ポッ、ポポポポ...って感じの長押し
            //TODO 長押し後に1度だけ発火タイプ
            //TODO 普通のボタンタップとの併用タイプ
        }

        //TODO UniRxにあるっぽいのでいらない説
    }
}
