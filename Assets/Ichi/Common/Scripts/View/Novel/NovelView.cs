using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

namespace Ichi.Common
{
    public class NovelView : MonoBehaviour
    {
        [SerializeField]
        private Button button;
        [SerializeField]
        private Text text;

        public async UniTask Play(IEnumerable<INovel> novels) {
            foreach (var novel in novels) {
                this.text.text = novel.Text;
                await this.button.OnClickAsObservable().TakeUntilDestroy(this);
                //TODO 文字送り
                //TODO ウィンドウ開閉アニメ
            }
        }
    }
}
