using System.Collections;
using System.Collections.Generic;
using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker
{
    [RequireComponent(typeof(Button))]
    public class FeverButton : MonoBehaviour
    {
        public async void Fever() {
            var button = this.GetComponent<Button>();
            button.interactable = false;
            var observer = Observable.Interval(TimeSpan.FromMilliseconds(100))
                .Subscribe(_ => this.ProduceAll())
                .AddTo(this);
            await UniTask.Delay(
                TimeSpan.FromSeconds(30),
                cancellationToken: this.GetCancellationTokenOnDestroy()
            );
            observer.Dispose();
            button.interactable = true;
            //TODO 広告
        }

        public void ProduceAll() {
            foreach (var produceButton in this.transform.root.GetComponentsInChildren<ProduceButton>()) {
                produceButton.Produce();
            }
        }
    }
}
