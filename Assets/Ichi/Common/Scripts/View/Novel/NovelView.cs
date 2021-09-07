using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Common
{
    [RequireComponent(typeof(WaitTapButton))]
    public class NovelView : MonoBehaviour
    {
        [SerializeField]
        private Text text;

        public async UniTask Play(IEnumerable<INovel> novels) {
            var wait = this.GetComponent<WaitTapButton>();
            var token = this.GetCancellationTokenOnDestroy();
            foreach (var novel in novels) {
                this.text.text = novel.Text;
                await wait.Wait(token);
                //TODO 文字送り
                //TODO ウィンドウ開閉アニメ
            }
        }
    }
}
